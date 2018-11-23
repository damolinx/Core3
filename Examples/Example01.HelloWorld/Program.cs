using Core3;
using Core3.Extensions;

namespace Example01.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreProgram = new CoreProgram()
                .AddCommand(new SayCommand("Hello there!"))
                .AddCommand(new SayCommand("Hello world!"));
            coreProgram.Execute(args);
        }
    }
}
