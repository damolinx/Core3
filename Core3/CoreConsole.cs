using Core3.Interfaces;
using System;
using System.Text;

namespace Core3
{
    public class CoreConsole : ICoreInput, ICoreErrorOutput, ICoreOutput
    {
        public static CoreConsole Instance { get; } = new CoreConsole();

        private CoreConsole()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
        }

        ConsoleKeyInfo ICoreInput.ReadKey(bool intercept = false)
        {
            return Console.ReadKey(intercept);
        }

        string ICoreInput.ReadLine(bool trim = true)
        {
            var input = Console.ReadLine();
            return (input != null)
                ? (trim ? input.Trim() : input)
                : string.Empty;
        }

        ICoreErrorOutput ICoreErrorOutput.Write(string format, params object[] args)
        {
            Console.Error.Write(format, args);
            return this;
        }

        ICoreErrorOutput ICoreErrorOutput.WriteLine()
        {
            Console.Error.WriteLine();
            return this;
        }

        ICoreErrorOutput ICoreErrorOutput.WriteLine(string format, params object[] args)
        {
            Console.Error.WriteLine(format, args);
            return this;
        }

        ICoreOutput ICoreOutput.Write(string format, params object[] args)
        {
            Console.Write(format, args);
            return this;
        }

        ICoreOutput ICoreOutput.WriteLine()
        {
            Console.WriteLine();
            return this;
        }

        ICoreOutput ICoreOutput.WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            return this;
        }
    }
}
