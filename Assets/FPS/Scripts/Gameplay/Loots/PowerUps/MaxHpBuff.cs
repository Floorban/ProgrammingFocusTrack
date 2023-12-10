using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/MaxHpBuff")]
public class MaxHpBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<Health>().MaxHealth += amount;
    }
}
