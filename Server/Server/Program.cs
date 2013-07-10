// (C) 2013 - Dennis Ziolkowski
// Server : Program.cs

using System;

namespace Server {
    internal class Program {
        private static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            ServerBundle bundle = new ServerBundle();
            bundle.StartBundle();
        }
    }
}