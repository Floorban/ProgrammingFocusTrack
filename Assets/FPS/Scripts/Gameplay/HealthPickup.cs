using Unity.FPS.Game;

namespace Unity.FPS.Gameplay
{
    public class HealthPickup : Pickup
    {
        //[Header("Parameters")] [Tooltip("Amount of health to heal on pickup")]
        //public float HealAmount;

        public PowerUpEffect powerUpEffect;
        protected override void OnPicked(PlayerCharacterController player)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth && playerHealth.CanPickup())
            {
                //playerHealth.Heal(HealAmount);
                powerUpEffect.Apply(player.gameObject);
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }

    }
}