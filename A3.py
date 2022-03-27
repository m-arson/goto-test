# Answer for Question 3
# By Arson Marianus

buff = []

T = int(input())

for _ in range(T):
    A = int(input())
    B = int(input())
    K = int(input())

    if (1<=T<= 100) and (1<=A<=B<10000) and (1<=K<10000):
        counter = 0
        for i in range(A,B+1):
            if not i % K:
                counter = counter + 1
        buff.append(counter)

for i,v in enumerate(buff):
    print(f"Case {i+1}: {v}")

