using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldIngotInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    string textOut;
    [SerializeField] int amount;

    private void Start()
    {
        textOut = interactText + amount.ToString();

    }

    public string GetInteractText()
    {
        return textOut;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        Inventory inventory = playerInteract.GetComponent<Inventory>();
        if (inventory.IsMaxIngotReached(amount))
        {
            return;

        }
        else if (!inventory.IsMaxIngotReached(amount))
        {

            inventory.AddGoldIngot(amount);
            inventory.playerInventoryUI.UpdateGoldIngotAmount();

            Destroy(gameObject);
        }
    }
}
