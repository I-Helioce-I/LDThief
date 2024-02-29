using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject maxIngotContainer;
    

    [SerializeField] GameObject inventoryContainerUI;
    [SerializeField] TextMeshProUGUI moneyAmount;
    [SerializeField] TextMeshProUGUI goldIngotAmount;
    [SerializeField] Inventory inventory;

    private void Start()
    {
        Show();
    }

    public void Show()
    {
        inventoryContainerUI.SetActive(true);
        StartCoroutine(CloseCoroutineInventory());
    }

    public void OpenUI()
    {
        inventoryContainerUI.SetActive(true);
    }

    public void Hide()
    {
        inventoryContainerUI.SetActive(false);
    }

    public void UpdateMoneyAmount()
    {
        moneyAmount.text = inventory.Money.ToString();
        Show();
    }
     
    public void UpdateGoldIngotAmount()
    {
        goldIngotAmount.text = inventory.GoldIngot.ToString();
        Show();

    }

    public void ShowMaxIngotMessage()
    {
        maxIngotContainer.SetActive(true);
        StartCoroutine(CloseCoroutineMaxIngotCapacity());
    }

    public void HideMaxIngotMessage()
    {
        maxIngotContainer.SetActive(false);
    }

    public IEnumerator CloseCoroutineInventory()
    {
        yield return new WaitForSeconds(3f);
        Hide();
        
    }

    public IEnumerator CloseCoroutineMaxIngotCapacity()
    {
        yield return new WaitForSeconds(3f);
        HideMaxIngotMessage();

    }


}
