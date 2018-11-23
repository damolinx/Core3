using Core3.Commands.Attributes;
using System.Threading.Tasks;

namespace Core3.Commands.Prompt.Cmdlets
{
    [CommandDescription("Exits interactive prompt")]
    public class ExitCmdlet : PromptCmdlet
    {
        public override Task<PromptCmdletResult> ExecuteAsync(PromptCmdletContext context, params string[] args)
        {
            context.Exit = true;
            return Task.FromResult(PromptCmdletResult.Empty);
        }
    }
}
