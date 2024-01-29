using System.Collections;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Flash")]
    public class FlashAbility : Ability
    {
        public float dashTime, dashLength, dashSpeed;
        public override void Activate(GameObject player)
        {
            PlayerCharacterController playerController = player.GetComponent<PlayerCharacterController>();
            /*Rigidbody rb = player.GetComponent<Rigidbody>();
            Vector3 forceToApply = player.transform.forward * flashVelocity;
            playerController.enabled = false;
            rb.AddForce(forceToApply, ForceMode.Force);*/
            playerController.dashTime = dashTime;
            playerController.dashLength = dashLength;
            playerController.dashSpeed = dashSpeed;
            playerController.LesDash();
            
        }
    }
}

