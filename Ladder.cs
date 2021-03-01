using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInLadderRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D ladderCollider;
    private Text interactUI;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(isInLadderRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            ladderCollider.isTrigger = false;
            return; //end the frame or the following statement will cancel this one
        }

        if (isInLadderRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;  //Reference to the variable in PlayerMovement scrip: enable the player to climb
            ladderCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInLadderRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInLadderRange = false;
            playerMovement.isClimbing = false;
            ladderCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
