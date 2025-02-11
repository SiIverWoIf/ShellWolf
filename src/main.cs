#pragma warning disable CS8600
#pragma warning disable CS8602
using System.Net;
using System.Net.Sockets;

while(true)
{
    Console.Write("$ ");
    string userInput = Console.ReadLine();
    if (userInput.StartsWith("exit"))
    {
        string[] h = userInput.Split();
        int exitStatus = Convert.ToInt32(h[1]);
        return exitStatus;
    }
    else
    {
        Console.WriteLine($"{userInput}: command not found");   
    }
}

