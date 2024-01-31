using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.FPS.AI;

namespace Unity.FPS.UI
{
    public class AbilityManager : MonoBehaviour
    {
        public Ability[] abilities;
        [SerializeField] float[] activeTimes;
        [SerializeField] float[] cooldownTimes;
        [SerializeField] KeyCode[] abilityKeys;
        [SerializeField] InGameMenuManager menuManager;
        [SerializeField] GameObject player;
        enum State
        {
            ready,
            activated,
            cooldown
        }
        [SerializeField] State[] states;
        [SerializeField] bool[] canUsed;
        [SerializeField] Button[] buttons;
        [SerializeField] GameObject buttonPrefab;
        void Start()
        {
            menuManager = FindObjectOfType<InGameMenuManager>();
            activeTimes = new float[abilities.Length];
            cooldownTimes = new float[abilities.Length];
            states = new State[abilities.Length];
              
            canUsed = new bool[3];
            buttons = new Button[3];
            for (int i = 0; i < abilities.Length; i++)
            {
                GameObject buttonObject = Instantiate(buttonPrefab, transform);
                buttonObject.transform.parent = transform;
                buttons[i] = buttonObject.GetComponent<Button>();
                int closureIndex = i;
                buttons[closureIndex].onClick.AddListener(() => EnableAbility(closureIndex));
            }
        }
        void Update()
        {
            HandleAbilityStateSwitch();
        }
        public void EnableAbility(int buttonIndex)
        {
            canUsed[buttonIndex] = true;
            menuManager.ClosePauseMenu();
        }
        void HandleAbilityStateSwitch()
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                if (canUsed[i])
                {
                    switch (states[i])
                    {
                        case State.ready:
                            if (Input.GetKeyDown(abilityKeys[i]))
                            {
                                abilities[i].Activate(player);
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
}

