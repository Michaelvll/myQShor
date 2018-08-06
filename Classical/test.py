import shor
if __name__ == "__main__":
    alg = shor.myShor(6, 3)
    with open('test.out', 'w', encoding='utf8') as outfile:
        for i in range(1, 100):
            print(alg.shor(i), file=outfile)
            outfile.flush()
