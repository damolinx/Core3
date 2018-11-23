using Core3;
using Core3.Extensions;

namespace Example02.MagicEightball
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreProgram = new CoreProgram()
                .PushCommand(new AskCommand());
            coreProgram.Execute(args);
        }
    }
}
