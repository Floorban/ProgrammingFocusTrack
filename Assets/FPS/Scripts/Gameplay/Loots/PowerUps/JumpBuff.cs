using UnityEngine;
using Unity.FPS.Gameplay;

[CreateAssetMenu(menuName = "PowerUps/JumpBuff")]
public class JumpBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerCharacterController>().JumpForce += amount;
    }
}
