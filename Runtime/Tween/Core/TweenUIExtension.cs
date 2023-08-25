using UnityEngine;
using UnityEngine.UI;
using System;

namespace Tweener
{
    public static class TweenUIExtension
    {
        public static Tween<Color> TweenColor(this Graphic graphic, Color target, float duration = 1, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          TweenLerp.Lerp(graphic.color, target, duration, timeScale, value => graphic.color = value, onComplete, callCompleteEventOnThisPercentDuration, ease);

        public static Tween<Color> TweenAlpha(this Graphic graphic, float target, float duration = 1, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          TweenLerp.Lerp(graphic.color, target, duration, timeScale, value => graphic.color = value, onComplete, callCompleteEventOnThisPercentDuration, ease);

        public static Tween<float> TweenAlpha(this CanvasGroup canvasGroup, float target, float duration = 1, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          TweenLerp.Lerp(canvasGroup.alpha, target, duration, timeScale, value => canvasGroup.alpha = value, onComplete, callCompleteEventOnThisPercentDuration, ease);

        public static Tween<float> TweenFillAmount(this Image img, float target, float duration = 1, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          TweenLerp.Lerp(img.fillAmount, target, duration, timeScale, value => img.fillAmount = value, onComplete, callCompleteEventOnThisPercentDuration, ease);
    }
}