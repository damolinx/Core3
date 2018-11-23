using Core3.Commands;
using Core3.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example02.MagicEightball
{
    class AskCommand : CoreCommand
    {
        private AnswerCommand _answerCommand;

        public override Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            var output = context.GetOutput()
                .WriteLine("Ask me anything and press ENTER (leave empty to exit):")
                .Write(">> ");

            var question = context.GetInput().ReadLine();

            var complete = false;
            if (string.IsNullOrEmpty(question))
            {
                complete = true;
            }
            else if (!question.EndsWith("?", StringComparison.Ordinal) || question.TrimEnd('?').Length == 0)
            {
                output
                    .WriteLine("Is that a question?")
                    .WriteLine();
            }
            else
            {
                context.GetProgram().CommandStack.Push(LazyInitializer.EnsureInitialized(ref _answerCommand));
            }

            return Task.FromResult(new CoreCommandResult { Complete = complete });
        }
    }
}
