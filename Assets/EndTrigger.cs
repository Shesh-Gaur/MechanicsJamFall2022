using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject winText;
    public int scene = 0;
    float timer = 0.0f;
    public float timerMax = 3.0f;

    bool levelComplete = false;
    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Player"))
      {
            winText.SetActive(true);
            timer = timerMax;
            levelComplete = true;
      }  
    }

    private void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        else if (levelComplete)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
