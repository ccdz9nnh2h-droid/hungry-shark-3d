using UnityEngine;

public class SharkAnimator : MonoBehaviour
{
    private Animator animator;
    private float swimSpeed = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator != null)
            animator.SetFloat("SwimSpeed", swimSpeed);
    }

    public void SetSwimmingSpeed(float speed)
    {
        swimSpeed = Mathf.Lerp(swimSpeed, speed, Time.deltaTime * 5f);
    }

    public void PlayEatAnimation()
    {
        if (animator != null)
            animator.SetTrigger("Eat");
    }

    public void PlayHitAnimation()
    {
        if (animator != null)
            animator.SetTrigger("Hit");
    }
}
