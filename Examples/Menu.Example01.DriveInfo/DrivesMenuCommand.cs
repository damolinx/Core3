using Core3.Commands;
using Core3.Commands.Menu;
using System;
using System.Collections.Generic;

namespace Menu.Example01.DriveInfo
{
    public class DrivesMenuCommand : MenuCommand
    {
        public DrivesMenuCommand(string backLabel = "Exit")
            : base("Disk Drives", backLabel)
        {
            RequiresClearScreen = true;
        }

        protected override IReadOnlyList<MenuEntry> GetMenuEntries(CoreCommandContext context)
        {
            var menuEntries = new List<MenuEntry>(base.GetMenuEntries(context));
            var baseKey = ConsoleKey.D1;

            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                var text = (drive.IsReady && !string.IsNullOrWhiteSpace(drive.VolumeLabel)) ? drive.VolumeLabel : drive.DriveType.ToString();
                var title = $"{text} ({drive.Name})";
                var menuEntry = new MenuEntry(baseKey++, title)
                {
                    CommandFactory = (ctx) => new DriveMenuCommand(title, drive)
                };
                menuEntries.Add(menuEntry);
            }

            return menuEntries;
        }
    }
}