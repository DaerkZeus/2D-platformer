using UnityEngine;

public class CurrentScriptManager : MonoBehaviour
{
    public int coinsPickedDuringCurrentScene;
    public Vector3 playerSpawn;
    public int levelToUnlock;

    public static CurrentScriptManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of CurrentScripManager");
            return;
        }
        instance = this;

        playerSpawn = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
