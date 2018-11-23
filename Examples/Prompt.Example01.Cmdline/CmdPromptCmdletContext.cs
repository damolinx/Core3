using Core3.Commands;
using Core3.Commands.Prompt;
using System;

namespace Prompt.Example01.Cmdline
{
    public class CmdPromptCmdletContext : PromptCmdletContext
    {
        public CmdPromptCmdletContext(CoreCommandContext context, PromptCommand prompt)
            : base(context, prompt)
        {
        }

        /// <summary>
        /// Current environment
        /// </summary>
        /// <remarks>
        /// Used to wrap <see cref="Environment.CurrentDirectory"/> to keep sample simple
        /// </remarks>
        public string CurrentDirectory
        {
            get { return Environment.CurrentDirectory; }
            set { Environment.CurrentDirectory = value; }
        }
    }
}