using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private CharacterMovement charMovement;

    private void Awake()
    {
        charMovement = GetComponent<CharacterMovement>();
    }

    private void LateUpdate()
    {
        var speedPercent = charMovement.Velocity.sqrMagnitude / (charMovement.MaxSpeed * charMovement.MaxSpeed);
        animator.SetFloat("Speed", speedPercent);
    }
}
