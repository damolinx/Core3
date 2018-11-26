using Core3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            output.Write((left: Left, top: Top), AnimationSequence.ElementAt(_frame).ToString());
        }

        public async Task StartAsync(ICoreOutput output, TimeSpan delay, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Render(output);
                await Task.Delay(delay, cancellationToken);
            }
        }
    }
}
