using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepotGoldIngotInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] Inventory inventory;
    [SerializeField] string text;
    string textOut;
    [SerializeField] int maxGoldPossible;
    [SerializeField] int goldIngotAlreadyIn;
    [SerializeField] GameObject mesh;

    private void Start()
    {
        mesh.SetActive(false);
    }


    public string GetInteractText()
    {
        int possibleGoldIngot = maxGoldPossible - goldIngotAlreadyIn;

        textOut = string.Concat(text + " " + possibleGoldIngot + " / " + maxGoldPossible.ToString());
        return textOut;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        int possibleGoldIngot = maxGoldPossible - goldIngotAlreadyIn;
        Inventory inventory = playerInteract.GetComponent<Inventory>();

        if (IsMaxIngotReached())
        {
            return;
        }
        


        if(inventory.GoldIngot > goldIngotAlreadyIn)
        {
            return;
        }
        else if (inventory.GoldIngot <= possibleGoldIngot)
        {
            goldIngotAlreadyIn += inventory.GoldIngot;
            inventory.GoldIngot = 0;

            if (mesh.activeSelf == false)
            {
                mesh.SetActive(true);
            }
        }
        else if (inventory.GoldIngot > possibleGoldIngot)
        {
            int goldIn = inventory.GoldIngot - possibleGoldIngot;

            goldIngotAlreadyIn += goldIn;
            inventory.GoldIngot -= goldIn;
                
            if (mesh.activeSelf == false)
            {
                mesh.SetActive(true);
            }
        }
        

        inventory.playerInventoryUI.UpdateGoldIngotAmount();


    }

    public bool IsMaxIngotReached()
    {
        if (goldIngotAlreadyIn >= maxGoldPossible)
        {
            return true;
        }

        return false;

    }


}
