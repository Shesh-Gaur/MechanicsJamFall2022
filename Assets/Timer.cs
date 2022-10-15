using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float time;
    public float speed = 1.0f;
    public float loopLength = 10.0f;
    public bool rewinding = false;
    public Slider timelineSlider;

    // Start is called before the first frame update
    void Start()
    {
        timelineSlider.maxValue = loopLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewinding)
        {
            time += speed * Time.deltaTime;
            if (time >= loopLength)
                rewinding = true;
        }
        else
        {
            time -= speed * Time.deltaTime;
            if (time <= 0.0f)
                rewinding = false;
        }

        timelineSlider.value = time;

    }
}
