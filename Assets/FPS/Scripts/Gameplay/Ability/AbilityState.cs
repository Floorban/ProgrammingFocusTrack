using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AbilityState : MonoBehaviour
    {
        public Ability ability;
        float activeTime, cooldownTime;
        [SerializeField] KeyCode abilityKey;
        enum State
        {
            ready,
            activated,
            cooldown
        }
        State state = State.ready;
        void Update()
        {
            switch (state)
            {
                case State.ready:
                    if (Input.GetKeyDown(abilityKey))
                    {
                        ability.Activate(gameObject);
                        state = State.activated;
                        activeTime = ability.activeTime;
                    }
                    break;
                case State.activated:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = State.cooldown;
                        cooldownTime = ability.cooldownTime;
                    }
                    break;
                case State.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = State.ready;
                    }
                    break;
            }
        }
    }
}

