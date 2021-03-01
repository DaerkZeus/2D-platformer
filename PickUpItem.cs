using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour
{
    
    private Text interactUI;
    private bool isInRange;
    public Item item;

    public AudioClip itemSound;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }
    private void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateItemUI();
        AudioManager.instance.PlayClipAt(itemSound, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}

