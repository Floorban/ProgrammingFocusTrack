using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float healAmount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<Health>().CurrentHealth += healAmount;
    }
}
