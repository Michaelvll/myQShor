import shor
if __name__ == "__main__":
    with open('test.out', 'w', encoding='utf8') as outfile:
        for i in range(3, 100):
            print(shor.shor(i), file=outfile)
            outfile.flush()
