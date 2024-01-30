using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AbilityManager : MonoBehaviour
    {
        public Ability[] abilities;
        [SerializeField] float[] activeTimes;
        [SerializeField] float[] cooldownTimes;
        [SerializeField] KeyCode[] abilityKeys;
        enum State
        {
            ready,
            activated,
            cooldown
        }
        [SerializeField] State[] states;
        void Start()
        {
            activeTimes = new float[abilities.Length];
            cooldownTimes = new float[abilities.Length];
            states = new State[abilities.Length];
        }
        void Update()
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                switch (states[i])
                {
                    case State.ready:
                        if (Input.GetKeyDown(abilityKeys[i]))
                        {
                            abilities[i].Activate(gameObject);
                            states[i] = State.activated;
                            activeTimes[i] = abilities[i].activeTime;
                        }
                        break;
                    case State.activated:
                        if (activeTimes[i] > 0)
                        {
                            activeTimes[i] -= Time.deltaTime;
                        }
                        else
                        {
                            states[i] = State.cooldown;
                            cooldownTimes[i] = abilities[i].cooldownTime;
                        }
                        break;
                    case State.cooldown:
                        if (cooldownTimes[i] > 0)
                        {
                            cooldownTimes[i] -= Time.deltaTime;
                        }
                        else
                        {
                            states[i] = State.ready;
                        }
                        break;
                }
            }
        }
    }
}

