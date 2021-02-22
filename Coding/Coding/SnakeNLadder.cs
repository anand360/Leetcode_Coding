using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding
{
    // Snakes and Ladders: The Quickest Way Up
    public class SnakeNLadder
    {
        public Dictionary<int, int> Snakedict { get; set; }

        public Dictionary<int, int> Ladderdict { get; set; }

        public SnakeNLadder()
        {
            Snakedict = new Dictionary<int, int>();
            Ladderdict = new Dictionary<int, int>();
        }

        public void GetInput()
        {
            var lCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < lCount; i++)
            {
                var lInputs = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray(); ;
                Ladderdict.Add(lInputs[0], lInputs[1]);
            }

            var sCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sCount; i++)
            {
                var sInputs = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray(); ;
                Snakedict.Add(sInputs[0], sInputs[1]);
            }
        }

        public int QuickWayUp()
        {
            var queue = new Queue<int>();
            var visited = new Dictionary<int, int>();

            queue.Enqueue(1);
            visited.Add(1, 0);
            while (queue.Count != 0)
            {
                var el = queue.Dequeue();
                if (el == 100)
                {
                    return visited[el];
                }

                for (int i = 1; i <= 6; i++)
                {
                    var next = el + i;
                    if (next > 100)
                        continue;

                    if (Snakedict.ContainsKey(next))
                    {
                        next = Snakedict[next];
                    } else if (Ladderdict.ContainsKey(next))
                    {
                        next = Ladderdict[next];
                    }

                    if (!visited.ContainsKey(next))
                    {
                        visited.Add(next, visited[el] + 1);
                        queue.Enqueue(next);
                    } 
                    else if(visited[el] + 1 < visited[next])
                    {
                        visited[next] = visited[el] + 1;
                    }
                }
            }

            return -1;
        }
    }
}
