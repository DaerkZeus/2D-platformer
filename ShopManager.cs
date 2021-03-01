using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Animator animator;

    public Text npcNameText;

    public GameObject sellButtonsPrefab;
    public Transform sellButtonsParent;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There more than one instance of ShopManager");
            return;
        }
        instance = this;
    }
    public void OpenShop(Item[] items, string npcName)
    {
        npcNameText.text = npcName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);
    }
    private void UpdateItemsToSell(Item[] items)
    {
        // Clearing any previous items
        for (int i = 0; i < sellButtonsParent.childCount; i++)
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }
        // Creating the numbers of items based on the prefab
        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(sellButtonsPrefab, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].itemName;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();

            buttonScript.item = items[i];

            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); } );
        }
    }
    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }
}
