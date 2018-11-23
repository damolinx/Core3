using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core3.Commands.Menu
{
    public class BackCommand : CoreCommand
    {
        public BackCommand(MenuCommand menu)
        {
            Menu = menu ?? throw new ArgumentNullException(nameof(menu));
        }

        public MenuCommand Menu { get; }

        public override Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            Menu.Complete = true;
            return Task.FromResult(new CoreCommandResult { Complete = true });
        }
    }
}
