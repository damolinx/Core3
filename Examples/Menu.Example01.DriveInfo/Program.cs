using Core3;
using Core3.Extensions;

namespace Menu.Example01.DriveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            new CoreProgram()
                .PushCommand(new DrivesMenuCommand())
                .Execute(args);
        }
    }
}
