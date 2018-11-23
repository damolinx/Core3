using Core3.Extensions;
using Core3.Interfaces;
using System;
using System.Collections.Generic;

namespace Core3.Commands.Prompt
{
    public class PromptCmdletContext
    {
        public PromptCmdletContext(CoreCommandContext parent, PromptCommand prompt)
        {
            Annotations = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            CommandContext = parent ?? throw new ArgumentNullException(nameof(parent));
            Prompt = prompt ?? throw new ArgumentNullException(nameof(prompt));
        }

        public IDictionary<string, object> Annotations { get; }

        public CoreCommandContext CommandContext { get; }

        public ICoreErrorOutput Error => CommandContext.GetError();

        public bool Exit { get; set; }

        public ICoreInput Input => CommandContext.GetInput();

        public ICoreOutput Output => CommandContext.GetOutput();

        public PromptCommand Prompt { get; }
    }
}
