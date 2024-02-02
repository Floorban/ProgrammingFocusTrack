using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AirDrop : MonoBehaviour, IInteractable
    {
        [SerializeField] bool canOpen;
        [SerializeField] PlayerCharacterController playerCharacterController;
        [SerializeField] List<Loot> lootList = new List<Loot>();

        private void Start()
        {
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        }
        private void Update()
        {
            canOpen = playerCharacterController.coinNum >= 1; 
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
         void InstantiateLoot(Vector3 spawnPosition)
        {
            Loot droppedItem = GetDroppedItem();
            if (droppedItem != null && droppedItem.lootPrefab != null)
            {
                GameObject lootGameObject = Instantiate(droppedItem.lootPrefab, spawnPosition, Quaternion.identity);
            }
        }
        public void Interact()
        {
            if (canOpen)
            {
                Vector3 position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                InstantiateLoot(position);

                playerCharacterController.coinNum--;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Not enough level to open the airdrop!");
            }
        }
    }
}

