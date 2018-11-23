using System.Threading.Tasks;

namespace Core3.Commands.Prompt
{
    public abstract class PromptCmdlet
    {
        protected PromptCmdlet()
        {
        }

        public abstract Task<PromptCmdletResult> ExecuteAsync(PromptCmdletContext context, params string[] args);
    }
}
