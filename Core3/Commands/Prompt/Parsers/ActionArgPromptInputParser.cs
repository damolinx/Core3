using Core3.Extensions;
using System;

namespace Core3.Commands.Prompt.Parsers
{
    /// <summary>
    /// Parses input as a cmdlet name followed by an optional expression
    /// </summary>
    public sealed class ActionArgPromptInputParser : PromptInputParser
    {
        protected override PromptInput Parse(PromptCmdletContext context, string input)
        {
            var promptInput = new PromptInput(input);
            var breakIndex = input.IndexOf(char.IsWhiteSpace);

            if (breakIndex > -1)
            {
                promptInput.CmdletName = input.Substring(0, breakIndex);
                promptInput.CmdletArguments = new[] { input.Substring(breakIndex + 1).TrimStart() };
            }
            else
            {
                promptInput.CmdletName = input;
            }

            return promptInput;
        }
    }
}
