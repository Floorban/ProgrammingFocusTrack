using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.AI
{
    [CreateAssetMenu(menuName = "Abilities/Freeze")]
    public class Freeze : Ability
    {
        public UnityAction onFreeze;
        public float freezingTime;

        [Header("SphereCast")]
        public float radius, maxDistance;
        public LayerMask layerMask;
        public override void Activate(GameObject player)
        {
            //EventManager.Broadcast(new FreezeEnemyEvent());
            Collider[] colliders = Physics.OverlapSphere(player.transform.position, radius, layerMask);
            foreach (Collider col in colliders)
            {
                col.gameObject.GetComponent<EnemyMobile>().OnFreeze();
                //onFreeze.Invoke();
            }
        }
    }

}
