using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace Tweener.Components.Types
{
    public class TweenFillAmount : TweenType
    {
        private float start;
        [SerializeField, Range(0, 1)] private float target;

        private Image imgComponent;

        public override void Initialize(TweenPlayer player)
        {
            base.Initialize(player);
            imgComponent = targetObject.GetComponent<Image>();
        }

        public override void Play(bool haveCompleteAction = true) =>
            Play(target, haveCompleteAction);

        public override void ReversePlay(bool haveCompleteAction = true) =>
            Play(start, haveCompleteAction);

        private void Play(float target, bool haveCompleteAction = true)
        {
            System.Action onCompleteAction = haveCompleteAction ? (start == target ? () => player.Events.onReverseCompleteEvent.Invoke() : () => player.Events.onCompleteEvent.Invoke()) : null;
            imgComponent.TweenFillAmount(target,player.Duration, player.TimeScale, onCompleteAction, 100, player.EaseAnimation).SetPingPong(player.PingPong).Play();
        }

        public void UpdateStartValue(float startValue) =>
            start = startValue;
    }
}
