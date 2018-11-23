using System;
using System.Collections.Generic;
using System.Linq;

namespace Core3.Commands.Prompt.Parsers
{
    /// <summary>
    /// Parses input as a cmdlet name followed by an white-space separated arguments
    /// </summary>
    public sealed class ActionArgsPromptInputParser : PromptInputParser
    {
        protected override PromptInput Parse(PromptCmdletContext context, string input)
        {
            var tokens = Parse(input).ToArray();
            var promptInput = new PromptInput(input)
            {
                CmdletName = tokens.FirstOrDefault(),
                CmdletArguments = tokens.Skip(1).ToArray()
            };
            return promptInput;
        }

        private static IEnumerable<string> Parse(string input)
        {
            var start = 0;
            var end = 0;

            while (end < input.Length)
            {
                if (char.IsWhiteSpace(input[end]))
                {
                    yield return input.Substring(start, end - start);
                    start = end + 1;
                }
                end++;
            }

            yield return input.Substring(start);
        }
    }
}
