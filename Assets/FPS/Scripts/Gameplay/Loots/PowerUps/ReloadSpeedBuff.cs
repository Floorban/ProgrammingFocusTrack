using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ReloadSpeedBuff")]
public class ReloadSpeedBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<WeaponController>().AmmoReloadRate += amount;
    }
}
