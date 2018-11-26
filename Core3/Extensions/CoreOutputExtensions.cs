using Core3.Interfaces;
using Core3.Utilities.TextControls;

namespace Core3.Extensions
{
    public static class CoreOutputExtensions
    {
        public static ICoreOutput InsertControl(this ICoreOutput output, CoreControl control)
        {
            var position = output.GetCursorPosition();
            control.Left = position.left;
            control.Top = position.top;
            return output;
        }
    }
}
