using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.AI
{
    [CreateAssetMenu(menuName = "Abilities/Freeze")]
    public class Freeze : Ability
    {
        //public UnityAction onFreeze;

        [Header("SphereCast Range")]
        [SerializeField] float radius, maxDistance;

        [Header("SphereCast Layer")]
        [SerializeField] LayerMask layerMask;
        public override void Activate(GameObject player)
        {
            //EventManager.Broadcast(new FreezeEnemyEvent());
            //onFreeze.Invoke();
            Collider[] colliders = Physics.OverlapSphere(player.transform.position, radius, layerMask);
            foreach (Collider col in colliders)
            {
                col.gameObject.GetComponent<EnemyMobile>().OnFreeze();
            }
        }
    }

}
