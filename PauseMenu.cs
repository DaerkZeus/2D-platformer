using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameisPaused = false;
    public static bool ableToResume = false;
    public GameObject menuPauseUI;
    public GameObject settingsMenu;
    public GameObject buttonToHide;

    public static PauseMenu instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PauseMenu.");
            return;
        }
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPaused && ableToResume)
            {
                Resume();
            }
            else if (!gameisPaused && !ableToResume)
            {
                Paused();
            }
        }
    }
    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        menuPauseUI.SetActive(true);
        Time.timeScale = 0;
        gameisPaused = true;
        ableToResume = true;
    }
    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        menuPauseUI.SetActive(false);
        Time.timeScale = 1;
        gameisPaused = false;
        ableToResume = false;
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }
    public void displaySettingsMenu()
    {
        settingsMenu.SetActive(true);
        buttonToHide.SetActive(false);
        ableToResume = false;
    }
    public void closeSettingsMenu()
    {
        settingsMenu.SetActive(false);
        buttonToHide.SetActive(true);
        ableToResume = true;
    }
}
