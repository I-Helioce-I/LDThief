using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMapUI : MonoBehaviour
{
    [SerializeField] GameObject playerMapContainer;
    [SerializeField] Sprite imageToDisplay;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        HideMap();
    }

    public void ShowMap()
    {
        playerMapContainer.SetActive(true);
    }

    public void HideMap()
    {
        playerMapContainer.SetActive(false);

    }
}
