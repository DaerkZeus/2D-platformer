using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;
    public Vector3 positionOffSet;

    private Vector3 velocity;
 
    void Update()  // Camera follow player with some time and position off set to be more confortable visually
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            player.transform.position + positionOffSet, ref velocity, timeOffSet);
    }
}
