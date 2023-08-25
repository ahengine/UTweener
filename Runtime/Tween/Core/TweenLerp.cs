using System;
using UnityEngine;

namespace Tweener
{
    public static class TweenLerp
    {
        public static float LerpAlgorithm(float start, float target, float t) => Mathf.Lerp(start, target, t);
        public static Vector2 LerpAlgorithm(Vector2 start, Vector2 target, float t) => Vector2.Lerp(start, target, t);
        public static Vector3 LerpAlgorithm(Vector3 start, Vector3 target, float t) => Vector3.Lerp(start, target, t);
        public static Quaternion LerpAlgorithm(Quaternion start, Quaternion target, float t) => Quaternion.Lerp(start, target, t);
        public static Color LerpAlgorithm(Color start, Color target, float t) => Color.Lerp(start, target, t);

        // Base Extensions
        public static Tween<float> Lerp(this float start, float target, float duration, bool timeScale = true, Action<float> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            new Tween<float>(start, target, duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);

        public static Tween<Vector2> Lerp(this Vector2 start, Vector2 target, float duration, bool timeScale = true, Action<Vector2> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            new Tween<Vector2>(start, target, duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);

        public static Tween<Vector3> Lerp(this Vector3 start, Vector3 target, float duration, bool timeScale = true, Action<Vector3> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            new Tween<Vector3>(start, target, duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);

        public static Tween<Quaternion> Lerp(this Quaternion start, Quaternion target, float duration, bool timeScale = true, Action<Quaternion> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
           new Tween<Quaternion>(start, target, duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);

        public static Tween<Color> Lerp(this Color start, Color target, float duration, bool timeScale = true, Action<Color> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
           new Tween<Color>(start, target, duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);

        public static Tween<Color> Lerp(this Color color, float target, float duration, bool timeScale = true, Action<Color> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
           new Tween<Color>(color, new Color(color.r,color.g,color.b, target), duration, LerpAlgorithm, timeScale, onUpdate, onComplete, DurationPercentageOnCompletion, ease);
    }
}
