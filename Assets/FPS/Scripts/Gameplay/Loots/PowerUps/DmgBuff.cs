using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/DmgBuff")]
public class DmgBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<ProjectileStandard>().Damage += amount;
    }
}
