# Answer for Question 5
# By Arson Marianus

import sys
sys.setrecursionlimit(20000)

def check(maps, checked, row, col, x, y):
	if x < 0 or y < 0 or x >= row or y >= col or checked[x][y] == True or maps[x][y] == '#':
		return

	checked[x][y] = True

	if not maps[x][y] == ".":
		tmp_troops.append(maps[x][y])

	check(maps, checked, row, col, x, y+1)
	check(maps, checked, row, col, x, y-1)
	check(maps, checked, row, col, x+1, y)
	check(maps, checked, row, col, x-1, y)
	return

tmp_troops = []
troops = []
counter = []
contested = []

T = int(input())

for x in range(T):
	N = int(input())
	M = int(input())

	if (1<=T<=100) and (1<=N<=100) and (1<=M<=100):
		maps = [[None] * M for _ in range(N)]
		checked = [[False] * M for _ in range(N)]
		location = []

		for i in range(N):
			tmp = input()
			for j,k in enumerate(tmp):
				maps[i][j] = k
				if not k == '#' and not k == '.':
					location.append([i,j,k])

		count_contested = 0
		local_troops = []
		local_counter = []
		for i in range(N):
			for j in range(M):
				check(maps, checked, N, M, i, j)
				if not tmp_troops == []:
					filtered_troops = list(dict.fromkeys(tmp_troops))
					if len(filtered_troops) > 1:
						count_contested = count_contested + 1
					else:
						local_troops.append(filtered_troops[0])
				tmp_troops.clear()
		local_troops.sort()
		troops.append(local_troops)
		contested.append(count_contested)
		res = {}
		for i in local_troops:
			res[i] = local_troops.count(i)
		for (k,v) in res.items():
			local_counter.append(v)
		counter.append(local_counter)

for i in range(len(contested)):
	print(f"Case {i+1}:")
	for j,k in zip(list(dict.fromkeys(troops[i])), counter[i]):
		print(j,k)
	print("contested",contested[i])
