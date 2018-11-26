using Core3.Interfaces;
using System;
using System.Text;

namespace Core3
{
    public class CoreConsole : ICoreInput, ICoreErrorOutput, ICoreOutput
    {
        public static readonly CoreConsole Instance = new CoreConsole();

        private readonly object _outputLock;

        private CoreConsole()
        {
            _outputLock = new object();
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

        (int left, int top) ICoreOutput.GetCursorPosition()
        {
            lock (_outputLock)
            {
                return (left: Console.CursorLeft, top: Console.CursorTop);
            }
        }

        ICoreOutput ICoreOutput.SetCursorPosition((int left, int top) position)
        {
            lock (_outputLock)
            {
                Console.SetCursorPosition(position.left, position.top);
                return this;
            }
        }

        ICoreOutput ICoreOutput.Write(string format, params object[] args)
        {
            lock (_outputLock)
            {
                Console.Write(format, args);
                return this;
            }
        }

        ICoreOutput ICoreOutput.Write((int left, int top) position, string format, params object[] args)
        {
            lock (_outputLock)
            {
                Console.SetCursorPosition(position.left, position.top);
                Console.Write(format, args);
                return this;
            }
        }

        ICoreOutput ICoreOutput.WriteLine()
        {
            return ((ICoreOutput)this).Write(Environment.NewLine);
        }

        ICoreOutput ICoreOutput.WriteLine(string format, params object[] args)
        {
            return ((ICoreOutput)this).Write(format + Environment.NewLine, args);
        }
    }
}
