using UnityEngine;
using System;
using Tweener.Components;

namespace Tweener
{
    public class Tween<T> : ITween
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
        public bool PingPong { private set; get; }
        public int PingPongCount { private set; get; } = -1;

        public Tween(T start, T target, float duration, LerpFunction lerpFunc, bool timeScale = true,
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
            Tweener.Add(this);
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

        public Tween<T> Stop()
        {
            timeElapsed = 0;
            value = start;
            IsPlaying = false;
            return this;
        }

        private void OnComplete()
        {
            if (PingPong)
            {
                if (PingPongCount != -1)
                {
                    PingPongCount--;

                    if (PingPongCount == 0)
                    {
                        PingPong = false;
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
            Tweener.Remove(this);
        }

        private void CompleteAction()
        {
            if (calledOnCompleteAction) return;
            calledOnCompleteAction = true;
            onCompleteAction?.Invoke();
        }

        public Tween<T> Play()
        {
            IsPlaying = true;
            return this;
        }

        public Tween<T> Pause()
        {
            IsPlaying = false;
            return this;
        }

        public Tween<T> Reset()
        {
            timeElapsed = 0;
            value = start;
            onUpdate?.Invoke(value);
            return this;
        }

        public Tween<T> Reverse()
        {
            var startValue = start;
            start = target;
            target = startValue;
            return this;
        }

        public Tween<T> SetStart(T value)
        {
            start = value;
            return this;
        }

        public Tween<T> SetTarget(T value)
        {
            target = value;
            return this;
        }

        public Tween<T> SetTimeScale(bool value)
        {
            TimeScale = value;
            return this;
        }


        public Tween<T> SetDuration(float value)
        {
            duration = value;
            return this;
        }

        public Tween<T> SetPingPong(bool value = true)
        {
            PingPong = value;
            return this;
        }

        public Tween<T> SetPingPong(TweenPingPong pingPong)
        {
            if (!pingPong.pingPong)
                return this;

            SetPingPong();
            SetPingPongCount(pingPong.pingPongCount);
            return this;
        }

        public Tween<T> SetPingPongCount(int count)
        {
            PingPongCount = count;
            SetPingPong();
            return this;
        }


        public Tween<T> SetEase(EasingFunction.Ease ease)
        {
            easeFunc = EasingFunction.GetEasingFunction(ease);
            return this;
        }

        public Tween<T> SetOnCompleteAction(Action action)
        {
            onCompleteAction = action;
            return this;
        }
    }
}