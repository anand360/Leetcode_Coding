using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Coding
{
    // need to check logic
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Moves Moves { get; set; }

        public Player(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Moves = new Moves();
        }
    }

    public class Moves
    {
        public string Movestring { get; set; }

        public int Score { get; set; }

        public int CurrentSet { get; set; }

        public Moves()
        {
            this.Movestring = string.Empty;
        }
    }

    public class BowlingAlleyGame
    {
        public Dictionary<int, Player> PlayersMoves { get; set; }

        public Queue<int> PlayerQueue { get; set; }

        public BowlingAlleyGame()
        {
            this.PlayersMoves = new Dictionary<int, Player>();
            this.PlayerQueue = new Queue<int>();
        }

        public void AddPlayer(int id, string name)
        {
            if (!PlayersMoves.ContainsKey(id))
            {
                PlayersMoves.Add(id, new Player(id, name));
                PlayerQueue.Enqueue(id);
            }
        }

        public void Play()
        {
            while(PlayerQueue.Count >= 0)
            {
                var playerId = PlayerQueue.Peek();
                if (PlayersMoves.ContainsKey(playerId))
                {
                    var player = PlayersMoves[playerId];
                    player.Moves.CurrentSet++;
                }

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"{playerId} Move. enter move: ");
                    var move = Convert.ToChar(Console.ReadLine());

                    if (i == 0 && char.IsDigit(move))
                    {
                        UpdateMove(playerId, move);
                    }
                    else if (i == 0 && !char.IsDigit(move))
                    {
                        Move(playerId, move);
                    }
                    else if (i == 1 && char.IsDigit(move))
                    {
                        Move(playerId, move);
                    }
                    else if (i == 1 && !char.IsDigit(move))
                    {
                        UpdateMove(playerId, move);
                    }
                }

                if (PlayersMoves.ContainsKey(playerId))
                {
                    var player = PlayersMoves[playerId];
                    if (player.Moves.CurrentSet == 2)
                    {
                        PlayerQueue.Dequeue();
                    }
                    else
                    {
                        PlayerQueue.Enqueue(PlayerQueue.Dequeue());
                    }
                }
            }
        }

        private void UpdateMove(int id, char move)
        {
            if (PlayersMoves.ContainsKey(id))
            {
                var player = PlayersMoves[id];
                player.Moves.Movestring += move;
            }
        }

        private void Move(int id, char move)
        {
            if (PlayersMoves.ContainsKey(id))
            {
                var player = PlayersMoves[id];
                player.Moves.Score = BowlingAllyCalc.GetScore(player.Moves.Movestring, move, player.Moves.Score);

                player.Moves.Movestring += move;
            }
        }
    }

    public class BowlingAllyCalc
    {
        public static int GetScore(string allMoves, char currentMove, int score)
        {
            var allMovesArr = allMoves.ToCharArray();
            int allMoveLen = allMovesArr.Length;

            if(!char.IsWhiteSpace(currentMove))
            {
                if (char.IsDigit(currentMove))
                {
                    if(allMoveLen - 1 >= 0 && allMovesArr[allMoveLen - 1] == '/')
                    {
                        score += 10 + Convert.ToInt32(currentMove);
                    }
                    else if (allMoveLen - 2 >= 0 && allMovesArr[allMoveLen - 2] == 'X')
                    {
                        if (allMovesArr[allMoveLen - 1] == 'X')
                        {
                            score += 20 + (currentMove - '0');
                        }
                        else
                        {
                            score += 10 + 2 * (Convert.ToInt32(allMovesArr[allMoveLen - 1]) + (currentMove - '0'));
                        }
                    }
                    else
                    {
                        if (allMoveLen - 1 >= 0 && char.IsDigit(allMovesArr[allMoveLen - 1]))
                        {
                            score += (allMovesArr[allMoveLen - 1] - '0') + (currentMove - '0');
                        }
                    }
                }
                else if(currentMove == 'X')
                {
                    if (allMoveLen - 2 >= 0 && allMovesArr[allMoveLen - 2] == 'X')
                    {
                        score += 30;
                    }
                }
                else if (currentMove == '/')
                {
                    if (allMoveLen - 2 >= 0 && allMovesArr[allMoveLen - 2] == 'X')
                    {
                        score += 20;
                    }
                }
            }

            return score;
        }
    }
}
