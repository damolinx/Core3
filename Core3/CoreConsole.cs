using Core3.Interfaces;
using System;
using System.Text;

namespace Core3
{
    public class CoreConsole : ICoreInput, ICoreOutput
    {
        public static CoreConsole Instance { get; } = new CoreConsole();

        private CoreConsole()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
        }

        public ConsoleKeyInfo ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }

        public string ReadLine(bool trim = true)
        {
            var input = Console.ReadLine();
            return (input != null)
                ? (trim ? input.Trim() : input)
                : string.Empty;
        }

        public ICoreOutput Write(string format, params object[] args)
        {
            Console.Write(format, args);
            return this;
        }

        public ICoreOutput WriteLine()
        {
            Console.WriteLine();
            return this;
        }

        public ICoreOutput WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            return this;
        }
    }
}
