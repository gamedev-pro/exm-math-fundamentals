using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float acceleration = 100;

    [SerializeField] private float rotateSpeed = 10;

    [Header("Collision")]
    [SerializeField] private Vector3 colliderSize;

    private Vector3 targetVelocity;
    private Quaternion targetRotation;
    public Vector3 Velocity { get; private set; }

    private RaycastHit[] hits = new RaycastHit[10];

    public float MaxSpeed => moveSpeed;

    private Vector3 ColliderExtents => colliderSize * 0.5f;

    public void SetInput(float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        targetVelocity = input * moveSpeed;
        if (horizontal != 0 || vertical != 0)
        {
            targetRotation = Quaternion.LookRotation(input);
        }
    }

    private void FixedUpdate()
    {
        Velocity = Vector3.Lerp(Velocity, targetVelocity, Time.deltaTime * acceleration);

        CheckCollisionHorizontal();
        var targetPos = transform.position + Velocity * Time.deltaTime;
        CheckCollisionVertical(ref targetPos);

        transform.position = targetPos;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    private void CheckCollisionVertical(ref Vector3 targetPos)
    {
        const float rayLength = 10.0f;

        var hitCount = Physics.RaycastNonAlloc(
            transform.position + transform.up * colliderSize.y,
            transform.up * -1,
            hits,
            colliderSize.y + rayLength);

        for (int i = 0; i < hitCount; i++)
        {
            var hit = hits[i];
            targetPos.y = hit.point.y;
            break;
        }
    }

    private void CheckCollisionHorizontal()
    {
        var rayLength = Velocity.magnitude * Time.fixedDeltaTime;

        const float verticalShrink = 0.6f;
        var boxExtents = ColliderExtents;
        boxExtents.y *= verticalShrink;

        const float horizontalIterations = 5;
        const float boxShrinkXZ = 1.0f / horizontalIterations;

        for (int i = 0; i < horizontalIterations; i++)
        {
            var partialBox = boxExtents;
            partialBox.x *= boxShrinkXZ;
            partialBox.z *= boxShrinkXZ;

            var hitCount = Physics.BoxCastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            partialBox,
            Velocity.normalized,
            hits,
            transform.rotation,
            rayLength);

            for (int j = 0; j < hitCount; j++)
            {
                var hit = hits[j];
                var projectedVelocity = Vector3.ProjectOnPlane(Velocity, hit.normal);
                if (projectedVelocity != Vector3.zero)
                {
                    Velocity = projectedVelocity.normalized * Velocity.magnitude;
                    break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, colliderSize);
    }
}
