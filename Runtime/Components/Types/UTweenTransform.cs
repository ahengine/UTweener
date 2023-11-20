
using UnityEngine;
using UTweener.Components.Types;

namespace UTweener.Components
{
    public class UTweenTransform : UTweenType
    {
        public enum TransformType { Move, Rotate, Scale,Size }

        private Transform tr;
        private RectTransform rectTransform;
        private Vector3 start;
        [SerializeField] private Vector3 target;
        [SerializeField] private Space space;
        [SerializeField] private TransformType type;

        public override void Initialize(UTweenPlayer player)
        {
            base.Initialize(player);

            tr = targetObject.transform;

            switch (type)
            {
                case TransformType.Move:
                    start = space == Space.Self ? tr.localPosition : tr.position;
                    break;
                case TransformType.Rotate:
                    start = space == Space.Self ? tr.localEulerAngles : tr.eulerAngles;
                    break;
                case TransformType.Scale:
                    start = tr.localScale;
                    break;
                case TransformType.Size:
                    rectTransform = GetComponent<RectTransform>();
                    start = rectTransform.sizeDelta;
                    break;
            }
        }

        public override void Play(bool haveCompleteAction = true) =>
            Play(target, haveCompleteAction);

        public override void ReversePlay(bool haveCompleteAction = true) =>
            Play(start, haveCompleteAction);

        public void Play(Vector3 target, bool haveCompleteAction)
        {
            UTween<Vector3> tween = null;

            switch (type)
            {
                case TransformType.Move:
                    tween = tr.TweenPosition(target, player.Duration, space, player.TimeScale,null,100);
                    break;
                case TransformType.Rotate:
                    tween = tr.TweenEulerAngles(target, player.Duration, space, player.TimeScale, null, 100);
                    break;
                case TransformType.Scale:
                    tween = tr.TweenScale(target, player.Duration, player.TimeScale, null, 100);
                    break;
                case TransformType.Size:
                    tween = rectTransform.TweenRectSize(target, player.Duration, player.TimeScale, null, 100);
                    break;
                default:
                    break;
            }

            if (haveCompleteAction)
                tween.SetOnCompleteAction(start == target ? () => player.Events.OnReverseCompleteEvent.Invoke()
                : () => player.Events.OnCompleteEvent.Invoke());

            tween.SetEase(player.EaseAnimation);
            tween.SetPingPong(player.PingPong);
            tween.Play();
        }
    }
}