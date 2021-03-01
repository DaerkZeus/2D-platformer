using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public Item[] allItems;

    public static ItemsDataBase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There more than one instance of ItemsDataBase");
            return;
        }
        instance = this;
    }
}
