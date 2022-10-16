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
    public bool didTimeFlip = false;
    public Slider timelineSlider;
    RectTransform timelineRect;
    public RectTransform handleRect;

    // Start is called before the first frame update
    void Start()
    {
        timelineSlider.maxValue = loopLength;
        timelineRect = timelineSlider.GetComponent<RectTransform>();
        timelineRect.sizeDelta += Vector2.right * loopLength * 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewinding)
        {
            didTimeFlip = false;
            time += speed * Time.deltaTime;
            if (time >= loopLength)
            {
                rewinding = true;
                handleRect.localScale = new Vector3(0.5f, 0.5f, 1.0f);
                didTimeFlip = true;
            }
        }
        else
        {
            didTimeFlip = false;
            time -= speed * Time.deltaTime;
            if (time <= 0.0f)
            {
                rewinding = false;
                handleRect.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
                didTimeFlip = true;
            }
        }

        timelineSlider.value = time;

    }

    public void ChangeLoopLength(float t)
    {
        loopLength += t;
        timelineSlider.maxValue = loopLength;
        timelineRect.sizeDelta += Vector2.right * t * 50.0f;
        time += t / 2.0f;
    }
}
