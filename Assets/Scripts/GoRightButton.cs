using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRightButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GoToRightTimeDuration()
    {
        if (DataManager.Instance.currentDisplayedTimePointer < 11 && 
            DataManager.Instance.currentDisplayedTimePointer < DataManager.Instance.currentTimePointer)
        {
            DataManager.Instance.currentDisplayedTimePointer++;
        }
    }
}
