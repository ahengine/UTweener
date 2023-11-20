using UnityEngine;
using System;

namespace UTweener
{
    public static class UTweenTransformExtension
    {
        public static UTween<Vector3> TweenPosition(this Transform tr, Vector3 target, float duration, Space space, bool timeScale = true, Action onComplete = null,int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear)
        {
            void Update(Vector3 value) => tr.position = value;
            void UpdateLocal(Vector3 value) => tr.localPosition = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localPosition : tr.position, target, duration, timeScale, space == Space.Self ? UpdateLocal : Update, onComplete, callCompleteEventOnThisPercentDuration, ease);
        }

        public static UTween<Vector3> TweenEulerAngles (this Transform tr, Vector3 target, float duration, Space space, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear)
        {
            void Update(Vector3 value) => tr.eulerAngles = value;
            void UpdateLocal(Vector3 value) => tr.localEulerAngles = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localEulerAngles : tr.eulerAngles, target, duration, timeScale, space == Space.Self ? UpdateLocal : Update, onComplete, callCompleteEventOnThisPercentDuration, ease);
        }

        public static UTween<Quaternion> TweenQuaternion(this Transform tr, Quaternion target, float duration, Space space, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear)
        {
            void Update(Quaternion value) => tr.rotation = value;
            void UpdateLocal(Quaternion value) => tr.localRotation = value;

            return UTweenLerp.Lerp(space == Space.Self ? tr.localRotation : tr.rotation, target, duration, timeScale, space == Space.Self ? UpdateLocal : Update, onComplete, callCompleteEventOnThisPercentDuration, ease);
        }

        public static UTween<Vector3> TweenScale(this Transform tr, Vector3 target, float duration, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
          UTweenLerp.Lerp(tr.localScale, target, duration, timeScale, value => tr.localScale = value, onComplete, callCompleteEventOnThisPercentDuration, ease);

        public static UTween<Vector3> TweenRectSize(this RectTransform tr, Vector3 target, float duration, bool timeScale = true, Action onComplete = null, int callCompleteEventOnThisPercentDuration = 100, EasingFunction.Ease ease = EasingFunction.Ease.Linear) =>
            UTweenLerp.Lerp((Vector3)tr.sizeDelta, target, duration, timeScale, value => tr.sizeDelta = value, onComplete, callCompleteEventOnThisPercentDuration, ease);
    }
}