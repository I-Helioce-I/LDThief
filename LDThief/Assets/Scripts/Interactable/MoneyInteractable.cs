using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    [SerializeField] int amount;

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        Inventory inventory = playerInteract.GetComponent<Inventory>();
        inventory.AddMoney(amount);
        inventory.playerInventoryUI.UpdateMoneyAmount();
        
        Destroy(gameObject);
    }
}
