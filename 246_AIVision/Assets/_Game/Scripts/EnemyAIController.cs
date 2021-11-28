using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(TopdownFOV))]
public class EnemyAIController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private CharacterMovement characterMovement;
    private TopdownFOV fOV;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        fOV = GetComponent<TopdownFOV>();
    }

    private void Update()
    {
        if (fOV.CanSeeTarget(player?.transform))
        {
            var toPlayer = (player.transform.position - transform.position).normalized;
            characterMovement.SetInput(toPlayer.x, toPlayer.z);
        }
        else
        {
            characterMovement.SetInput(0, 0);
        }
    }
}
