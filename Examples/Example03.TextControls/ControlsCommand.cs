using Core3.Commands.Menu;
using System;

namespace Example03.TextControls
{
    class ControlsCommand : MenuCommand
    {
        public ControlsCommand()
            : base("Text Controls")
        {
            RequiresClearScreen = true;
            MenuEntries.Add(new MenuEntry(ConsoleKey.D1, "Progress controls")
            {
                Command = new ProgressCommand()
            });
        }
    }
}