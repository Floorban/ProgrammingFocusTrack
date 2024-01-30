using System.Collections;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Flash")]
    public class FlashAbility : Ability
    {
        [SerializeField] float flashDistance, flashSpeed;
        public override void Activate(GameObject player)
        {
            CharacterController characterController = player.GetComponent<CharacterController>();

            Vector3 moveDirection = player.transform.forward * flashDistance;
            characterController.Move(moveDirection * Time.deltaTime * flashSpeed);
        }
    }
}

