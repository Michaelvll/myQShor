import math


def denominator(x, N):
    seq = []
    if (x < 1):
        x = 1 / x
    k = 10
    for i in range(10):
        seq.append(math.floor(x))
        if (abs(x - math.floor(x)) < 1e-9):
            k = i + 1
            break
        x = 1 / (x - math.floor(x))
    ans = []
    ans2 = []
    for i in range(k):
        up = 1
        down = seq[i]
        for j in range(i):
            t = seq[i-1-j]
            d = down
            down = down * t + up
            up = d
        ans.append(int(down))
        ans2.append(int(up))
    return ans
