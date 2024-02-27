using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private PlayerInteract playerInteract;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void Update()
    {
        OnInteract();
    }

    private void OnInteract()
    {
        if (_input.interact)
        {
            playerInteract.InteractInput();
            _input.interact = false;
        }
    }
}
