using Core3.Commands;
using Core3.Commands.Prompt;
using Core3.Commands.Prompt.Cmdlets;
using Prompt.Example01.Cmdline.Cmdlets;
using System;
using System.Collections.Generic;

namespace Prompt.Example01.Cmdline
{
    public class CmdPromptCommand : PromptCommand
    {
        public CmdPromptCommand()
        {
        }

        protected override PromptCmdletContext CreateCmdletContext(CoreCommandContext context)
        {
            var promptContext = new CmdPromptCmdletContext(context, this);
            return promptContext;
        }

        protected override IReadOnlyDictionary<string, PromptCmdlet> CreateCmdlets(PromptCmdletContext context)
        {
            var dictionary = new Dictionary<string, PromptCmdlet>(StringComparer.OrdinalIgnoreCase)
            {
                { "cat", new CatCmdlet() },
                { "cd", new ChangeDirectoryCmdlet() },
                { "dir", new DirectoryCmdlet() },
                { "exit",  new ExitCmdlet() },
                { "help",  new HelpCmdlet() },
            };

            return dictionary;
        }

        protected override string GetPromptText(PromptCmdletContext context)
        {
            return ((CmdPromptCmdletContext)context).CurrentDirectory + ">";
        }
    }

}