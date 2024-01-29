using UnityEngine;
using Unity.FPS.Gameplay;
using System.Collections.Generic;

namespace Unity.FPS.UI
{
    public class UpgradePanelManager : MonoBehaviour
    {
        [SerializeField] GameObject panel;
        public List<Loot> lootList = new List<Loot>();
        public Transform canvas;

        private List<GameObject> spawnedLootObjects = new List<GameObject>();
        public void OpenPanel()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Vector3 position = new Vector3( 680f, 440f, 0);
            Vector3 position2 = new Vector3(780f, 440f, 0);
            Vector3 position3 = new Vector3(880f, 440f, 0);
            InstantiateLoot(position);
            InstantiateLoot(position2);
            InstantiateLoot(position3);

        }
        public void ClosePanel()
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            foreach (GameObject lootObject in spawnedLootObjects)
            {
                Destroy(lootObject);
            }

            spawnedLootObjects.Clear();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
        }
        Loot GetDroppedItem()
        {
            int randomNumber = Random.Range(1, 101);
            List<Loot> possibleItems = new List<Loot>();
            foreach (Loot item in lootList)
            {
                if (randomNumber <= item.dropChance)
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
        public void InstantiateLoot(Vector3 spawnPosition)
        {
            Loot droppedItem = GetDroppedItem();
            if (droppedItem != null && droppedItem.lootPrefab != null)
            {
                GameObject lootGameObject = Instantiate(droppedItem.lootPrefab, spawnPosition, Quaternion.identity);
                lootGameObject.transform.parent = canvas.transform;

                spawnedLootObjects.Add(lootGameObject);

            }
        }
    }

}
