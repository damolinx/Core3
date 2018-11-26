using Core3.Commands;
using Core3.Extensions;
using Core3.Utilities.TextControls;
using System.Threading;
using System.Threading.Tasks;

namespace Example03.TextControls
{
    class ProgressCommand : CoreCommand
    {
        public ProgressCommand()
        {
            RequiresClearScreen = true;
            RequiresCursor = false;
            RequiresExitPause = true;
        }

        public override async Task<CoreCommandResult> ExecuteAsync(CoreCommandContext context, CancellationToken cancellationToken)
        {
            var progressBar1 = new CoreProgressBar(width: 40)
            {
                Maximum = 100,
                Minimum = 0,
                Value = 0,
                ShowPercentage = true,
            };

            var progressBar2 = new CoreProgressBar(width: 40)
            {
                Maximum = 100,
                Minimum = 0,
                Value = 100,
            };

            var spinner = new CoreSpinner();

            var output = context.GetOutput()
                .WriteLine("Progress bar (up):")
                .InsertControl(progressBar1)
                .WriteLine()
                .WriteLine()
                .WriteLine("Progress bar (down):")
                .InsertControl(progressBar2)
                .WriteLine()
                .WriteLine()
                .Write("Spinner: ")
                .InsertControl(spinner)
                .WriteLine()
                .WriteLine();

            //var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            //spinner.StartAsync(output, TimeSpan.FromMilliseconds(100), cts.Token);

            do
            {
                progressBar1.Render(output);
                progressBar1.Value += 10;

                progressBar2.Render(output);
                progressBar2.Value -= 10;

                spinner.Render(output);

                await Task.Delay(250);
            }
            while (progressBar1.Value <= progressBar1.Maximum || progressBar2.Value >= progressBar2.Minimum);
            spinner.Clean(output);

            return new CoreCommandResult { Complete = true };
        }
    }
}