using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ReloadDurationBuff")]
public class ReloadDurationBuff : WeaponPowerupEffect
{
    public float amount;
    public override void ApplyWeapon(GameObject weapon)
    {
        weapon.GetComponent<WeaponController>().AmmoReloadDelay -= amount;
    }
}
