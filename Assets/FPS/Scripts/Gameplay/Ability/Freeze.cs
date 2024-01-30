using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Freeze")]
    public class Freeze : Ability
    {
        public UnityAction onFreeze;
        public override void Activate(GameObject player)
        {
            //EventManager.Broadcast(new FreezeEnemyEvent());
            onFreeze.Invoke();
        }
    }

}
