using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace UTweener.Components.Types
{
    public abstract class UTweenType : MonoBehaviour
    {
        protected UTweenPlayer player;
        [SerializeField,Tooltip("Null == this game object")] protected GameObject targetObject;
        public virtual void Initialize(UTweenPlayer player)
        {
            this.player = player;

            if(!targetObject)
                targetObject = gameObject;
        }

        public abstract void Play(bool haveCompleteAction = true);

        public abstract void ReversePlay(bool haveCompleteAction = true);

        protected void Play<T>(UTween<T> tweener, bool reverse, bool haveCompleteAction = true)
        {
            System.Action onCompleteAction = haveCompleteAction ? (reverse ? () => player.Events.OnReverseCompleteEvent.Invoke() : () => player.Events.OnCompleteEvent.Invoke()) : null;

            tweener.SetDuration(player.Duration).
            SetTimeScale(player.TimeScale).
            SetEase(player.EaseAnimation).
            SetOnCompleteAction(onCompleteAction).
            SetPingPong(player.PingPong).
            Play();
        }
    }
}