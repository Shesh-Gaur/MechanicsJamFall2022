using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExtender : MonoBehaviour
{
    Timer timeManager;
    public float newTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<Timer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timeManager.ChangeLoopLength(newTime);
            Destroy(gameObject);
        }
    }
}
