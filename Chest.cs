using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    public Animator chestAnimator;
    private Text interactUI;
    private bool canOpenChest;
    public int coinsToAdd;
    public AudioClip chestSound;
    public GameObject chest;
    
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenChest)
        {
            OpenChest();
            Inventory.instance.AddCoins(coinsToAdd);
            AudioManager.instance.PlayClipAt(chestSound, transform.position);
            chest.GetComponent<Chest>().enabled = false;
            chest.GetComponent<BoxCollider2D>().enabled = false;
            interactUI.enabled = false;
        }
    }
    private void OpenChest()
    {
        chestAnimator.SetTrigger("OpenChest");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            canOpenChest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            canOpenChest = false;
        }
    }


}
