using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPageSubmissionButton : MonoBehaviour
{
    [SerializeField] private GameObject firstPageCanvas;
    [SerializeField] private GameObject secondPageCanvas;

    public void GoToSecondPage()
    {
        firstPageCanvas.SetActive(false);
        secondPageCanvas.SetActive(true);
    }
}
