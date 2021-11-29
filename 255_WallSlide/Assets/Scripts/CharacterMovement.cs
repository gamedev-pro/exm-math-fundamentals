using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float acceleration = 100;

    private Vector3 targetVelocity;
    public Vector3 Velocity { get; private set; }

    public void SetInput(float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        targetVelocity = input * moveSpeed;
    }

    private void FixedUpdate()
    {
        Velocity = Vector3.Lerp(Velocity, targetVelocity, Time.deltaTime * acceleration);
        var targetPos = transform.position + Velocity * Time.deltaTime;
        transform.position = targetPos;
    }
}