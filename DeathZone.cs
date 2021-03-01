using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;

    //public int deathZoneDamage = 10;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        //This operation is costly so it only happens once and it is stocked throughout the level
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerHealth>().TakeDamage(deathZoneDamage); 
            //(This line can be added to hurt the player if entering death zones)
            StartCoroutine(ReplacePlayerFadeIn(collision));   
        }
    }

    private IEnumerator ReplacePlayerFadeIn(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        collision.transform.position = CurrentScriptManager.instance.playerSpawn;
    }
}
