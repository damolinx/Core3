using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core3.Commands
{
    public abstract class CoreCommand
    {
        public bool RequiresCursor { get; set; }

        public bool RequiresClearScreen { get; set; }

        public abstract Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken);

        public virtual CoreCommandHandledExceptionResult HandleException(Exception ex)
        {
            return new CoreCommandHandledExceptionResult { ExceptionHandled = false };
        }
    }
}
