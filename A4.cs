// Anwer for Question 4 (C#)
// By Arson Marianus

using System;
using static System.Math;
using System.IO;
using System.Collections.Generic;

namespace Q4 {
	class Q4Class {
		public static void Main() {
			Console.WriteLine("Enter Filename Path (Ex. ./input.in)");
			string filename = Console.ReadLine();
			string[] data = File.ReadAllLines(filename);
			List<string> words = new List<string>();
			List<int> count = new List<int>();

			int T = Convert.ToInt32(data[0]);
			int inx = 0;
			while(T > 0) {
				int N = Convert.ToInt32(data[++inx]);
				int M = Convert.ToInt32(data[++inx]);
				
				for(int i = 0; i < N; ++i) {
					words.Add(data[++inx]);
				}
				string W = data[++inx];
				if((1<=T&&T<=100) && (1<=N&&N<=100) && (1<=M&&M<=100) && (1<=W.Length&&W.Length<=100))
					count.Add(SearchWord(words, W));
				words.Clear();
				--T;
			}
			int c_inc = 0;
			foreach(int c in count) {
				++c_inc;
				Console.WriteLine("Case " + c_inc + ": " + c);
			}
		}
		public static int FindWordHorizontally(List<string> words, string key) {
			int count = 0;
			int inx;

			foreach(string word in words) {
				inx = 0;
				while((inx+key.Length) < word.Length+1) {
					if(word.Substring(inx, key.Length) == key) {
						++count;
					}
					++inx;
				}
				inx = 0;
				string r_word = Reverse(word);
				while((inx+key.Length) < word.Length+1) {
					if(r_word.Substring(inx, key.Length) == key) {
						++count;
					}
					++inx;
				}
				
			}
			return count;
		}
		public static int FindWordVertically(List<string> words, string key)  {
			List<string> word_buff = new List<string>();
			for(int i = 0; i < words[0].Length; ++i) {
				string tmp = "";
				for(int j = 0; j < words.Count; ++j) {
					tmp+=words[j][i];
				}
				word_buff.Add(tmp);
			}
			return FindWordHorizontally(word_buff, key);
		}
		public static int FindWordDiagonally(List<string> words, string key) {
			List<string> word_buff = new List<string>();
			
			int row = words.Count;
			int col = words[0].Length;
			
			int mode = 0;

			if(row > col)
				mode = 1;
			else if(row < col)
				mode = 2;
		
			int max_col_len = col - key.Length + 1;
			int max_row_len = row - key.Length + 1;

			int l_max = col;
			if(mode == 2)
				l_max = row;

			for(int i = 0; i < max_col_len; ++i) {
				string tmp_buff1 = "";
				string tmp_buff2 = "";
				for(int j = 0; j < l_max; ++j) {
					tmp_buff1 += words[j][i+j];
					tmp_buff2 += words[j][col-1-i-j];
				}
				if(mode == 2) {
					if(i >= Abs(row-col))
						--l_max;
				}
				else
					--l_max;
				word_buff.Add(tmp_buff1);
				word_buff.Add(tmp_buff2);
				
			}

			l_max = row;
			if(mode == 1) l_max = col;

			for(int i = 0; i < max_row_len; ++i) {
				string tmp_buff1 = "";
				string tmp_buff2 = "";
				for(int j = 0; j < l_max; ++j) {
					tmp_buff1 += words[i+j][j];
					tmp_buff2 += words[i+j][col-1-j];
				}
				if(i != 0) {
					word_buff.Add(tmp_buff1);
					word_buff.Add(tmp_buff2);
				}
				if(mode == 1) {
					if(i >= Abs(row-col))
						--l_max;
				}
				else
					--l_max;
			}
			
			return FindWordHorizontally(word_buff, key);

		}
		public static int SearchWord(List<string> words, string key) {
			return (
				FindWordHorizontally(words, key) +
				FindWordVertically(words, key) +
				FindWordDiagonally(words, key)
			);
		}
		public static string Reverse( string s ) {
			char[] c = s.ToCharArray();
			Array.Reverse(c);
			return new string(c);
		}
	}
}
