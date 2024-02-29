using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class GoldIngotInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    string textOut;
    [SerializeField] int amount;

    private void Start()
    {

    }

    public string GetInteractText()
    {
        textOut = string.Concat(interactText + " " + amount.ToString());
        return textOut;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        Inventory inventory = playerInteract.GetComponent<Inventory>();
        if (inventory.IsMaxIngotReached())
        {
            return;

        }
        else if (!inventory.IsMaxIngotReached())
        {
            int possibleIngot = inventory.MaxGoldIngot - inventory.GoldIngot;

            if (amount <= possibleIngot)
            {

                inventory.AddGoldIngot(amount);
                inventory.playerInventoryUI.UpdateGoldIngotAmount();
                Destroy(gameObject);

            }
            else if (amount > possibleIngot)
            {
                int ingotIn = amount - possibleIngot;
                amount -= ingotIn;

                inventory.AddGoldIngot(ingotIn);
                inventory.playerInventoryUI.UpdateGoldIngotAmount();

            }

        }
    }
}
