using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ReloadSpeedBuff")]
public class ReloadSpeedBuff : WeaponPowerupEffect
{
    public float amount;
    public override void ApplyWeapon(WeaponController weapon)
    {
        weapon.GetComponent<WeaponController>().AmmoReloadRate += amount;
    }
}
