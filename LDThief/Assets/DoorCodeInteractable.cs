using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCodeInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    [SerializeField] DoorMinigameUI minigameUI;
    [SerializeField] string theGoodCode;
    [SerializeField] GameObject gameObjectDisaperaingOnUnlock;
    public bool isUnlock = false;


    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        FirstPersonController fps = playerInteract.GetComponent<FirstPersonController>();

        if (minigameUI.IsCodeActive == true)
        {
            fps.enabled = true;
            minigameUI.HideCode();
        }
        else
        {
            fps.enabled = false;
            minigameUI.CodeToInput = theGoodCode;
            minigameUI.ShowCode(fps);
            minigameUI.doorCodeInteractable = this;
        }
    }

    private void Update()
    {
        if (gameObjectDisaperaingOnUnlock != null)
        {

            if (isUnlock && gameObjectDisaperaingOnUnlock.activeSelf)
            {
                gameObjectDisaperaingOnUnlock.SetActive(false);

            }
        }
    }
}
