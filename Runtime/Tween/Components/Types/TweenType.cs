using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Tweener.Components.Types
{
    public abstract class TweenType : MonoBehaviour
    {
        protected TweenPlayer player;
        [SerializeField,Tooltip("Null == this game object")] protected GameObject targetObject;
        public virtual void Initialize(TweenPlayer player)
        {
            this.player = player;

            if(!targetObject)
                targetObject = gameObject;
        }

        public abstract void Play(bool haveCompleteAction = true);

        public abstract void ReversePlay(bool haveCompleteAction = true);

        protected void Play<T>(Tween<T> tweener, bool reverse, bool haveCompleteAction = true)
        {
            System.Action onCompleteAction = haveCompleteAction ? (reverse ? () => player.Events.onReverseCompleteEvent.Invoke() : () => player.Events.onCompleteEvent.Invoke()) : null;

            tweener.SetDuration(player.Duration).
            SetTimeScale(player.TimeScale).
            SetEase(player.EaseAnimation).
            SetOnCompleteAction(onCompleteAction).
            SetPingPong(player.PingPong).
            Play();
        }
    }
}