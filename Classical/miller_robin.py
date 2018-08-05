import random
import ksm


def miller_robin(n):
    # print("start miller robin")
    if n == 2 or n == 3:
        return True

    if n % 2 == 0:
        return False

    t = 10

    q = 0
    m = n-1
    while m % 2 == 0:
        q += 1
        m /= 2

    for i in range(t):
        a = random.randint(2, n-2)
        x = ksm.ksm(a, m, n)

        if x == 1:
            continue

        j = 0
        while j < q and x != n-1:
            x = (x * x) % n
            j += 1

        if j >= q:
            return False
    # print("end miller robin")
    return True
