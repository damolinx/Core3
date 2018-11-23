namespace Core3.Interfaces
{
    public interface ICoreErrorOutput
    {
        ICoreErrorOutput Write(string format, params object[] args);

        ICoreErrorOutput WriteLine();

        ICoreErrorOutput WriteLine(string format, params object[] args);
    }
}
