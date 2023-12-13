using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ReloadDurationBuff")]
public class ReloadDurationBuff : WeaponPowerupEffect
{
    public float amount;
    public override void ApplyWeapon(WeaponController weapon)
    {
        weapon.AmmoReloadDelay -= amount;
    }
}
