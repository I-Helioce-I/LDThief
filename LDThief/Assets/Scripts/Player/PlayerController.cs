using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum PlayerActions
{
    Normal,
    Map
}

public class PlayerController : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private PlayerInteract playerInteract;
    [SerializeField] private PlayerMapUI playerMapUI;
    private FirstPersonController firstPersonController;
    Inventory inventory;

    [SerializeField] List<Image> imagesHealthBar;
    [SerializeField] TextMeshProUGUI deathText;

    private PlayerActions playerActions = PlayerActions.Normal;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        _input = GetComponent<StarterAssetsInputs>();
        playerInteract = GetComponent<PlayerInteract>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        OnInteract();
        OnMap();
        OnInventory();
    }

    private void OnInteract()
    {
        if (_input.interact)
        {
            playerInteract.InteractInput();
            _input.interact = false;
        }
    }

    public void OnMap()
    {
        if (_input.map)
        {
            if (playerActions == PlayerActions.Normal)
            {
                playerMapUI.ShowMap();
                _input.map = false;
                playerActions = PlayerActions.Map;
                firstPersonController.enabled = false;

            }
            else if (playerActions == PlayerActions.Map)
            {
                playerMapUI.HideMap();
                _input.map = false;
                playerActions = PlayerActions.Normal;
                firstPersonController.enabled = true;

            }
        }
    }

    public void RemoveHealth()
    {
        int maxHearth = imagesHealthBar.Count;
        Debug.Log("remove" + maxHearth);

        if (imagesHealthBar.Count > 0)
        {
            Destroy(imagesHealthBar[maxHearth - 1]);
            imagesHealthBar.Remove(imagesHealthBar[maxHearth - 1]);
        }
        else
        {
            deathText.gameObject.SetActive(true);
            return;
        }

        if(imagesHealthBar.Count <= 0)
        {
            deathText.gameObject.SetActive(true);

        }

    }
     
    public void OnInventory()
    {
        if (_input.inventory && !inventory.playerInventoryUI.IsInventoryOpen)
        {
            inventory.playerInventoryUI.Show();
            _input.inventory = false;

        }
        else if (_input.inventory && inventory.playerInventoryUI.IsInventoryOpen)
        {
            _input.inventory = false;
        }
    }

}
