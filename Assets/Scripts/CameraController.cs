using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Initialisera vår offset enligt kamerans position
    void Start()
    {
        offset = transform.position;
    }
	
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
