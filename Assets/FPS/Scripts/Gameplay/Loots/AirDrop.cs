using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AirDrop : MonoBehaviour, IInteractable
    {
        //public List<AirDropSlot> slotList = new List<AirDropSlot>();
        [SerializeField]
        private bool canOpen;
        [SerializeField]
        private bool isOpen;
        [SerializeField]
        private bool isPickup;
        [SerializeField]
        public PlayerCharacterController playerCharacterController;
        private void OnEnable()
        {
            Pickup.OnPickup += HandlePickup;
        }

        private void OnDisable()
        {
            Pickup.OnPickup -= HandlePickup;
        }

        private void HandlePickup()
        {
            isPickup = true;
        }

        private void Start()
        {
            playerCharacterController = FindObjectOfType<PlayerCharacterController>();

        }

        private void Update()
        {
            canOpen = playerCharacterController.openCounter >= 1; 
            if (isOpen && isPickup)
            {
                Destroy(gameObject);
            }
        }
        public List<Loot> lootList = new List<Loot>();

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
                lootGameObject.transform.parent = transform;

            }
        }
        public void Interact()
        {
            if (canOpen)
            {
                Vector3 position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                InstantiateLoot(position);

                playerCharacterController.openCounter--;
                isOpen = true;
            }
            else
            {
                Debug.Log("Not enough level to open the airdrop!");
            }
        }
    }
}

