using UnityEngine;
using System;
using UnityEngine.UI;

namespace UTweener
{
    public static class UTweenExtension
    {
        // Sprite Renderer
        public static UTween<Color> TweenColor(this SpriteRenderer sr, Color target, float duration = 1, bool timeScale = true, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            UTweenLerp.Lerp(sr.color, target, duration, timeScale, value => sr.color = value, onComplete, DurationPercentageOnCompletion, ease);
        public static UTween<Color> TweenAlpha(this SpriteRenderer sr, float target, float duration = 1, bool timeScale = true, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          UTweenLerp.Lerp(sr.color, target, duration, timeScale, value => sr.color = value, onComplete, DurationPercentageOnCompletion, ease);
    }
}