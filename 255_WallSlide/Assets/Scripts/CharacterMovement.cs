using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float acceleration = 100;

    [Header("Collision")]
    [SerializeField] private Vector3 colliderSize;

    private Vector3 targetVelocity;
    public Vector3 Velocity { get; private set; }

    private Vector3 ColliderExtents => colliderSize * 0.5f;

    private RaycastHit[] hits = new RaycastHit[10];

    public void SetInput(float horizontal, float vertical)
    {
        var input = new Vector3(horizontal, 0, vertical);
        targetVelocity = input * moveSpeed;
    }

    private void FixedUpdate()
    {
        Velocity = Vector3.Lerp(Velocity, targetVelocity, Time.fixedDeltaTime * acceleration);
        CheckCollisionHorizontal();
        var targetPos = transform.position + Velocity * Time.fixedDeltaTime;
        transform.position = targetPos;
    }

    private void CheckCollisionHorizontal()
    {
        var rayLength = Velocity.magnitude * Time.fixedDeltaTime;
        var hitCount = Physics.BoxCastNonAlloc(
            transform.position + Vector3.up * ColliderExtents.y,
            ColliderExtents,
            Velocity.normalized,
            hits,
            transform.rotation,
            rayLength);

        for (int i = 0; i < hitCount; i++)
        {
            var hit = hits[i];
            var projectedVelocity = Vector3.ProjectOnPlane(Velocity, hit.normal);
            Velocity = projectedVelocity.normalized * Velocity.magnitude;
            break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * ColliderExtents.y, colliderSize);
    }
}