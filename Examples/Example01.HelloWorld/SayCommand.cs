using Core3.Commands;
using Core3.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example01.HelloWorld
{
    class SayCommand : CoreCommand
    {
        public SayCommand(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException("Cannot be empty", nameof(message));
            Message = message;
        }

        public string Message { get; }

        public override async Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            context.GetOutput().WriteLine(Message);
            await Task.Delay(1000, cancellationToken);
            return new CoreCommandResult { Complete = true };
        }
    }
}
