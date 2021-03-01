using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startingPos;
    public float parallaxEffect;

    public GameObject cam;

    void Start()
    {
        startingPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float distRelativeToCam = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startingPos + dist, cam.transform.position.y, transform.position.z);

        if (distRelativeToCam > startingPos + length)
        {
            startingPos += length;
        }
        else if (distRelativeToCam < startingPos - length)
        {
            startingPos -= length;
        }    
    }
}
