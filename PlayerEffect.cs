using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.speed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }
    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.speed -= speedGiven;
    }
}
