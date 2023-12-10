using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class AirDrop : MonoBehaviour, IInteractable
    {
        public List<AirDropSlot> slotList = new List<AirDropSlot>();
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
            canOpen = playerCharacterController.OpenCounter >= 1;
            if (isOpen && isPickup)
            {
                Destroy(gameObject);
            }
        }

        public void Interact()
        {
            if (canOpen)
            {
                foreach (AirDropSlot slot in slotList)
                {
                    slot.InstantiateLoot(slot.transform.position);
                }
                playerCharacterController.OpenCounter--;
                isOpen = true;
            }
            else
            {
                Debug.Log("Not enough level to open the airdrop!");
            }
        }
    }
}

