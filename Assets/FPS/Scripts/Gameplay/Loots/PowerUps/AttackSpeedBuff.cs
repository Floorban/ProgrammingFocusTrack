using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AttackSpeedBuff")]
public class AttackSpeedBuff : WeaponPowerupEffect
{
    public float amount;
    public override void ApplyWeapon(WeaponController weapon)
    {
        weapon.DelayBetweenShots -= amount;
    }
}
