using Unity.FPS.Game;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ReloadDurationBuff")]
public class ReloadDurationBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<WeaponController>().AmmoReloadDelay -= amount;
    }
}
