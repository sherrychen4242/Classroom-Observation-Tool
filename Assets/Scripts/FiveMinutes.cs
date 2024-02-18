using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FiveMinutes : MonoBehaviour
{
    [SerializeField] float timeLength;

    public float currentTime = 0f;
    private bool TimeIsUp { get; set; }

    private bool alreadyForNextDuration = true;
    // Start is called before the first frame update
    void Start()
    {
        TimeIsUp = false;
        currentTime = timeLength * 60f;
        gameObject.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromMinutes(currentTime).ToString(@"hh\:mm");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0f)
        {
            TimeIsUp = true;
            if (alreadyForNextDuration)
            {
                GoToNextTimeDuration();
            }
        }
        else
        {
            alreadyForNextDuration = true;
            currentTime -= Time.deltaTime;
            if (DataManager.Instance.currentTimePointer == DataManager.Instance.currentDisplayedTimePointer)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromMinutes(currentTime).ToString(@"hh\:mm");
            }
            else
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromMinutes(0f).ToString(@"hh\:mm");
            }
        }
    }

    void GoToNextTimeDuration()
    {
        if (DataManager.Instance.currentTimePointer < 11)
        {
            DataManager.Instance.currentTimePointer++;
            DataManager.Instance.currentDisplayedTimePointer = DataManager.Instance.currentTimePointer;
            currentTime = timeLength * 60f;
        }
        alreadyForNextDuration = false;
        
    }
}
