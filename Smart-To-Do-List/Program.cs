using System.IO;

List<string> tasks = new List<string>();

while (true)
{

    Console.Clear();

    Console.WriteLine("[1] Add a new task.");
    Console.WriteLine("[2] Show current tasks.");
    Console.WriteLine("[3] Exit.");

    ConsoleKeyInfo keyPressedMenu = Console.ReadKey(true);


    while (keyPressedMenu.Key == ConsoleKey.NumPad1 || keyPressedMenu.Key == ConsoleKey.D1)
    {
        Console.Clear();
        Console.WriteLine("Please enter a task:\n");

        string addedTask = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrWhiteSpace(addedTask))
            continue;

        tasks.Add(addedTask);
        File.AppendAllText("tasksList.txt", addedTask + Environment.NewLine);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task added successfully\n");
        Console.ResetColor();

        Console.WriteLine("[1] Add another task.");
        Console.WriteLine("[2] Back to menu.");

        ConsoleKeyInfo keyPressed1;
        do
        {
            keyPressed1 = Console.ReadKey(true);
        } while (keyPressed1.Key != ConsoleKey.D1 &&
                 keyPressed1.Key != ConsoleKey.NumPad1 &&
                 keyPressed1.Key != ConsoleKey.D2 &&
                 keyPressed1.Key != ConsoleKey.NumPad2);

        if (keyPressed1.Key == ConsoleKey.D2 || keyPressed1.Key == ConsoleKey.NumPad2)
            break;
    }

    if (keyPressedMenu.Key == ConsoleKey.NumPad2 || keyPressedMenu.Key == ConsoleKey.D2)
    {
        tasks = File.ReadLines("tasksList.txt").ToList();

        Console.Clear();

        if (tasks.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no tasks to complete.");
            Console.ResetColor();

            Console.ReadKey();
            continue;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"({i+1}) {tasks[i]}");
        }

        Console.WriteLine();
        Console.WriteLine("[1] Complete a task.");
        Console.WriteLine("[2] Complete all tasks.");
        Console.WriteLine("[3] Back to menu.");
        Console.WriteLine("[4] Exit.");

        var keyPressed2 = Console.ReadKey(true);

        if (keyPressed2.Key == ConsoleKey.NumPad4 || keyPressed2.Key == ConsoleKey.D4)
            break;

        else if (keyPressed2.Key == ConsoleKey.NumPad3 || keyPressed2.Key == ConsoleKey.D3)
        {
            continue;
        }

        else if (keyPressed2.Key == ConsoleKey.NumPad2 || keyPressed2.Key == ConsoleKey.D2)
        {
            tasks.Clear();

            File.WriteAllLines("tasksList.txt", tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All tasks completed succesfully.");
            Console.ResetColor();

            Console.ReadKey();

            continue;
        }

        else if (keyPressed2.Key == ConsoleKey.NumPad1 || keyPressed2.Key == ConsoleKey.D1)
        {
            while (true)
            {
                Console.Clear();

                Console.Write("Please enter the number of the task you have completed: ");

                int completedTaskNum;
                bool done = int.TryParse(Console.ReadLine(), out completedTaskNum);

                if (done)
                {
                    if (completedTaskNum - 1 < tasks.Count && completedTaskNum > 0)
                    {
                        tasks.RemoveAt(completedTaskNum - 1);
                        File.WriteAllLines("tasksList.txt", tasks);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task completed successfully.");
                        Console.ResetColor();

                        Console.ReadKey();

                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number.");
                        Console.ResetColor();

                        Console.ReadKey();
                        continue;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number.");
                    Console.ResetColor();

                    Console.ReadKey();
                    continue;
                }
            }
        }
    }

    if (keyPressedMenu.Key == ConsoleKey.NumPad3 || keyPressedMenu.Key == ConsoleKey.D3)
    {
        Console.Clear();
        break;
    }
}