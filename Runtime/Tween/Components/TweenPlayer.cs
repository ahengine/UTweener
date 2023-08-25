using UnityEngine;
using Tweener.Components.Types;

namespace Tweener.Components
{
    public class TweenPlayer : MonoBehaviour
    {
        [SerializeField] private bool playOnEnable;
        [field: SerializeField] public EasingFunction.Ease EaseAnimation { private set; get; }
        [field: SerializeField] public float Duration { private set; get; } = 1;
        [field: SerializeField] public bool TimeScale { private set; get; } = true;
        //[field: SerializeField] public int  DurationPercentageOnCompletion { private set; get; } = 100;
        [field: SerializeField] public TweenEvents Events { private set; get; }
        [SerializeField] public TweenPingPong PingPong { private set; get; }
        [field: SerializeField] public TweenType[] Targets { private set; get; }
        public bool IsPlayed { protected set; get; }

        private bool isInitialized;

        public void Initialize()
        {
            if (isInitialized)
                return;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].Initialize(this);

            isInitialized = true;
        }

        private void Awake()
        {
            if (!isInitialized)
                Initialize();
        }

        protected void OnEnable()
        {
            if (playOnEnable)
                Play();
        }

        public virtual void Play(bool haveCompleteAction = true)
        {
            if(!isInitialized)
                Initialize();

            IsPlayed = true;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].Play(haveCompleteAction);
        }
        public virtual void ReversePlay(bool haveCompleteAction = true)
        {
            if (!isInitialized)
                Initialize();

            IsPlayed = false;

            for (int i = 0; i < Targets.Length; i++)
                Targets[i].ReversePlay(haveCompleteAction);
        }
        public virtual void ChangeState(bool haveCompleteAction = true)
        {
            if (IsPlayed)
                ReversePlay(haveCompleteAction);
            else
                Play(haveCompleteAction);
        }
    }
}