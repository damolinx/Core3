using System;
using System.Text;

namespace Core3.Interfaces
{
    public interface ICoreInput
    {
        ConsoleKeyInfo ReadKey(bool intercept = false);

        string ReadLine(bool trim = true);
    }
}
