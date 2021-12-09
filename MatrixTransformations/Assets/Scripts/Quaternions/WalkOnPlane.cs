using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnPlane : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        const float rayDistance = 100;
        if (Physics.Raycast(transform.position, -transform.up, out var hit, rayDistance))
        {
            var targetRot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            transform.rotation = targetRot;
            transform.position = hit.point + hit.normal * hit.distance;
        }

        //v = a*w + b*t
        var inputDir = transform.right * horizontal + transform.forward * vertical;
        var frameMovement = inputDir * moveSpeed * Time.deltaTime;
        transform.position += frameMovement;
    }
}
