using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    [SerializeField] private Tweener.Components.TweenAnimator animator;
    [SerializeField] private string ShowState = "Show", HideState = "Hide";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
            animator.Play(ShowState);

        if (Input.GetKeyDown(KeyCode.Alpha9))
            animator.Play(HideState);
    }
}
