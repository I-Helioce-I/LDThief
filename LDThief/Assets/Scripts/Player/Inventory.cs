using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int money = 0;
    [SerializeField] int goldIngot = 0;
    [SerializeField] int maxGoldIngot = 10;
    PlayerController playerController;
    public PlayerInventoryUI playerInventoryUI;

    public int Money {  get { return money; } set { money = value; } }
    public int GoldIngot {  get { return goldIngot; } set { goldIngot = value; } }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }   

    public void AddMoney(int moneyIn)
    {
        money += moneyIn;
    }
    public void AddGoldIngot(int goldIngotIn)
    {
        goldIngot += goldIngotIn;
    }

    public bool IsMaxIngotReached(int ingotIn)
    {
        if(goldIngot >= maxGoldIngot)
        {
            playerInventoryUI.ShowMaxIngotMessage();
            return true;
        }

        
        return false;
        return true;
    }
}
