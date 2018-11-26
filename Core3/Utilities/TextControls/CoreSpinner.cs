using Core3.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core3.Utilities.TextControls
{
    public class CoreSpinner : CoreControl
    {
        public static readonly IEnumerable<char> DefaultAnimationSequence = new[] { '/', '―', '\\', '|' };

        private int _frame;

        public CoreSpinner(int? left = null, int? top = null)
            : base(1, left, top)
        {
            AnimationSequence = DefaultAnimationSequence;
        }

        public IEnumerable<char> AnimationSequence { get; set; }

        protected override void InnerRender(ICoreOutput output)
        {
            _frame = (_frame + 1) % AnimationSequence.Count();
            output
                .SetCursorPosition((left: this.Left, top: this.Top))
                .Write(AnimationSequence.ElementAt(_frame).ToString());
        }

        //TODO: DO NOT enable until Output is locked / scoped / other
        //public async Task StartAsync(ICoreOutput output, TimeSpan delay, CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        Render(output);
        //        await Task.Delay(delay, cancellationToken);
        //    }
        //}
    }
}
