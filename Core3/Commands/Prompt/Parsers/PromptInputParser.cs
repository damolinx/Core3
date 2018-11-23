namespace Core3.Commands.Prompt.Parsers
{
    public abstract class PromptInputParser
    {
        protected PromptInputParser()
        {
        }

        protected abstract PromptInput Parse(PromptCmdletContext context, string input);

        public bool TryParseInput(PromptCmdletContext context, string input, out PromptInput parsedInput)
        {
            try
            {
                parsedInput = Parse(context, input);
                return true;
            }
            catch
            {
                parsedInput = default;
                return false;
            }
        }
    }
}