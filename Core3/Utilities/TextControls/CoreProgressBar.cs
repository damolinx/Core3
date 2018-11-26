using Core3.Interfaces;

namespace Core3.Utilities.TextControls
{
    public class CoreProgressBar : CoreControl
    {
        public const char DefaultBackgroundCharacter = '░';

        public const char DefaultForegroundCharacter = '█';

        public CoreProgressBar(int width, int? left = null, int? top = null)
            : base(width, left, top)
        {
            BackgroundCharacter = DefaultBackgroundCharacter;
            ForegroundCharacter = DefaultForegroundCharacter;
        }

        public char BackgroundCharacter { get; set; }

        public char ForegroundCharacter { get; set; }

        public int Maximum { get; set; }

        public int Minimum { get; set; }

        public bool ShowPercentage { get; set; }

        public int Value { get; set; }

        protected override void InnerRender(ICoreOutput output)
        {
            var percentageText = string.Empty;
            var width = this.Width;

            if (ShowPercentage)
            {
                percentageText = (Value / (double)Maximum).ToString("P1").PadLeft(6);
                width -= (percentageText.Length + 1);
            }

            if (Value <= Minimum)
            {
                output
                    .SetCursorPosition((left: Left, top: Top))
                    .Write(new string(BackgroundCharacter, width));
            }
            else if (Value >= Maximum)
            {
                output
                    .SetCursorPosition((left: Left, top: Top))
                    .Write(new string(ForegroundCharacter, width));
            }
            else
            {
                var scale = (Maximum - Minimum) / (double)width;
                var complete = (int)(Value / scale);
                var remaining = (int)((Maximum / scale) - complete);
                output
                    .SetCursorPosition((left: Left, top: Top))
                    .Write(new string(ForegroundCharacter, complete))
                    .Write(new string(BackgroundCharacter, remaining));
            }

            if (ShowPercentage)
            {
                output
                    .Write(" ")
                    .Write(percentageText);
            }
        }
    }
}
