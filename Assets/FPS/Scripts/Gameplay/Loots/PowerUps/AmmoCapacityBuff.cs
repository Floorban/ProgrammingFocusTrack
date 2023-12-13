using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AmmoCapacityBuff")]
public class AmmoCapacityBuff: WeaponPowerupEffect
{
    public int amount;
    public override void ApplyWeapon(GameObject weapon)
    {
        weapon.GetComponent<WeaponController>().MaxAmmo += amount;
    }
}
