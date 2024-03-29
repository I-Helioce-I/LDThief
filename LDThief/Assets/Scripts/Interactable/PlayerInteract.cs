using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerInteract : MonoBehaviour
{

    public PlayerInteractUI playerInteractUI;


    public void InteractInput()
    {
        IInteractable interactable = GetInteractableObject();
        if (interactable != null)
        {
            Debug.Log("Detected");

            interactable.Interact(this);
        }

    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> _interactableList = new List<IInteractable>();
        float _interactRange = 2f;
        Collider[] _collidersArray = Physics.OverlapSphere(transform.position, _interactRange);

        foreach (Collider collider in _collidersArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                _interactableList.Add(interactable);
                Debug.Log("Detected");

            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in _interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}