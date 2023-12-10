using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class AirDrop : MonoBehaviour, IInteractable
{
    public List<AirDropSlot> slotList = new List<AirDropSlot>();
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private bool isPickup;
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
    private void Update()
    {
        if (isOpen && isPickup)
        {
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        foreach (AirDropSlot slot in slotList)
        {
            slot.InstantiateLoot(slot.transform.position);
        }
        isOpen = true;
    }
}
