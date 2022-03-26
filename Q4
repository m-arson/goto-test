# Question 4
# By Arson Marianus

def find_word_horizontally(words, key):
	count = 0
	inx = 0
	for word in words:
		inx = 0
		while inx+len(key) < len(word) + 1:
			if(word[inx:inx+len(key)] == key):
				count = count + 1
			inx = inx + 1
		inx = 0
		word = word[::-1]
		while inx+len(key) < len(word) + 1:
			if(word[inx:inx+len(key)] == key):
				count = count + 1
			inx = inx + 1
	return count

def find_word_vertically(words, key):
	if len(words) < len(key):
		return 0

	new_words = []

	for i in range(len(words[0])):
		tmp = ""
		for j in range(len(words)):
			tmp = tmp + words[j][i]
		new_words.append(tmp)

	return find_word_horizontally(new_words, key)

def find_word_diagonally(words, key):
	if len(words) < len(key):
		return 0
	if len(words[0]) < len(key):
		return 0

	word_buff = []

	row = len(words)
	col = len(words[0])


	mode = 0
	if row > col: mode = 1
	elif row < col: mode = 2

	max_col_len = col - len(key) + 1
	max_row_len = row - len(key) + 1

	l_max = col
	if mode == 2:
		l_max = row

	for i in range(max_col_len):
		tmp_buff = [""] * 2
		for j in range(l_max):
			tmp_buff[0] = tmp_buff[0] + words[j][i+j]
			tmp_buff[1] = tmp_buff[1] + words[j][col-1-i-j]
		if mode == 2:
			if i >= abs(row-col):
				l_max = l_max - 1
		else:
			l_max = l_max - 1
		word_buff.append(tmp_buff[0])
		word_buff.append(tmp_buff[1])

	l_max = row
	if mode == 1:
		l_max = col

	for i in range(max_row_len):
		tmp_buff = [""] * 2
		for j in range(l_max):
			tmp_buff[0] = tmp_buff[0] + words[i+j][j]
			tmp_buff[1] = tmp_buff[1] + words[i+j][col-1-j]
		if i != 0:
			print(tmp_buff)
			word_buff.append(tmp_buff[0])
			word_buff.append(tmp_buff[1])
		if mode == 1:
			if i >= abs(row-col):
				l_max = l_max -1
		else:
			l_max = l_max - 1

	return find_word_horizontally(word_buff, key)

def search_word(words, key):
	return (
		find_word_horizontally(words, key) +
		find_word_vertically(words, key) +
		find_word_diagonally(words, key)
	)

words = []
count = []

T = int(input())

for _ in range(T):
	N = int(input())
	M = int(input())

	for _ in range(N):
		tmp = input()
		words.append(tmp)

	W = input()
	count.append(search_word(words, W))
	words.clear()

for i,j in enumerate(count):
	print(f"Case {i+1}: {j}")
