using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
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