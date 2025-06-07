using UnityEngine;

public class SettingsPopupController : MonoBehaviour
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
}
