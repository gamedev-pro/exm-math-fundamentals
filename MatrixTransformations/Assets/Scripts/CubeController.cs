using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformComponent))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;

    private TransformComponent transformComponent;

    private void Awake()
    {
        transformComponent = GetComponent<TransformComponent>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var frameMovement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transformComponent.Position += frameMovement;
    }
}
