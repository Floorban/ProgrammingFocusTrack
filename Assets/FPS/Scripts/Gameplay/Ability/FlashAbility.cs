using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Flash")]
public class FlashAbility : Ability
{
    [SerializeField] float flashDistance;
    public override void Activate(GameObject player)
    {
        Vector3 forwardDirection = player.transform.forward;
        Vector3 newPosition = player.transform.position + forwardDirection * flashDistance;
        player.transform.position = newPosition;
    }
}
