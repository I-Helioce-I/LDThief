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
    bool IsInventoryContainerIsOpen;

    public bool IsInventoryOpen { get; private set; }

    private void Start()
    {
        Show();
    }

    public void Show()
    {

        StopCoroutine(CloseCoroutineInventory());
        inventoryContainerUI.SetActive(true);
        IsInventoryContainerIsOpen = true;
        StartCoroutine(CloseCoroutineInventory());
    }

    public void OpenUI()
    {
        inventoryContainerUI.SetActive(true);
    }

    public void Hide()
    {
        inventoryContainerUI.SetActive(false);
        IsInventoryContainerIsOpen = false; ;
    }

    public void UpdateMoneyAmount()
    {
        moneyAmount.text = inventory.Money.ToString();
        Show();
    }

    public void UpdateGoldIngotAmount()
    {
        goldIngotAmount.text = string.Concat(inventory.GoldIngot.ToString() + " / " + inventory.MaxGoldIngot.ToString());
        Show();
    }

    public void ShowMaxIngotMessage()
    {
        StopCoroutine(CloseCoroutineMaxIngotCapacity());
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
