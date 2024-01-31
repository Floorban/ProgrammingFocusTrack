using UnityEngine;

namespace Unity.FPS.AI
{
    [CreateAssetMenu(menuName = "Abilities/Flash")]
    public class FlashAbility : Ability
    {
        [SerializeField] float flashDistance, flashDuration;
        public override void Activate(GameObject player)
        {
            CharacterController characterController = player.GetComponent<CharacterController>();

            Vector3 moveDirection = player.transform.forward * flashDistance;
            characterController.Move(moveDirection * Time.deltaTime * flashDuration);
        }
    }
}

