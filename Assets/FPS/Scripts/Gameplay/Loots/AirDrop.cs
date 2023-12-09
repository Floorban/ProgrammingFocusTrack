using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class AirDrop : MonoBehaviour
{
    public List<AirDropSlot> slotList = new List<AirDropSlot>();
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private bool isPickup;
    private void OnEnable()
    {
        foreach (AirDropSlot slot in slotList)
        {
            slot.OnPickupChange += HandlePickup;
        }
    }

    private void OnDisable()
    {
        foreach (AirDropSlot slot in slotList)
        {
            slot.OnPickupChange -= HandlePickup;
        }
    }
    private void HandlePickup()
    {
        isPickup = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isOpen)
        {
            foreach (AirDropSlot slot in slotList)
            {
                slot.InstantiateLoot(slot.transform.position);
            }
            isOpen = true;
        }

        if (isOpen && isPickup)
        {
            Destroy(gameObject);
        }
    }
}