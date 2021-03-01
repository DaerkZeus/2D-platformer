using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificLevel : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    public AudioSource audioSource;
    public bool canTrigger = true; //Make sure that the player can't teleport twice during the fade animation  

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canTrigger) 
        {
            canTrigger = false;
            StartCoroutine(loadNextScene());
        }
    }
    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        StartCoroutine(AudioFadeOut(audioSource, 2f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(2f);
        canTrigger = true;
    }

    public IEnumerator AudioFadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
