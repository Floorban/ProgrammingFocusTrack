using UnityEngine;
using UnityEngine.UI;
using Unity.FPS.AI;
using Unity.FPS.Gameplay;
using UnityEngine.Events;

namespace Unity.FPS.UI
{
    public class AbilityManager : MonoBehaviour
    {
        public Ability[] abilities;
        [SerializeField] float[] activeTimes;
        [SerializeField] float[] cooldownTimes;
        [SerializeField] KeyCode[] abilityKeys;
        [SerializeField] InGameMenuManager menuManager;
        [SerializeField] GameObject abilityPanel;
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
        [SerializeField] PlayerCharacterController player;
        [SerializeField] string[] abilityNames;
        [SerializeField] int[] buyPrices;
        public UnityAction<string> OnUnlockPowerUp;
        void Start()
        {
            abilityNames = new string[3];
            abilityNames[0] = "Self-Heal Unlocked";
            abilityNames[1] = "Flash Unlocked";
            abilityNames[2] = "Freeze Skill Unlocked";

            player = FindObjectOfType<PlayerCharacterController>();
            menuManager = FindObjectOfType<InGameMenuManager>();
            activeTimes = new float[abilities.Length];
            cooldownTimes = new float[abilities.Length];
            states = new State[abilities.Length];
              
            canUsed = new bool[3];
            buttons = new Button[3];
            for (int i = 0; i < abilities.Length; i++)
            {
                GameObject buttonObject = Instantiate(buttonPrefab, transform);
                buttonObject.transform.parent = abilityPanel.transform;
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
            if (player.coinNum < buyPrices[buttonIndex])
            {
                OnUnlockPowerUp.Invoke($"Need {buyPrices[buttonIndex] - player.coinNum} more coins");
            }else
            {
                player.coinNum -= buyPrices[buttonIndex];
                canUsed[buttonIndex] = true;
                OnUnlockPowerUp.Invoke(abilityNames[buttonIndex]);
                buttons[buttonIndex].image.color = Color.red;
                buttons[buttonIndex].enabled = false;
            }
            menuManager.SetPauseMenuActivation(abilityPanel, !abilityPanel.activeSelf);
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
}

