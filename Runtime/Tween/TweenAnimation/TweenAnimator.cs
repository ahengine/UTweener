using UnityEngine;

namespace Tweener.Components
{
    public class TweenAnimator : MonoBehaviour
    {
        [field:SerializeField] public string DefaultState { private set; get; }
        [field:SerializeField] public TweenAnimation[] States { private set; get; }

        private void OnEnable()
        {
            if (!string.IsNullOrEmpty(DefaultState))
                Play(DefaultState);
        }

        public void Play(string name)
        {
            for (int i = 0; i < States.Length; i++)
                if (States[i].name == name)
                {
                    States[i].PlayDefault();
                    break;
                }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                Play("Show");

            if (Input.GetKeyDown(KeyCode.H))
                Play("Hide");
        }
    }
}