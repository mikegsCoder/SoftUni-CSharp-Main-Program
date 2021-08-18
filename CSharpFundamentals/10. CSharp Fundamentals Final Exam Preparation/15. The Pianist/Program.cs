using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentPiece = pieceInfo[0];
                string currentcomposer = pieceInfo[1];
                string currentKey = pieceInfo[2];

                if (!pieces.ContainsKey(currentPiece))
                {
                    pieces.Add(currentPiece, new List<string> { currentcomposer, currentKey });
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] currentCommand = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string piece = currentCommand[1];

                switch (currentCommand[0])
                {
                    case "Add":
                        string composer = currentCommand[2];
                        string key = currentCommand[3];

                        if (!pieces.ContainsKey(piece))
                        {
                            pieces.Add(piece, new List<string> { composer, key });
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (!pieces.ContainsKey(piece))
                        {                            
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        else
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = currentCommand[2];

                        if (!pieces.ContainsKey(piece))
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        else
                        {
                            pieces[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        break;
                }
            }

            foreach (var piece in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
