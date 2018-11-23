using Core3;
using Core3.Extensions;

namespace Prompt.Example01.Cmdline
{
    class Program
    {
        static void Main(string[] args)
        {
            new CoreProgram()
                .PushCommand(new CmdPromptCommand())
                .Execute(args);
        }
    }
}
