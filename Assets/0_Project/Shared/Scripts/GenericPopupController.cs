using DG.Tweening;
using UnityEngine;

public class GenericPopupController : MonoBehaviour
{

    [SerializeField] private Animator animator;

    public void OnCloseButtonClicked()
    {
        animator.SetTrigger("Close");
    }


// Method called through animation event when the close animation is completed

    public void OnClosedAnimationCompleted()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        transform.DOKill(); // Prevent memory leak from hanging tweens
    }
}
