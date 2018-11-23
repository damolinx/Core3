using Core3.Commands.Attributes;
using Core3.Commands.Prompt;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Prompt.Example01.Cmdline.Cmdlets
{
    [CommandArgument(LongOptionName = "dir", ShortOptionName = "ls")]
    [CommandDescription("List directory contents")]
    public class DirectoryCmdlet : PromptCmdlet
    {
        public override Task<PromptCmdletResult> ExecuteAsync(PromptCmdletContext context, params string[] args)
        {
            IEnumerable<string> paths;

            if (args.Any())
            {
                paths = args.SelectMany(arg => Directory.Exists(arg) ? Directory.EnumerateFileSystemEntries(arg) : new[] { arg });
            }
            else
            {
                paths = Directory.EnumerateFileSystemEntries(((CmdPromptCmdletContext)context).CurrentDirectory);
            }

            foreach (var path in paths)
            {
                var fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    context.Output.WriteLine(fileInfo.Name);
                }
                else
                {
                    context.Error.WriteLine("File Not Found");
                }
            }

            return Task.FromResult(PromptCmdletResult.Empty);
        }
    }
}
