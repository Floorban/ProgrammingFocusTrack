using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;

namespace Unity.FPS.UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        [Header("Power-up data")]
        [SerializeField] List<Loot> lootList = new List<Loot>();
        [SerializeField] string[] powerUpNames;
        List<GameObject> spawnedLootObjects = new List<GameObject>();

        [Header("Level-up Panel")]
        [SerializeField] GameObject panel;

        InGameMenuManager menuManager;
        public UnityAction<string> OnUnlockPowerUp;
        private void Start()
        {
            menuManager = GetComponent<InGameMenuManager>();
            powerUpNames = new string[8];
            powerUpNames[0] = "MoveSpeed++";
            powerUpNames[1] = "JumpHeight++";
            powerUpNames[2] = "Damage++";
            powerUpNames[3] = "MaxHp++";
            powerUpNames[4] = "AttackSpeed++";
            powerUpNames[5] = "ReloadSpeed++";
            powerUpNames[6] = "ReloadDelay--";
            powerUpNames[7] = "AmmoCapacity++";

            EventManager.AddListener<LevelUpEvent>(OnLevelUpEvent);
            panel.SetActive(false);
        }
        void OnLevelUpEvent(LevelUpEvent evt)
        {
            menuManager.SetPauseMenuActivation(panel, true);
            InstantiateButtons(panel.transform, 3);
        }
        public void ClosePanel(int buttonID)
        {
            menuManager.SetPauseMenuActivation(panel, false);
            OnUnlockPowerUp.Invoke(powerUpNames[buttonID]);
            foreach (GameObject lootObject in spawnedLootObjects)
            {
                Destroy(lootObject);
            }
            spawnedLootObjects.Clear();
        }
        Loot GetDroppedItem(List<Loot> excludeList)
        {
            int randomNumber = Random.Range(1, 101);
            List<Loot> possibleItems = new List<Loot>();
            foreach (Loot item in lootList)
            {
                if (randomNumber <= item.dropChance && !excludeList.Contains(item))
                {
                    possibleItems.Add(item);
                }
            }
            if (possibleItems.Count > 0)
            {
                Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
                return droppedItem;
            }
            return null;
        }

        void InstantiateButtons(Transform parentTransform, int numberOfButtons)
        {
            List<Loot> excludeList = new List<Loot>();
            for (int i = 0; i < numberOfButtons; i++)
            {
                Loot droppedItem = GetDroppedItem(excludeList);
                if (droppedItem != null && droppedItem.lootPrefab != null)
                {
                    GameObject lootGameObject = Instantiate(droppedItem.lootPrefab, parentTransform);
                    lootGameObject.transform.parent = panel.transform;
                    spawnedLootObjects.Add(lootGameObject);
                    excludeList.Add(droppedItem);
                }
            }
        }
    }

}
