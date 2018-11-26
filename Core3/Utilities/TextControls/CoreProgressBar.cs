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
            if (ShowPercentage)
            {
                InnerRenderWithPercentage(output);
            }
            else
            {
                InnerRenderBare(output);
            }
        }

        private void InnerRenderBare(ICoreOutput output)
        {
            var completeText = string.Empty;
            var remainingText = string.Empty;

            if (Value <= Minimum)
            {
                remainingText = new string(BackgroundCharacter, Width);
            }
            else if (Value >= Maximum)
            {
                completeText = new string(ForegroundCharacter, Width);
            }
            else
            {
                var scale = (Maximum - Minimum) / (double)Width;
                var complete = (int)(Value / scale);
                var remaining = (int)((Maximum / scale) - complete);
                completeText = new string(ForegroundCharacter, complete);
                remainingText = new string(BackgroundCharacter, remaining);
            }

            output
                .Write((left: Left, top: Top), completeText)
                .Write((left: Left + completeText.Length, top: Top), remainingText);
        }

        private void InnerRenderWithPercentage(ICoreOutput output)
        {
            var percentageText = (Value / (double)Maximum).ToString("P1").PadLeft(6);
            var width = this.Width - (percentageText.Length + 1);
            var completeText = string.Empty;
            var remainingText = string.Empty;

            if (Value <= Minimum)
            {
                remainingText = new string(BackgroundCharacter, width);
            }
            else if (Value >= Maximum)
            {
                completeText = new string(ForegroundCharacter, width);
            }
            else
            {
                var scale = (Maximum - Minimum) / (double)width;
                var complete = (int)(Value / scale);
                var remaining = (int)((Maximum / scale) - complete);
                completeText = new string(ForegroundCharacter, complete);
                remainingText = new string(BackgroundCharacter, remaining);
            }

            output
                .Write((left: Left, top: Top), completeText)
                .Write((left: Left + completeText.Length, top: Top), remainingText)
                .Write((left: Left + completeText.Length + remainingText.Length, top: Top), " {0}", percentageText);
        }
    }
}
