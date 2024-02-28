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

    private PlayerActions playerActions = PlayerActions.Normal;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        playerInteract = GetComponent<PlayerInteract>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        OnInteract();
        OnMap();
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


}
