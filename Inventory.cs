using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int coinCount;
    public Text coinCountText;

    public List<Item> content = new List<Item>();
    public int currentContentIndex = 0;

    public Image itemImageUI;
    public Sprite emptyItemImage;
    public Text itemTextUI;

    public PlayerEffect playerEffect;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Inventory.");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        UpdateItemUI();
    }
    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Item currentItem = content[currentContentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpRestored);
        playerEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateItemUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        currentContentIndex++;
        if (currentContentIndex > content.Count - 1)
        {
            currentContentIndex = 0;
        }
        UpdateItemUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        currentContentIndex--;
        if (currentContentIndex < 0)
        {
            currentContentIndex = content.Count - 1;
        }
        UpdateItemUI();
    }

    public void UpdateItemUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[currentContentIndex].image;
            itemTextUI.text = content[currentContentIndex].itemName;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemTextUI.text = "";
        }
    }

    public void AddCoins(int count)
    {
        coinCount += count;
        UpdateCoinTextUI();
    }

    public void RemoveCoins(int count)
    {
        coinCount -= count;
        UpdateCoinTextUI();
    }

    public void UpdateCoinTextUI()
    {
        coinCountText.text = coinCount.ToString();
    }    
}
