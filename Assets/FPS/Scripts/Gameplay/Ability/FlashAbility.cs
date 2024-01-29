using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Flash")]
    public class FlashAbility : Ability
    {
        [SerializeField] float flashVelocity;
        public override void Activate(GameObject player)
        {
            PlayerCharacterController playerController = player.GetComponent<PlayerCharacterController>();
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = flashVelocity * playerController.CharacterVelocity.normalized;
        }
    }
}

