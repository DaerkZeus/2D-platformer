using UnityEngine;
using System.Collections;

public class DoorToSameLevel : MonoBehaviour
{
    public Animator fadeSystem;
    public GameObject newPosition;

    public GameObject background;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WalkThroughDoor(collision.gameObject));
                  }
    }
    public IEnumerator WalkThroughDoor(GameObject player)
    {
        player.gameObject.GetComponent<Animator>().SetBool("Door", true);
        PlayerMovement.instance.rb.velocity = new Vector3(0f, 0f, 0f);
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2f);
        player.gameObject.GetComponent<Animator>().SetBool("Door", false);
        player.transform.position = newPosition.transform.position;
        player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        background.SetActive(true);
        yield return new WaitForSeconds(2f);
    }
}
