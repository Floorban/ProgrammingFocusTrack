using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AttackSpeedBuff")]
public class AttackSpeedBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<WeaponController>().DelayBetweenShots += amount;
    }
}
