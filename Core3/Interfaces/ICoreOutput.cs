namespace Core3.Interfaces
{
    public interface ICoreOutput
    {
        (int left, int top) GetCursorPosition();

        ICoreOutput SetCursorPosition((int left, int top) position);

        ICoreOutput Write(string format, params object[] args);

        ICoreOutput WriteLine();

        ICoreOutput WriteLine(string format, params object[] args);
    }
}
