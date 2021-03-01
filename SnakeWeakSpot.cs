using UnityEngine;

public class SnakeWeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    public AudioClip killedSound;

    //Destroy Ennemy if it enter the weak point Collider box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killedSound, transform.position);
            Destroy(objectToDestroy);
        }
    }
}

