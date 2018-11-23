using Core3.Commands;
using Core3.Commands.Menu;
using Core3.Extensions;
using System;

namespace Menu.Example01.DriveInfo
{
    public class DriveMenuCommand : MenuCommand
    {
        public DriveMenuCommand(string title, System.IO.DriveInfo drive)
            : base(title)
        {
            Drive = drive ?? throw new ArgumentNullException(nameof(drive));
            RequiresClearScreen = true;
        }

        public System.IO.DriveInfo Drive { get; }

        protected override void RenderHeader(CoreCommandContext context)
        {
            base.RenderHeader(context);
            context.GetOutput()
                .WriteLine("  Type:           {0}", Drive.DriveType)
                .WriteLine("  Format:         {0}", Drive.IsReady ? Drive.DriveFormat : string.Empty)
                .WriteLine("  User-available: {0} bytes", Drive.IsReady ? Drive.AvailableFreeSpace.ToString() : "--")
                .WriteLine("  Free space:     {0} bytes", Drive.IsReady ? Drive.TotalFreeSpace.ToString() : "--")
                .WriteLine("  Capacity:       {0} bytes", Drive.IsReady ? Drive.TotalSize.ToString() : "--")
                .WriteLine();
        }
    }
}