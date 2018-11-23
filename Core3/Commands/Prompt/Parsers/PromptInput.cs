using System;

namespace Core3.Commands.Prompt.Parsers
{
    public class PromptInput
    {
        public PromptInput(string input)
        {
            OriginalInput = input;
            CmdletArguments = Array.Empty<string>();
        }

        public string CmdletName { get; set; }

        public string[] CmdletArguments { get; set; }

        public string OriginalInput { get; }
    }
}
