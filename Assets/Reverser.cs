using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverser : MonoBehaviour
{
    Timer timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<Timer>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timeManager.rewinding = !timeManager.rewinding;
        }
    }
}
