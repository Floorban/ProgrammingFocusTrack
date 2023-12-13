using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AttackSpeedBuff")]
public class AttackSpeedBuff : WeaponPowerupEffect
{
    public float amount;
    public override void ApplyWeapon(GameObject weapon)
    {
        weapon.GetComponent<WeaponController>().DelayBetweenShots -= amount;
    }
}
