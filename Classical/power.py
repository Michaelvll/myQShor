import math
import ksm
import miller_robin


def isPower(l, r, s, N):
    if (l > r):
        return -1
    mid = (l + r) / 2
    ans = ksm.ksmBool(mid, s, N)
    if (ans == N):
        return mid
    elif (ans < N):
        return isPower(mid+1, r, s, N)
    else:
        return isPower(l, mid-1, s, N)


def power(N):
    # print("start power")
    s = int(math.floor(math.log(N, 2))) + 1
    r = int(math.floor(math.sqrt(N))) + 1
    for i in range(2, s):
        ans = isPower(2, r, i, N)
        if ans != -1:
            return ans
    # print("end power")
    return -1
