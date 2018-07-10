using System;

namespace BigramConsoleApplication {
    internal class CommandLineOptions {
        public CommandLineOptions(string[] args) {
            if (args.Length < 1) return;
            IsValid = true;
            Filepath = args[0];
        }

        public bool IsValid { get; }
        public string Filepath { get; }

        public void DisplayUsage() {
            Console.WriteLine("The syntax of the command is incorrect");
            Console.WriteLine();
            Console.WriteLine("usage: bigram <filename>");
            Console.WriteLine();
        }
    }
}