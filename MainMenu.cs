using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    private string sceneName = "Level01";
    public Animator fadeSystem;
    public AudioSource audioSource;
    
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingButton()
    {
        settingsWindow.SetActive(true); 
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }    
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
        //StartCoroutine(FadeSystemAnimation());
    }
    /*private IEnumerator FadeSystemAnimation()
    {
        fadeSystem.SetTrigger("FadeIn");
        StartCoroutine(AudioFadeOut(audioSource, 2f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(2f);
        
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
    }*/
}
