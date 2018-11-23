using Core3.Commands.Attributes;
using Core3.Commands.Prompt;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Prompt.Example01.Cmdline.Cmdlets
{
    [CommandArgument(LongOptionName = "cat")]
    [CommandDescription("Display file contents")]
    public class CatCmdlet : PromptCmdlet
    {
        public override async Task<PromptCmdletResult> ExecuteAsync(PromptCmdletContext context, params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    context.Output.WriteLine("Missing File Name");
                    break;

                default:
                    foreach (var arg in args)
                    {
                        try
                        {
                            await ProcessFileAsync(arg)
                                .ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            context.Error.WriteLine(ex.Message);
                        }
                    }
                    break;
            }

            return PromptCmdletResult.Empty;
        }

        private async Task ProcessFileAsync(string arg)
        {
            using (var fs = File.OpenRead(arg))
            {
                await fs.CopyToAsync(Console.OpenStandardOutput())
                    .ConfigureAwait(false);
            }
        }
    }
}
