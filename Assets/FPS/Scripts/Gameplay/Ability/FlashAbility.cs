using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Flash")]
    public class FlashAbility : Ability
    {
        [SerializeField] float flashDistance;
        public override void Activate(GameObject player)
        {
            PlayerCharacterController playerController = player.GetComponent<PlayerCharacterController>();
            playerController.flashDistance = flashDistance;
            //playerController.Flash();
        }
    }
}

