using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
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
        CloseCombat();

    }

    private void CloseCombat()
    {
        if (_input.attack)
        {
            Debug.Log("Attack");
            _input.attack = false;
        }
    }
}
