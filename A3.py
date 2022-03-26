# Question 4
# By Arson Marianus

buff = []

T = int(input())

for i in range(T):
    A = int(input())
    B = int(input())
    K = int(input())

    if((1 <= T <= 100) and (1 <= A <= B < 10000) and (1 <= K < 10000)):
        counter = 0
        for j in range(A,B+1):
            if not j % K:
                counter = counter + 1
        buff.append(counter)

for i,v in enumerate(buff):
    print(f"Case {i+1}: {v}")

