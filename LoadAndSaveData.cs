using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{
    Inventory inventory = Inventory.instance;

    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of LoadAndSaveData.");
            return;
        }
        instance = this;
    }
    void Start()
    {
        Inventory.instance.coinCount = PlayerPrefs.GetInt("coinCount", 0);
        Inventory.instance.UpdateCoinTextUI();

        /*int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/

        string[] itemsSaved = PlayerPrefs.GetString("InventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if (itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
                Debug.Log("The items loaded are: " + currentItem.itemName);
                
            }
        }
        Inventory.instance.UpdateItemUI();
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("coinCount", Inventory.instance.coinCount);
        if (CurrentScriptManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentScriptManager.instance.levelToUnlock);
        }

        //PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        if (itemsInInventory != "")
        {
            PlayerPrefs.SetString("InventoryItems", itemsInInventory);
            Debug.Log("The items saved are: " + itemsInInventory);
        }
        
    }

}
