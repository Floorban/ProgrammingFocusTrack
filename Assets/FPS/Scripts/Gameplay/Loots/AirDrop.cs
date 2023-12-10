using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;
using Unity.FPS.Game;

public class AirDrop : MonoBehaviour, IInteractable
{
    public List<AirDropSlot> slotList = new List<AirDropSlot>();
    [SerializeField]
    private bool canOpen;
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private bool isPickup;
    public int requiredLevel = 3;

    private void OnEnable()
    {
        Pickup.OnPickup += HandlePickup;
        PlayerCharacterController.OnLevelCompare += HandleUnlock;
    }

    private void OnDisable()
    {
        Pickup.OnPickup -= HandlePickup;
        PlayerCharacterController.OnLevelCompare -= HandleUnlock;
    }

    private void HandlePickup()
    {
        isPickup = true;
    }
    private void HandleUnlock(int amount)
    {
        canOpen = amount >= requiredLevel;
    }
    private void Update()
    {
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
            isOpen = true;
        }
        else
        {
            Debug.Log("Not enough level to open the airdrop!");
        }
    }

}
