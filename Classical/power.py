import math
import fastPow
import miller_robin


def power(N):
    def isPower(l, r, s, N):
        if (l > r):
            return -1
        mid = (l + r) / 2
        ans = fastPow.fastPowBool(mid, s, N)
        if (ans == N):
            return mid
        elif (ans < N):
            return isPower(mid+1, r, s, N)
        else:
            return isPower(l, mid-1, s, N)

    s = int(math.floor(math.log(N, 2))) + 1
    r = int(math.floor(math.sqrt(N))) + 1
    for i in range(2, s):
        ans = isPower(2, r, i, N)
        if ans != -1:
            return ans
    return -1
