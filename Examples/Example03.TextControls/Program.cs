using Core3;
using Core3.Extensions;
using System;

namespace Example03.TextControls
{
    class Program
    {
        static void Main(string[] args)
        {
            new CoreProgram()
                .PushCommand(new ControlsCommand())
                .Execute(args);
        }
    }
}
