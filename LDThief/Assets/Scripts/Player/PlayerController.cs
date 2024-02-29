using UnityEngine;


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
        if( _input.map)
        {
            if (playerActions == PlayerActions.Normal)
            {
                playerMapUI.ShowMap();
                _input.map = false;
                playerActions = PlayerActions.Map;
                firstPersonController.enabled = false;

            }
            else if(playerActions == PlayerActions.Map)
            {
                playerMapUI.HideMap();
                _input.map = false;
                playerActions = PlayerActions.Normal;
                firstPersonController.enabled = true;

            }
        }
    }

    public void OnInventory()
    {
        if (_input.inventory && !inventory.playerInventoryUI.IsInventoryOpen)
        {
            inventory.playerInventoryUI.Show();
            _input.inventory = false;
            
        }
        else if(_input.inventory && inventory.playerInventoryUI.IsInventoryOpen)
        {
            _input.inventory = false;
        }
    }

}
