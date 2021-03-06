﻿using Core3;
using Core3.Extensions;

namespace Example01.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            new CoreProgram()
                .PushCommand(new SayCommand("Hello there!"))
                .PushCommand(new SayCommand("Hello world!"))
                .Execute(args);
        }
    }
}
