namespace Core3.Interfaces
{
    public interface ICoreOutput
    {
        ICoreOutput Write(string format, params object[] args);

        ICoreOutput WriteLine();

        ICoreOutput WriteLine(string format, params object[] args);
    }
}
