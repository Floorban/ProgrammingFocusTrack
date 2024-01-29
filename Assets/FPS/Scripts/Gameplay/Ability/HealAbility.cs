using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Heal")]
    public class HealAbility : Ability
    {
        [SerializeField] float healAmount;
        public override void Activate(GameObject player)
        {
            Health health = player.GetComponent<Health>();
            health.CurrentHealth += healAmount;
        }
    }
}
