using UnityEngine;
using UnityEngine.UI;

namespace UTweener.Components.Types
{
    public class UTweenAlpha : UTweenType
    {
        public enum CompnentType { Graphic, SpriteRenderer, CanvasGroup}

        private float start;
        [SerializeField, Range(0, 1)] private float target;
        [SerializeField] private CompnentType component;

        private Graphic graphicComponent;
        private CanvasGroup canvasGroupComponent;
        private SpriteRenderer sprComponent;


        public override void Initialize(UTweenPlayer player)
        {
            base.Initialize(player);

            switch (component)
            {
                case CompnentType.Graphic:
                    graphicComponent = targetObject.GetComponent<Graphic>();
                    break;
                case CompnentType.SpriteRenderer:
                    canvasGroupComponent = targetObject.GetComponent<CanvasGroup>();
                    break;
                case CompnentType.CanvasGroup:
                    sprComponent = targetObject.GetComponent<SpriteRenderer>();
                    break;
            }
        }

        public override void Play(bool haveCompleteAction = true) =>
            Play(target, haveCompleteAction,false);

        public override void ReversePlay(bool haveCompleteAction = true) =>
            Play(start, haveCompleteAction,true);

        private void Play(float target, bool haveCompleteAction = true, bool reverse = false)
        {
            switch (component)
            {
                case CompnentType.Graphic:
                    Play(graphicComponent.TweenAlpha(target), reverse);
                    break;
                case CompnentType.SpriteRenderer:
                    Play(sprComponent.TweenAlpha(target), reverse);
                    break;
                case CompnentType.CanvasGroup:
                    Play(canvasGroupComponent.TweenAlpha(target), reverse);
                    break;
                default:
                    break;
            }
        }

        public void UpdateStartValue(float startValue) =>
            start = startValue;
    }
}