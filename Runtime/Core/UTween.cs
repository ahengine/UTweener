using UnityEngine;
using System;
using UTweener.Components;

namespace UTweener
{
    public class UTween<T> : IUTween
    {
        public delegate T LerpFunction(T start, T target, float t);

        protected T start, value, target;
        private float timeElapsed, duration;
        private EasingFunction.Function easeFunc;
        protected Action<T> onUpdate;
        private Action onCompleteAction;
        private int DurationPercentageOnCompletion;
        private bool calledOnCompleteAction;
        protected LerpFunction lerpFunc;
        public bool TimeScale { private set; get; }
        public bool IsPlaying { private set; get; }
        public UTweenPingPong PingPong { private set; get; }

        public UTween(T start, T target, float duration, LerpFunction lerpFunc, bool timeScale = true,
            Action<T> onUpdate = null, Action onComplete = null, int DurationPercentageOnCompletion = 100,
            EasingFunction.Ease ease = EasingFunction.Ease.Linear)
        {
            value = this.start = start;
            this.target = target;
            this.duration = duration;
            this.lerpFunc = lerpFunc;
            this.onUpdate = onUpdate;
            onCompleteAction = onComplete;
            this.DurationPercentageOnCompletion = DurationPercentageOnCompletion;
            easeFunc = EasingFunction.GetEasingFunction(ease);
            timeElapsed = 0;
            TimeScale = timeScale;
            UTweener.Add(this);
        }


        public void Update()
        {
            if (!IsPlaying) return;

            timeElapsed += TimeScale ? Time.deltaTime : Time.unscaledDeltaTime;
            float t = timeElapsed / duration;
            value = lerpFunc(start, target, easeFunc(0, 1, t));
            onUpdate?.Invoke(value);
            if (t >= 1)
                OnComplete();

            if (!calledOnCompleteAction && DurationPercentageOnCompletion < 100 &&
                t >= ((float) DurationPercentageOnCompletion / 100.0f))
                CompleteAction();
        }

        public UTween<T> Stop()
        {
            timeElapsed = 0;
            value = start;
            IsPlaying = false;
            return this;
        }

        private void OnComplete()
        {
            if (PingPong.Enable)
            {
                if (PingPong.Count != -1)
                {
                    PingPong.Count--;

                    if (PingPong.Count == 0)
                    {
                        PingPong.Enable = false;
                        DoComplete();
                        return;
                    }
                }

                Reverse().Stop().Play();
            }
            else
                DoComplete();
        }

        public void DoComplete(bool allowCallCompleteAction = true)
        {
            IsPlaying = false;
            if(allowCallCompleteAction) CompleteAction();
            UTweener.Remove(this);
        }

        private void CompleteAction()
        {
            if (calledOnCompleteAction) return;
            calledOnCompleteAction = true;
            onCompleteAction?.Invoke();
        }

        public UTween<T> Play()
        {
            IsPlaying = true;
            return this;
        }

        public UTween<T> Pause()
        {
            IsPlaying = false;
            return this;
        }

        public UTween<T> Reset()
        {
            timeElapsed = 0;
            value = start;
            onUpdate?.Invoke(value);
            return this;
        }

        public UTween<T> Reverse()
        {
            var startValue = start;
            start = target;
            target = startValue;
            return this;
        }

        public UTween<T> SetStart(T value)
        {
            start = value;
            return this;
        }

        public UTween<T> SetTarget(T value)
        {
            target = value;
            return this;
        }

        public UTween<T> SetTimeScale(bool value)
        {
            TimeScale = value;
            return this;
        }


        public UTween<T> SetDuration(float value)
        {
            duration = value;
            return this;
        }

        public UTween<T> SetPingPong(UTweenPingPong pingPong)
        {
            if (!pingPong.Enable)
                return this;

            PingPong = pingPong;
            return this;
        }

        public UTween<T> SetEase(EasingFunction.Ease ease)
        {
            easeFunc = EasingFunction.GetEasingFunction(ease);
            return this;
        }

        public UTween<T> SetOnCompleteAction(Action action)
        {
            onCompleteAction = action;
            return this;
        }
    }
}