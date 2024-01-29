using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ExpPickUp : Pickup
    {
        [SerializeField] float expAmount;
        protected override void OnPicked(PlayerCharacterController player)
        {
            if (player != null)
            {
                player.HandleExperienceChange(expAmount);
                //PlayPickupFeedback();
            }
            base.OnPicked(player);
            Destroy(gameObject);
        }
    }

}