using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class DataSubmitter : MonoBehaviour
{
    [SerializeField] GameObject submitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.currentTimePointer >= 0 && FindObjectOfType<FirstPageSubmissionButton>() == null)
        {
            submitButton.SetActive(true);
        }
    }

    public void SendData()
    {
        StartCoroutine(SendDataToPHP());
    }

    private void OnApplicationQuit()
    {
        StartCoroutine(SendDataToPHP());
    }

    IEnumerator SendDataTest()
    {
        DataManager dm = DataManager.Instance;
        // Current time pointer
        int currentTimePointer = dm.currentTimePointer;
        //print(currentTimePointer);
        
        WWWForm form = new WWWForm();
        form.AddField("CurrentTimePointer", currentTimePointer);
        
        WWW wwwForm = new WWW("https://efgameabita.online/VenomCoLabObservationFormApplication/fromUnityData.php", form);
        yield return wwwForm;
        if (wwwForm.error != null)
        {
            Debug.Log(wwwForm.error);
        }
        else
        {
            Debug.Log(wwwForm.text);
            Debug.Log("Data successfully sent!");
        }
        
    }
    
    IEnumerator SendDataToPHP()
    {
        // Teacher's Code
        String[] _teacherCodeList = new String[7]
        {
            "ORG",
            "MAN+",
            "MAN-",
            "LEC",
            "DIR",
            "MOD",
            "PLA"
        };
        
        // Students' Code
        String[] _studentCodeList = new String[18]
        {
            "IND",
            "COL",
            "PRES",
            "PAS",
            "INAT",
            "DISL",
            "DISH",
            "HAND",
            "INFOS",
            "INFOR",
            "OFFB",
            "OFFC",
            "CLASK",
            "CLPRV",
            "ITASK",
            "ITPRV",
            "USEP",
            "USEO"
        };
        
        DataManager dm = DataManager.Instance;
        
        // School and class name
        string className = dm.className;
        string schoolName = dm.schoolName;
        
        // Number of students in each group
        int group1num = dm.group1num;
        int group2num = dm.group2num;
        int group3num = dm.group3num;
        int group4num = dm.group4num;
        int group5num = dm.group5num;
        int group6num = dm.group6num;
        
        // Current time pointer
        int currentTimePointer = dm.currentTimePointer;
    
        // Teacher Data
        Dictionary<int, Dictionary<string, bool>> teacherData = dm.teacherData;
        
        // Student Data
        Dictionary<int, Dictionary<string, bool>> group1Data = dm.group1Data;
        Dictionary<int, Dictionary<string, bool>> group2Data = dm.group2Data;
        Dictionary<int, Dictionary<string, bool>> group3Data = dm.group3Data;
        Dictionary<int, Dictionary<string, bool>> group4Data = dm.group4Data;
        Dictionary<int, Dictionary<string, bool>> group5Data = dm.group5Data;
        Dictionary<int, Dictionary<string, bool>> group6Data = dm.group6Data;
        Dictionary<int, string> group1OnTaskData = dm.group1OnTaskData;
        Dictionary<int, string> group2OnTaskData = dm.group2OnTaskData;
        Dictionary<int, string> group3OnTaskData = dm.group3OnTaskData;
        Dictionary<int, string> group4OnTaskData = dm.group4OnTaskData;
        Dictionary<int, string> group5OnTaskData = dm.group5OnTaskData;
        Dictionary<int, string> group6OnTaskData = dm.group6OnTaskData;
        Dictionary<int, string> group1EngagedData = dm.group1EngagedData;
        Dictionary<int, string> group2EngagedData = dm.group2EngagedData;
        Dictionary<int, string> group3EngagedData = dm.group3EngagedData;
        Dictionary<int, string> group4EngagedData = dm.group4EngagedData;
        Dictionary<int, string> group5EngagedData = dm.group5EngagedData;
        Dictionary<int, string> group6EngagedData = dm.group6EngagedData;
        Dictionary<int, Dictionary<int, string>> notesData = dm.notesData;
        
        Dictionary<int, Dictionary<int, Dictionary<string, bool>>> groupData = new Dictionary<int, Dictionary<int, Dictionary<string, bool>>>();
        groupData.Add(1, group1Data);
        groupData.Add(2, group2Data);
        groupData.Add(3, group3Data);
        groupData.Add(4, group4Data);
        groupData.Add(5, group5Data);
        groupData.Add(6, group6Data);

        Dictionary<int, Dictionary<int, string>> groupOnTaskData = new Dictionary<int, Dictionary<int, string>>();
        groupOnTaskData.Add(1, group1OnTaskData);
        groupOnTaskData.Add(2, group2OnTaskData);
        groupOnTaskData.Add(3, group3OnTaskData);
        groupOnTaskData.Add(4, group4OnTaskData);
        groupOnTaskData.Add(5, group5OnTaskData);
        groupOnTaskData.Add(6, group6OnTaskData);

        Dictionary<int, Dictionary<int, string>> groupEngagedData = new Dictionary<int, Dictionary<int, string>>();
        groupEngagedData.Add(1, group1EngagedData);
        groupEngagedData.Add(2, group2EngagedData);
        groupEngagedData.Add(3, group3EngagedData);
        groupEngagedData.Add(4, group4EngagedData);
        groupEngagedData.Add(5, group5EngagedData);
        groupEngagedData.Add(6, group6EngagedData);
        

        WWWForm form = new WWWForm();
        form.AddField("CurrentTimePointer", currentTimePointer);
        form.AddField("SchoolName", schoolName);
        form.AddField("ClassName", className);
        
        form.AddField("Group1NumStudents", group1num);
        form.AddField("Group2NumStudents", group2num);
        form.AddField("Group3NumStudents", group3num);
        form.AddField("Group4NumStudents", group4num);
        form.AddField("Group5NumStudents", group5num);
        form.AddField("Group6NumStudents", group6num);
        
        // Teacher Code
        for (int i = 0; i < teacherData.Count; i++)
        {
            int timePoint = (i + 1) * 5;
            string timePointText = (i * 5).ToString() + "_" + ((i + 1) * 5).ToString() + "min";
            for (int j = 0; j < 7; j++)
            {
                string codeName = _teacherCodeList[j];
                form.AddField("TeacherCode" + timePointText + codeName, teacherData[timePoint][codeName].ToString());
            }
        }
        
        // Student Code
        for (int m = 0; m < groupData.Count; m++)
        {
            int groupNum = m + 1;
            Dictionary<int, Dictionary<string, bool>> currentGroupData = groupData[groupNum];
            for (int n = 0; n < group1Data.Count; n++)
            {
                int timePoint = (n + 1) * 5;
                string timePointText = (n * 5).ToString() + "_" + ((n + 1) * 5).ToString() + "min";
                
                for (int k = 0; k < 18; k++)
                {
                    string codeName = _studentCodeList[k];
                    form.AddField("StudentCode" + timePointText + "group"+ groupNum + codeName, currentGroupData[timePoint][codeName].ToString());
                }
            }
        }
        
        // On task and engaged
        for (int x = 0; x < groupOnTaskData.Count; x++)
        {
            int groupNum = x + 1;
            Dictionary<int, string> currentOnTaskData = groupOnTaskData[groupNum];
            Dictionary<int, string> currentEngagedData = groupEngagedData[groupNum];
            for (int y = 0; y < group1OnTaskData.Count; y++)
            {
                int timePoint = (y + 1) * 5;
                string timePointText = (y * 5).ToString() + "_" + ((y + 1) * 5).ToString() + "min";
                
                form.AddField("StudentOnTask" + timePointText + "group" + groupNum, currentOnTaskData[timePoint]);
                form.AddField("StudentEngaged" + timePointText + "group" + groupNum, currentEngagedData[timePoint]);
            }
        }
        
        // Notes
        for (int r = 0; r < notesData.Count; r++)
        {
            int timePoint = (r + 1) * 5;
            string timePointText = (r * 5).ToString() + "_" + ((r + 1) * 5).ToString() + "min";

            for (int s = 0; s < 7; s++)
            {
                form.AddField("Notes" + timePointText + "group" + s, notesData[timePoint][s]);
            }
        }

        WWW wwwForm = new WWW("https://efgameabita.online/VenomCoLabObservationFormApplication/fromUnityData.php", form);
        yield return wwwForm;
        if (wwwForm.error != null)
        {
            Debug.Log(wwwForm.error);
        }
        else
        {
            Debug.Log(wwwForm.text);
            Debug.Log("Data successfully sent!");
        }
    }
}
