using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip soundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position);
            Inventory.instance.AddCoins(1);
            CurrentScriptManager.instance.coinsPickedDuringCurrentScene++;
            Destroy(gameObject);
        }
    }
}
