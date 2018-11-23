using Core3.Commands;

namespace Core3.Extensions
{
    public static class CoreProgramExtensions
    {
        public static TProgram AddCommand<TProgram>(this TProgram program, CoreCommand command)
            where TProgram : CoreProgram
        {
            program.CommandStack.Push(command);
            return program;
        }
    }
}
