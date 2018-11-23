using Core3.Commands.Attributes;
using Core3.Commands.Prompt;
using Core3.Utilities;
using System.Threading.Tasks;

namespace Prompt.Example01.Cmdline.Cmdlets
{
    [CommandArgument(LongOptionName = "chdir", ShortOptionName = "cd")]
    [CommandDescription("Change current directory")]
    public class ChangeDirectoryCmdlet : PromptCmdlet
    {
        public override Task<PromptCmdletResult> ExecuteAsync(PromptCmdletContext context, params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    context.Output.WriteLine(((CmdPromptCmdletContext)context).CurrentDirectory);
                    break;

                case 1:
                    ((CmdPromptCmdletContext)context).CurrentDirectory = PathUtilities.GetFullPath(args[0], true);
                    break;

                default:
                    context.Error.WriteLine("Too Many Arguments");
                    break;
            }

            return Task.FromResult(PromptCmdletResult.Empty);
        }
    }
}
