using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AbilityManager : MonoBehaviour
    {
        public Ability[] abilities;
        float activeTime, cooldownTime;
        [SerializeField] KeyCode[] abilityKeys;
        enum State
        {
            ready,
            activated,
            cooldown
        }
        State state = State.ready;
        void Update()
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                switch (state)
                {
                    case State.ready:
                        if (Input.GetKeyDown(abilityKeys[i]))
                        {
                            abilities[i].Activate(gameObject);
                            state = State.activated;
                            activeTime = abilities[i].activeTime;
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
                            cooldownTime = abilities[i].cooldownTime;
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
}

