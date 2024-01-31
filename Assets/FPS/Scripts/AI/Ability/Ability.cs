using Unity.FPS.Gameplay;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class Ability : ScriptableObject
    {
        public string abilityName;
        public float activeTime;
        public float cooldownTime;
        public virtual void Activate(GameObject player)
        {

        }
    }

}