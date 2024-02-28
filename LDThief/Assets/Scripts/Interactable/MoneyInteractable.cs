using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;

    public string GetInteractText()
    {
        Debug.Log("Detected");
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        Destroy(gameObject);
    }
}
