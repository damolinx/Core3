using Core3.Commands;
using Core3.Interfaces;

namespace Core3.Extensions
{
    public static class CoreCommandContextExtensions
    {
        public static ICoreErrorOutput GetError(this CoreCommandContext context)
        {
            return context.ServiceProvider.GetService<ICoreErrorOutput>();
        }

        public static ICoreInput GetInput(this CoreCommandContext context)
        {
            return context.ServiceProvider.GetService<ICoreInput>();
        }

        public static ICoreOutput GetOutput(this CoreCommandContext context)
        {
            return context.ServiceProvider.GetService<ICoreOutput>();
        }

        public static CoreProgram GetProgram(this CoreCommandContext context)
        {
            return context.GetProgram<CoreProgram>();
        }

        public static TProgram GetProgram<TProgram>(this CoreCommandContext context)
            where TProgram : CoreProgram
        {
            return context.ServiceProvider.GetService<TProgram>();
        }
    }
}
