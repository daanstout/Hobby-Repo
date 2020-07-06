using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGame.UI.Framework.TextRenderer {
    public static class TextAlignerPicker {
        public static ITextAligner PickAligner(TextAlignment alignment) {
            return alignment switch
            {
                TextAlignment.BottomCentered => BottomCenteredTextAligner.instance,
                TextAlignment.BottomLeft => BottomLeftTextAligner.instance,
                TextAlignment.BottomRight => BottomRightTextAligner.instance,
                TextAlignment.CenteredLeft => CenteredLeftTextAligner.instance,
                TextAlignment.Centered => CenteredTextAligner.instance,
                TextAlignment.CenteredRight => CenteredRightTextAligner.instance,
                TextAlignment.TopLeft => TopLeftTextAligner.instance,
                TextAlignment.TopCentered => TopCenteredTextAligner.instance,
                TextAlignment.TopRight => TopRightTextAligner.instance,
                _ => CenteredTextAligner.instance
            };
        }
    }
}
