def fastPow(a, b, N):
    ans = 1
    while (b > 0):
        if b % 2:
            ans = ans * a % N
        b = b // 2
        a = a * a
    return ans


def fastPowBool(a, b, N):
    ans = 1
    while (b > 0):
        if b % 2:
            ans = ans * a
        b = b // 2
        a = a * a
        if (ans > N):
            return ans
    return ans
