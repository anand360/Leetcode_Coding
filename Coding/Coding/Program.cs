﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // var output = TargetSum(new int[] { 2, 5, 3, 7, 8 }, 8);
            //Compress("aabbbbccdaaaf");

            //var output = TwoSum(new int[] { 2, 5, 3, 7, 8 }, 8);

            // var output = CheckInclusion("ab", "eidbaooo");

            //var SnL = new SnakeNLadder();
            //SnL.GetInput();
            //Console.WriteLine(SnL.QuickWayUp());

            //var bowlingAlley = new BowlingAlleyGame();
            //bowlingAlley.AddPlayer(1, "Anand");
            //bowlingAlley.AddPlayer(2, "Rick");

            //bowlingAlley.Play();

            //var player = bowlingAlley.PlayersMoves;

            //_2DMatrixProblem.UpdateNearLoc(null);

            //PrintSortedSquareArray.Run(null);

            //FirstDuplicate.Run(new int[] { 2,1,2,1,3,3 });

            //RotationalCipher.Run("abcdefghijklmNOPQRSTUVWXYZ0123456789", 39);

            //ReversetoMakeEqual.Run(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4, 3, 2 });

            //PassingYearbooks.Run(new int[] { 2, 1 }, 2);

            //ContiguousSubarrays.Run(new int[] { 2, 4, 7, 1, 5, 3 });

            //MinimumLengthSubstrings.Run("bfbeadbcbcbfeaaeefcddcccbbbfaaafdbebedddf", "cbccfafebccdccebdd");

            // BalanceBrackets.Run("{(})");

            // ReverseOperations.Run(null);

            // EncryptedWords.Run("facebook");

            // var sd = new SerlDelBT();
            // var a = sd.Serialize(TreeNode.Init());
            // var d = sd.DeSerialize(a);

            // var a = MinimumJumps.Run(new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1});
            
            // int[,] g = { 
            //     { 0, 1, 0, 1 }, 
            //     { 1, 0, 1, 0 }, 
            //     { 0, 1, 0, 1 }, 
            //     { 1, 0, 1, 0 } 
            //     };

            // var a = IsBipartite.Run(g);
            // var b = IsBipartite.BFSRun(g);

            // var l = new List<Side>{
            //     new Side(2,2,3),
            //     new Side(3,2,2),
            //     new Side(2,5,6)
            // };
            // var a = CountingTriangles.Run(l);

            // int[,] g = { 
            //     { 0, 0, 0, 1 }, 
            //     { 0, 0, 1, 1 }, 
            //     { 0, 1, 1, 1 }, 
            //     { 0, 0, 1, 1 } 
            //     };

            // var a = LeftMostCol1.Run(g);

            // var arr = new ArrayList();
            // arr.Add(1);
            // arr.Add(new ArrayList{
            //     4,
            //     new ArrayList{
            //         6
            //     }
            // });

            // var a = NestedListWeightSum.Run(arr);

            // var a = new List<int[]>{
            //     new int[] {2,3},
            //     new int[] {1,2},
            //     new int[] {2,1},
            //     new int[] {2,3},
            //     new int[] {2,2}
            // };

            // var r = AnswerQuery.Run(a);

            // var a = new int[] {-100, -30, -10, -4, 0, 0, 0, 0, 30, 45};
            // var b = new int[] {-60, -50, -10, -1, 0, 0 , 5 };
            // var c = new int[] {-80, -20, -9, 4, 6};

            // var res = Merge3SortArray.run(a, b, c);

            // var a = LengthOfLongestSubstring.Run("pwwkew");

            // var n1 = new int[]{1,3};
            // var n2 = new int[]{2};
            // var a = FindMedianSortedArrays.Run(n1, n2);

            // var a = LongestPalindromicSubstring.Run("ccc");

            // var a = ReverseInt.Run(-1893999999);

            // var a = MyAtoi.Run("-91283472332");

            // var a = Divide.Run(-2147483648, -1);

            // var a = FirstMissingPositive.Run(new int[]  {3,4,-1,1});
            
            // var a = new int[][]{new int[]{1,3},new int[]{0,3}};
            // var res = MergeIntervals.Run(a);

            // var a = new MovingAverage(3);
            // double res = a.Next(3);
            // res = a.Next(3);
            // res = a.Next(4);
            // res = a.Next(7);
            // res = a.Next(1);
            // res = a.Next(9);

            // var a = IsAlienSorted.Run(new string[] {"word","world","row"}, "worldabcefghijkmnpqstuvxyz");

            // var a = DecodeString.Run("3[z]2[2[y]pq4[2[jk]e1[f]]]ef");

            // var a = MobileNumberPadComb.Run("23");

            // var a = LongestSubarrayLimitedDiff.Run(new int[] {8,2,4,7}, 4);
            // int[,] g = { 
            //     { 7, 8, 4, 2 }, 
            //     { 3, 9, 3, 3 }, 
            //     { 8, 1, 5, 1 }, 
            //     { 1, 2, 0, 3 } 
            //     };
            // var a = new MatrixDiagonalsDec(g);
            // var b = a.Run();

            var a  = new LinkedHashMap<string>();
            a.Enqueue(new QueueItem<string>(2, "Anand2"));
            a.Enqueue(new QueueItem<string>(3, "Anand3"));
            a.Enqueue(new QueueItem<string>(1, "Anand1"));
            a.Enqueue(new QueueItem<string>(4, "Anand4"));

            var p = a.Peek();
            System.Console.WriteLine($"{p.Id} | {p.Value}");

            var d = a.Dequeue();
            System.Console.WriteLine($"{d.Id} | {d.Value}");

            p = a.Peek();
            System.Console.WriteLine($"{p.Id} | {p.Value}");
            
            a.Enqueue(new QueueItem<string>(1, "Anand1New"));

            p = a.Peek();
            System.Console.WriteLine($"{p.Id} | {p.Value}");

            a.ForceEnqueue(new QueueItem<string>(1, "Anand1New"));

            p = a.Peek();
            System.Console.WriteLine($"{p.Id} | {p.Value}");

            d = a.Dequeue();
            System.Console.WriteLine($"{d.Id} | {d.Value}");

            d = a.Dequeue();
            System.Console.WriteLine($"{d.Id} | {d.Value}");

            d = a.Dequeue();
            System.Console.WriteLine($"{d.Id} | {d.Value}");
        }

        public static void Compress(string str)
        {
            int size = 0;
            char last = str[0];
            int lastIndex = 0;
            int count = 1;

            var strArr = str.ToCharArray();

            for (int i = 1; i < strArr.Length; i++)
            {
                if (last == strArr[i])
                {
                    count++;
                }
                else
                {
                    strArr[lastIndex++] = last;
                    if (count != 1)
                    {
                        strArr[lastIndex] = Convert.ToChar(count);
                        lastIndex++;
                    }
                    last = str[i];
                    count = 1;
                }
            }

            strArr[lastIndex++] = last;
            if (count != 1)
            {                
                strArr[lastIndex] = Convert.ToChar(count);
            }
        }

        public static List<List<int>> TargetSum(int[] arr, int target)
        {
            var output = new List<List<int>>();
            var table = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                table.Add(arr[i]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= target)
                {
                    var m = target % arr[i];
                    if (m >= 0)
                    {
                        var count = target / arr[i];
                        var o = new List<int>();
                        while (count > 0)
                        {
                            o.Add(arr[i]);
                            count--;
                        }

                        if (m != 0 && table.Contains(m))
                        {
                            o.Add(m);
                            output.Add(o);
                        }
                        else if (m == 0)
                        {
                            output.Add(o);
                        }
                    }
                }
            }

            return output;
        }    

        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            var output = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var sub = target - nums[i];
                if (map.ContainsKey(sub))
                {
                    output.Add((int) map[sub]);
                    output.Add(i);
                }
                else
                {
                    if(!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
                }
            }

            return output.ToArray<int>();
        }

        private static int numberOfWays(int[] arr, int k)
        {
            // Write your code here

            var map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], 1);
                }
                else
                {
                    map[arr[i]] += 1;
                }
            }

            int twice_count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var sub = k - arr[i];
                if (map.ContainsKey(sub))
                {
                    twice_count += map[sub];
                    if (sub == arr[i])
                        twice_count--;
                }
            }

            return twice_count / 2;
        }

        //Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. 
        // In other words, one of the first string's permutations is the substring of the second string.
        public static bool CheckInclusion(string s1, string s2)
        {
            if(s1.Length > s2.Length)
            {
                return false;
            }

            var s1Map = new int[26];
            var s2Map = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                s1Map[s1[i] - 'a']++;
                s2Map[s2[i] - 'a']++;
            }

            for (int i = s1.Length; i < s2.Length; i++)
            {
                if(Compare(s1Map, s2Map))
                {
                    Console.WriteLine($"found at {i-s1.Length}");
                }

                s2Map[s2[i] - 'a']++;

                s2Map[s2[i-s1.Length] - 'a']--;
            }

            return true;
        }

        private static bool Compare(int[] s1Map, int[] s2Map)
        {
            for (int i = 0; i < 26; i++)
            {
                if (s1Map[i] != s2Map[i])
                    return false;
            }

            return true;
        }
    }
}