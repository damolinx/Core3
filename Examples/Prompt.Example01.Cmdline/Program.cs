using Core3;
using Core3.Extensions;
using System;

namespace Prompt.Example01.Cmdline
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new CoreProgram()
                .PushCommand(new CmdPromptCommand());
            program.Execute(args);
        }
    }
}
