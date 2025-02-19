#pragma warning disable CS8600
#pragma warning disable CS8602

using System.Globalization;
using System.Net;
using System.Net.Sockets;

while(true)
{
    string[] builtinCommands = ["exit", "echo", "type"];

    Console.Write("$ ");
    string userInput = Console.ReadLine();

    if (userInput.StartsWith("exit "))
    {
        string[] h = userInput.Split();
        int exitStatus = Convert.ToInt32(h[1]);
        return exitStatus;
    }
    else if (userInput.StartsWith("echo "))
    {
        string[] h = userInput.Split();
        for (int i = 1; i < h.Length; i++)
        {
            Console.Write(h[i] + " ");
        }
        Console.WriteLine();
    }
    else if (userInput.StartsWith("type "))
    {
        bool isBuiltin = false;
        string[] h = userInput.Split();
        for (int i = 0; i < builtinCommands.Length; i++)
        {
            if (h[1] == builtinCommands[i])
            {
                isBuiltin = true;
                break;
            }
        }
        if (isBuiltin)
            Console.WriteLine($"{h[1]} is a shell builtin");
        else if (OperatingSystem.IsWindows())
        {
            string[] path = Environment.GetEnvironmentVariable("path").Split(';');
            for (int i = 0; i < path.Length; i++)
            {
                if (File.Exists($"{i}\\{h[1]}.*"))
                {
                    Console.WriteLine($"{h[1]} is {i}\\{h[1]}");
                    break;
                }
            }
        }
        else if (OperatingSystem.IsLinux())
        {
            string[] path = Environment.GetEnvironmentVariable("PATH").Split(':');
            for (int i = 0; i < path.Length; i++)
            {
                if (File.Exists($"{i}/{h[1]}"))
                {
                    Console.WriteLine($"{h[1]} is {i}/{h[1]}");
                    break;
                }
            }
        }
        else 
            Console.WriteLine($"{h[1]}: not found");
    }
    else
    {
        Console.WriteLine($"{userInput}: command not found");   
    }
}

