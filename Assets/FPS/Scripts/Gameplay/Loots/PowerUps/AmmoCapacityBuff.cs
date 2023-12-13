using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AmmoCapacityBuff")]
public class AmmoCapacityBuff: WeaponPowerupEffect
{
    public int amount;
    public override void ApplyWeapon(WeaponController weapon)
    {
        weapon.MaxAmmo += amount;
    }
}
