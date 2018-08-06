import gcd
import fastPow
import miller_robin
import fraction
import power
import random
from multiprocessing.pool import ThreadPool
import qsharp

# Initializing
import sys
sys.path.append('../myShorLib/bin/Release/netstandard2.0')

import clr
clr.AddReference("Microsoft.Quantum.Canon")
clr.AddReference('myShorLib')

from myShorLib import PhaseEstimation


class myShor():
    def __init__(self, precision, thread_num):
        self.Precision = precision
        self.Thread_Num = thread_num

    def order_finding(self, x, n):
        qsim = qsharp.QuantumSimulator()

        def phase_estimation(x, n):
            tmp = int(qsim.run(PhaseEstimation, x, n,
                               self.Precision).result().clr_object)
            theta = float(tmp) / (2**self.Precision)
            return theta

        for _ in range(2):
            theta = phase_estimation(x, n)
            if theta == 0:
                print("========\nOrder Finding for: x={}, N={}\nGet theta: {}\nNo r estimated\n".format(
                    x, n, theta))
                continue

            r = fraction.denominator(theta, n)
            print("========\nOrder Finding for: x={}, N={}\nGet theta: {}\nEstimate r: {}\n".format(
                x, n, theta, r))
            for i in r:
                m = fastPow.fastPow(x, i, n)
                if m == 1:
                    return i
        return -1

    def shor(self, n):
        if miller_robin.miller_robin(n):
            return (1, n)
        else:
            tmp = power.power(n)
            if tmp != -1:
                return (tmp, n // tmp)
            else:
                if (n % 2 == 0):
                    return (2, n // 2)
                while True:
                    # Parrel computing for some random x
                    xlist = random.sample(range(3, n - 1), self.Thread_Num)
                    g = [gcd.gcd(x, n) for x in xlist]
                    for idx, g in enumerate(g):
                        if (g != 1):
                            # ======= For debug ===========
                            # while gcd.gcd(xlist[idx], n) != 1:
                            #     newx = random.randint(3, n - 1)
                            #     xlist[idx] = newx
                            # ======= In Real Quantum Computer =========
                            return (g, n // g)

                    print("======== Order Finding Started ========")
                    threadPool = ThreadPool(processes=self.Thread_Num)
                    results = []
                    for x in xlist:
                        results.append(threadPool.apply_async(
                            self.order_finding, args=(x, n)))
                    threadPool.close()
                    threadPool.join()
                    results = [r.get() for r in results]

                    for r in results:
                        if r == -1:
                            continue
                        if (r % 2 == 0):
                            s = fastPow.fastPow(x, r // 2, n)
                            if (s != 1 and s != n-1):
                                g1 = gcd.gcd(s+1, n)
                                g2 = gcd.gcd(s-1, n)
                                if (g1 != 1):
                                    return (g1, n // g1)
                                elif (g2 != 1):
                                    return (g2, n // g2)


if __name__ == "__main__":
    n = int(input())
    alg = myShor(6, 3)
    print("The factor of {} is {}".format(n, alg.shor(n)))
