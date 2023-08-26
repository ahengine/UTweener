using UnityEngine;
using UnityEngine.UI;

namespace Tweener.Components.Types
{
    public class TweenColor : TweenType
    {
        public enum ComponentType { Graphic , SpriteRenderer}

        private Color start;
        [SerializeField,Tooltip("FillAmount & CanvasGroup Alpha => Color.a")] private Color target;
        [SerializeField] private ComponentType component;

        private Graphic graphicComponent;
        private SpriteRenderer sprComponent;

        public override void Initialize(TweenPlayer player)
        {
            base.Initialize(player);

            switch (component)
            {
                case ComponentType.Graphic:
                    graphicComponent = targetObject.GetComponent<Graphic>();
                    start = graphicComponent.color;
                    break;

                case ComponentType.SpriteRenderer:
                    sprComponent = targetObject.GetComponent<SpriteRenderer>();
                    start = sprComponent.color;
                    break;
            }
        }

        public override void Play(bool haveCompleteAction = true) =>
            Play(target, haveCompleteAction);

        public override void ReversePlay(bool haveCompleteAction = true) =>
            Play(start, haveCompleteAction);

        private void Play(Color target, bool haveCompleteAction)
        {
            System.Action onCompleteAction = haveCompleteAction ? (start == target ? () => player.Events.OnReverseCompleteEvent.Invoke() : () => player.Events.OnCompleteEvent.Invoke()) : null;

            switch (component)
            {
                case ComponentType.Graphic:
                    graphicComponent.TweenColor(target,player.Duration, player.TimeScale, onCompleteAction, 100, player.EaseAnimation).SetPingPong(player.PingPong).Play();
                    break;

                case ComponentType.SpriteRenderer:
                    sprComponent.TweenColor(target, player.Duration, player.TimeScale, onCompleteAction, 100, player.EaseAnimation).SetPingPong(player.PingPong).Play();
                    break;
            }

        }
    }
}