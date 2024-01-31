using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.AI
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
        [SerializeField] bool[] canUsed;
        [SerializeField] Button[] buttons;
        [SerializeField] GameObject abilityPanel;
        void Start()
        {
            abilityPanel.SetActive(false);
            activeTimes = new float[abilities.Length];
            cooldownTimes = new float[abilities.Length];
            states = new State[abilities.Length];

            canUsed = new bool[3];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.AddListener(EnableAbility);
            }

        }
        void Update()
        {
            HandleAbilityStateSwitch();
            if (Input.GetKeyDown(KeyCode.T))
            {
                  abilityPanel.SetActive(!abilityPanel.activeSelf);
            }
        }
        public void EnableAbility()
        {
            for (int i = 0; i < canUsed.Length; i++)
            {
                canUsed[i] = true;
            }
        }
        void HandleAbilityStateSwitch()
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                if (!canUsed[i]) continue;
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

