using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float heightOffset = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 avgPos = ((player2.transform.position - player1.transform.position)/ 2.0f) + player1.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3 (avgPos.x, avgPos.magnitude + heightOffset ,avgPos.z), 5.0f * Time.deltaTime);
    }
}
