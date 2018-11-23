using System.Threading;
using System.Threading.Tasks;

namespace Core3.Commands.Menu
{
    public class BackCommand : CoreCommand
    {
        public static CoreCommand Instance { get; } = new BackCommand();

        private BackCommand()
        {
        }

        public override Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CoreCommandResult { Complete = true });
        }
    }
}
