using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    [CreateAssetMenu(menuName = "Abilities/Freeze")]
    public class Freeze : Ability
    {
        [SerializeField] float radius;
        public override void Activate(GameObject player)
        {
            Debug.Log("333");
        }
    }

}