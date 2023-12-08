using Unity.FPS.Game;

namespace Unity.FPS.Gameplay
{
    public class ExpPickUp : Pickup
    {
        public PowerUpEffect powerUpEffect;
        protected override void OnPicked(PlayerCharacterController player)
        {
            if (player != null)
            {
                powerUpEffect.Apply(player.gameObject);
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }
    }

}