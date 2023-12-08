using Unity.FPS.Gameplay;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ExpBuff")]
public class ExpBuff : PowerUpEffect
{
    public int expAmount;
    public override void Apply(GameObject player)
    {
        //player.GetComponent<PlayerCharacterController>().CurrentExperience += expAmount;
        ExperienceManager.instance.IncreaseExperience(expAmount);
    }
}
