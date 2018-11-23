using Core3;
using Core3.Extensions;

namespace Menu.Example01.DriveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreProgram = new CoreProgram()
                .PushCommand(new DrivesMenuCommand());
            coreProgram.Execute(args);
        }
    }
}
