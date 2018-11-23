using Core3.Extensions;
using Core3.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core3.Commands.Menu
{
    public class MenuCommand : CoreCommand
    {
        private string _title;

        public MenuCommand(string title, string backLabel = null, params MenuEntry[] menuEntries)
        {
            Title = title;
            MenuEntries = new List<MenuEntry>(menuEntries)
            {
                new MenuEntry(ConsoleKey.D0, backLabel ?? Resources.MenuBack)
                {
                    Command = new BackCommand(this)
                }
            };
        }

        public bool Complete { get; internal set; }

        public IList<MenuEntry> MenuEntries { get; }

        public string Title
        {
            get { return _title; }
            set { _title = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        public override Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            if (!this.Complete)
            {
                var menuEntries = GetMenuEntries(context);

                RenderHeader(context);
                RenderMenu(context, menuEntries);

                var entryCommand = WaitForEntry(context, menuEntries)
                    .GetCommand(context);

                context.GetProgram().PushCommand(entryCommand);
            }

            return Task.FromResult(new CoreCommandResult { Complete = Complete });
        }

        protected virtual void RenderHeader(CoreCommandContext context)
        {
            context.GetOutput()
                .WriteLine(Title)
                .WriteLine(new string('-', Title.Length))
                .WriteLine();
        }

        protected virtual void RenderMenu(CoreCommandContext context, IReadOnlyList<MenuEntry> menuEntries)
        {
            var output = context.GetOutput();
            foreach (var menuEntry in menuEntries.OrderBy(m => m.Key))
            {
                var key = (menuEntry.Key >= ConsoleKey.D0 && menuEntry.Key <= ConsoleKey.D9)
                    ? (menuEntry.Key - ConsoleKey.D0).ToString()
                    : menuEntry.Key.ToString();
                output.WriteLine(" {0}. {1}", key, menuEntry.Text);
            }
            output.WriteLine();
        }

        protected virtual IReadOnlyList<MenuEntry> GetMenuEntries(CoreCommandContext context)
        {
            return new ReadOnlyCollection<MenuEntry>(MenuEntries);
        }

        private static MenuEntry WaitForEntry(CoreCommandContext context, IEnumerable<MenuEntry> entries)
        {
            var entry = (MenuEntry)null;
            var input = context.GetInput();
            do
            {
                var keyInfo = input.ReadKey(intercept: true);
                entry = entries.FirstOrDefault(e => e.Key == keyInfo.Key);
            }
            while (entry == default);
            return entry;
        }
    }
}
