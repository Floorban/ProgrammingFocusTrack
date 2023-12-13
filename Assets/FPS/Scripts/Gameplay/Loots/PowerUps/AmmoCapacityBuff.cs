using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AmmoCapacityBuff")]
public class AmmoCapacityBuff: PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<WeaponController>().MaxAmmo += amount;
    }
}
