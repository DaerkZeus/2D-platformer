using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Animator flagMovement;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CurrentScriptManager.instance.playerSpawn = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            flagMovement.SetTrigger("ReachedCheckpoint");
        }
    }
}
