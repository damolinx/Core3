using Core3.Interfaces;
using System;

namespace Core3.Utilities.TextControls
{
    public abstract class CoreControl
    {
        protected CoreControl(int width, int? left = null, int? top = null)
        {
            this.Width = width;
            this.Left = left ?? Console.CursorLeft;
            this.Top = top ?? Console.CursorTop;
        }

        public int Left { get; internal set; }

        public int Top { get; internal set; }

        public int Width { get; set; }

        public virtual void Clean(ICoreOutput output)
        {
            var position = output.GetCursorPosition();
            try
            {
                output.Write((left: Left, top: Top), new string(' ', this.Width));
            }
            finally
            {
                output.SetCursorPosition(position);
            }
        }


        protected abstract void InnerRender(ICoreOutput output);

        public void Render(ICoreOutput output)
        {
            var position = output.GetCursorPosition();
            try
            {
                InnerRender(output);
            }
            finally
            {
                output.SetCursorPosition(position);
            }
        }
    }
}
