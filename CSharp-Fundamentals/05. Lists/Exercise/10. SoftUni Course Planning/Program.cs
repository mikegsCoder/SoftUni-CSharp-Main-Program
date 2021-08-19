using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] commandLine = input.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = commandLine[0];

                switch (command)
                {
                    case "Add":
                        string lessonTitleToAdd = commandLine[1];

                        if (!lessons.Contains(lessonTitleToAdd))
                        {
                            lessons.Add(lessonTitleToAdd);
                        }
                        break;
                    case "Insert":
                        string lessonTitleToInsert = commandLine[1];

                        if (!lessons.Contains(lessonTitleToInsert))
                        {
                            int index = int.Parse(commandLine[2]);
                            lessons.Insert(index, lessonTitleToInsert);
                        }
                        break;
                    case "Remove":
                        string lessonTitleToRemove = commandLine[1];

                        if (lessons.Contains(lessonTitleToRemove))
                        {
                            lessons.Remove(lessonTitleToRemove);
                        }
                        break;
                    case "Swap":
                        string lessonTitleToSwap1 = commandLine[1];
                        string lessonTitleToSwap2 = commandLine[2];

                        int index1 = lessons.IndexOf(lessonTitleToSwap1);
                        int index2 = lessons.IndexOf(lessonTitleToSwap2);

                        if (lessons.Contains(lessonTitleToSwap1) && lessons.Contains(lessonTitleToSwap2))
                        {
                            string temp = lessons.ElementAt(index1);
                            lessons[index1] = lessons[index2];
                            lessons[index2] = temp;

                            if (lessons.Contains(lessonTitleToSwap1 + "-Exercise") && lessons.Contains(lessons[index1]))
                            {
                                index1 = lessons.IndexOf(lessonTitleToSwap1);
                                lessons.Remove(lessonTitleToSwap1 + "-Exercise");
                                lessons.Insert(index1 + 1, lessonTitleToSwap1 + "-Exercise");
                            }
                            else if (lessons.Contains(lessonTitleToSwap2 + "-Exercise") && lessons.Contains(lessons[index2]))
                            {
                                index2 = lessons.IndexOf(lessonTitleToSwap2);
                                lessons.Remove(lessonTitleToSwap2 + "-Exercise");
                                lessons.Insert(index2 + 1, lessonTitleToSwap2 + "-Exercise");
                            }

                        }
                        break;
                    case "Exercise":
                        string lessonTitleWithExcercise = commandLine[1];

                        if (lessons.Contains(lessonTitleWithExcercise) && !lessons.Contains(lessonTitleWithExcercise + "-Exercise"))
                        {
                            int index3 = lessons.IndexOf(lessonTitleWithExcercise);
                            lessons.Insert(index3 + 1, lessonTitleWithExcercise + "-Exercise");
                        }
                        else if (!lessons.Contains(lessonTitleWithExcercise))
                        {
                            lessons.Add(lessonTitleWithExcercise);
                            lessons.Add(lessonTitleWithExcercise + "-Exercise");
                        }
                        break;
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
