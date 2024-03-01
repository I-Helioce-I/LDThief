using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorMinigameUI : MonoBehaviour
{
    [SerializeField] GameObject codeContainer;
    [SerializeField] public DoorCodeInteractable doorCodeInteractable;
    bool isActive;

    FirstPersonController fpsIn;

    [SerializeField] TextMeshProUGUI codeTextBox;

    string codeToInput;
    [SerializeField] string actualCode;

    public string CodeToInput { set { codeToInput = value; } }

    public bool IsCodeActive { get { return isActive; } }

    public void Start()
    {
        HideCode();
        codeTextBox.text = "XXXX";
    }

    public void ShowCode(FirstPersonController fps)
    {
        fpsIn = fps;

        fpsIn.enabled = false;

        codeContainer.SetActive(true);
        isActive = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCode()
    {
        if (fpsIn != null)
        {
            fpsIn.enabled = true;

        }
        codeContainer.SetActive(false);
        isActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    public void EnterCharaceter(string stringIn)
    {
        if (codeTextBox.text == "XXXX")
        {
            codeTextBox.text = stringIn;
        }
        else
        {
            codeTextBox.text += stringIn;
        }
    }

    public void CheckCode()
    {
        if (codeTextBox.text == codeToInput)
        {
            doorCodeInteractable.isUnlock = true;
            HideCode();
        }
        else
        {
            codeTextBox.text = "XXXX";
        }
    }

    public void CancelCode()
    {
        codeTextBox.text = "XXXX";
    }
}
