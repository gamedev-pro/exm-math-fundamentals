using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float acceleration = 100;

    [SerializeField] private float rotateSpeed = 10;

    [Header("Collision")]
    [SerializeField] private Vector3 colliderSize;
    [SerializeField] private float rayLength = 0.1f;

    private Vector3 targetVelocity;
    public Vector3 Velocity { get; private set; }

    private RaycastHit[] hits = new RaycastHit[10];

    public float MaxSpeed => moveSpeed;

    private Vector3 ColliderExtents => colliderSize * 0.5f;

    public void SetInput(float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        targetVelocity = input * moveSpeed;
    }

    private void FixedUpdate()
    {
        Velocity = Vector3.Lerp(Velocity, targetVelocity, Time.deltaTime * acceleration);
        var targetForward = Vector3.Lerp(transform.forward, Velocity, Time.deltaTime * rotateSpeed);

        CheckCollisionHorizontal();
        var targetPos = transform.position + Velocity * Time.deltaTime;

        CheckCollisionVertical(ref targetPos);

        transform.position = targetPos;
        transform.forward = targetForward;
    }

    private void CheckCollisionVertical(ref Vector3 targetPos)
    {
        var hitCount = Physics.RaycastNonAlloc(
            transform.position + transform.up * colliderSize.y, transform.up * -1,
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
        var hitCount = Physics.BoxCastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            colliderSize * 0.3f,
            Velocity.normalized,
            hits,
            transform.rotation,
            rayLength);

        for (int i = 0; i < hitCount; i++)
        {
            var hit = hits[i];
            var projectedVelocity = Vector3.ProjectOnPlane(Velocity, hit.normal);
            if (projectedVelocity != Vector3.zero)
            {
                Velocity = projectedVelocity.normalized * Velocity.magnitude;
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, colliderSize);
    }
}
