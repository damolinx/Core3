using System;
using System.Threading;

namespace Core3.Commands.Menu
{
    public class MenuEntry
    {
        private CoreCommand _command;

        public MenuEntry(ConsoleKey key, string text)
        {
            Key = (key != default) ? key : throw new ArgumentException($"Invalid key. Key:{key}", nameof(key));
            Text = !string.IsNullOrWhiteSpace(text) ? text : throw new ArgumentException("Cannot be empty", nameof(text));
        }

        public CoreCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public Func<CoreCommandContext, CoreCommand> CommandFactory { get; set; }

        public ConsoleKey Key { get; }

        public string Text { get; set; }

        public CoreCommand GetCommand(CoreCommandContext context)
        {
            return LazyInitializer.EnsureInitialized(ref _command, () => CommandFactory(context));
        }
    }
}
