#pragma warning disable CS8600
#pragma warning disable CS8602
using System.Net;
using System.Net.Sockets;

while(true)
{
    Console.Write("$ ");
    string userInput = Console.ReadLine();
    if (userInput.StartsWith("exit "))
    {
        string[] h = userInput.Split();
        int exitStatus = Convert.ToInt32(h[1]);
        return exitStatus;
    }
    if (userInput.StartsWith("echo "))
    {
        string[] h = userInput.Split();
        for (int i = 1; i < h.Length; i++)
        {
            Console.Write(h[i] + " ");
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"{userInput}: command not found");   
    }
}

