using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints;
    public AudioClip pickUpAudioSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerHealth.instance.currentHealth<PlayerHealth.instance.maxHealth)
        {
            if (collision.CompareTag("Player"))
            {
                AudioManager.instance.PlayClipAt(pickUpAudioSound, transform.position);
                PlayerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
    }
}
