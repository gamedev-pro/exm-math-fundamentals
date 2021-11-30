using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformComponent))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float acceleration = 10;

    private TransformComponent transformComponent;
    private Vector3 Velocity;

    private void Awake()
    {
        transformComponent = GetComponent<TransformComponent>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var targetVelocity = new Vector3(horizontal, 0, vertical) * moveSpeed;

        Velocity = Vector3.Lerp(Velocity, targetVelocity, acceleration * Time.deltaTime);

        var frameMovement = Velocity * Time.deltaTime;
        transformComponent.Position += frameMovement;
        if (Velocity != Vector3.zero)
        {
            transformComponent.Forward = Velocity;
        }
    }
}
