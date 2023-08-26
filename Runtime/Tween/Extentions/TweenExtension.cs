using UnityEngine;
using System;
using UnityEngine.UI;

namespace Tweener
{
    public static class TweenExtension
    {
        // Sprite Renderer
        public static Tween<Color> TweenColor(this SpriteRenderer sr, Color target, float duration = 1, bool timeScale = true, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            TweenLerp.Lerp(sr.color, target, duration, timeScale, value => sr.color = value, onComplete, DurationPercentageOnCompletion, ease);
        public static Tween<Color> TweenAlpha(this SpriteRenderer sr, float target, float duration = 1, bool timeScale = true, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          TweenLerp.Lerp(sr.color, target, duration, timeScale, value => sr.color = value, onComplete, DurationPercentageOnCompletion, ease);
    }
}