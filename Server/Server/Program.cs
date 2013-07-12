// (C) 2013 - Dennis Ziolkowski
// Server : Program.cs

using System;

namespace Server {
    internal class Program {
        public static ServerBundle Bundle {
            get; set; }
        private static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.White;
            Bundle = new ServerBundle();
            Bundle.StartBundle();
        }
    }
}