using Core3.Commands;
using Core3.Extensions;
using Core3.Interfaces;
using Core3.Properties;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Core3
{
    public class CoreProgram
    {
        public CoreProgram(params string[] args)
        {
            CommandStack = new ConcurrentStack<CoreCommand>();
        }

        public ConcurrentStack<CoreCommand> CommandStack { get; protected set; }

        public IServiceProvider ServiceProvider { get; protected set; }

        protected virtual void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            var logger = ServiceProvider.GetLogger();
            logger?.LogInformation("Cancel key press received");

            //TODO:
        }

        protected virtual CoreCommandContext CreateCommandContext(IServiceProvider provider, string[] args)
        {
            //TODO: var args.Select(arg => new CoreArgument { Value = arg }).ToList();
            var context = new CoreCommandContext { ServiceProvider = provider };
            return context;
        }

        protected virtual IServiceProvider CreateServiceProvider()
        {
            var serviceProvider = new CoreServiceProvider()
                .AddSingleton<CoreProgram>(this)
                .AddSingleton<ICoreInput>(CoreConsole.Instance)
                .AddSingleton<ICoreErrorOutput>(CoreConsole.Instance)
                .AddSingleton<ICoreOutput>(CoreConsole.Instance)
                .AddSingleton<ILogger>(NullLogger.Instance);
            return serviceProvider;
        }

        public virtual void Execute(params string[] args)
        {
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += Console_CancelKeyPress;

            try
            {
                ExecuteAsync(args, cts.Token).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                var logger = ServiceProvider.GetService<ILogger>();
                logger?.LogError(ex, "Unhandled exception");
            }
            finally
            {
                Console.CancelKeyPress -= Console_CancelKeyPress;
            }
        }

        public virtual async Task ExecuteAsync(string[] args, CancellationToken cancellationToken)
        {
            var sp = CreateServiceProvider();
            ServiceProvider = sp;

            var context = CreateCommandContext(sp, args);

            while (CommandStack.TryPeek(out var command))
            {
                var commandComplete = false;
                SetupConsole(command);

                try
                {
                    var commandResult = await command.ExecuteAsync(context, cancellationToken);
                    commandComplete = commandResult.Complete;
                }
                catch (Exception ex)
                {
                    var exceptionHandleResult = command.HandleException(ex);
                    if (exceptionHandleResult.ExceptionHandled)
                    {
                        commandComplete = exceptionHandleResult.Complete;
                    }
                    else
                    {
                        throw;
                    }
                }

                if (commandComplete)
                {
                    if (!CommandStack.TryPop(out var topCommand) || (topCommand != command))
                    {
                        var message = string.Format(CultureInfo.CurrentUICulture, Resources.CommandStackUnexpectedState_2, command, topCommand);
                        throw new InvalidOperationException(message);
                    }

                    if (command.RequiresExitPause)
                    {
                        Console.WriteLine(Resources.PressAnyKeyToContinue);
                        Console.ReadKey(intercept: true);
                    }
                }
            }
        }

        protected virtual void SetupConsole(CoreCommand command)
        {
            Console.CursorVisible = command.RequiresCursor;

            if (command.RequiresClearScreen)
            {
                Console.Clear();
            }
        }
    }
}
