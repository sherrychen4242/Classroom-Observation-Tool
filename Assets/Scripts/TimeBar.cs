using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] timePointsTextList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentTimePoint = DataManager.Instance.currentTimePointer;
        int currentDisplayedTimePoint = DataManager.Instance.currentDisplayedTimePointer;
        for (int i = 0; i < timePointsTextList.Length; i++)
        {
            if (i == currentDisplayedTimePoint)
            {
                timePointsTextList[i].fontStyle = FontStyles.Underline;
            }
            else
            {
                timePointsTextList[i].fontStyle = FontStyles.Normal;
            }
            if (i < currentTimePoint)
            {
                timePointsTextList[i].color = new Color(0, 255, 0);
            }
            else if (i == currentTimePoint)
            {
                timePointsTextList[i].color = new Color(255, 50, 0);
            }
            else if (i > currentTimePoint)
            {
                timePointsTextList[i].color = new Color(64, 64, 64);
            }
        }
    }
}
