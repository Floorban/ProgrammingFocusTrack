using UnityEngine;
using Unity.FPS.Gameplay;

[CreateAssetMenu(menuName = "PowerUps/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerCharacterController>().MaxSpeedOnGround += amount;
    }
}