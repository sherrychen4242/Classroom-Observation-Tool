using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("DataManager").AddComponent<DataManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        // Optionally, persist this object when loading new scenes
        DontDestroyOnLoad(this.gameObject);
    }

    // Class and school variable
    public string className = "Esperanza";
    public string schoolName = "North Star Academy";
    [SerializeField] GameObject classDropdown;
    private TMP_Dropdown cd;
    [SerializeField] GameObject schoolDropdown;
    private TMP_Dropdown sd;

    // Number of students in each group
    public int group1num = 0;
    public int group2num = 0;
    public int group3num = 0;
    public int group4num = 0;
    public int group5num = 0;
    public int group6num = 0;
    [SerializeField] private TMP_Dropdown group1NumDropdown;
    [SerializeField] private TMP_Dropdown group2NumDropdown;
    [SerializeField] private TMP_Dropdown group3NumDropdown;
    [SerializeField] private TMP_Dropdown group4NumDropdown;
    [SerializeField] private TMP_Dropdown group5NumDropdown;
    [SerializeField] private TMP_Dropdown group6NumDropdown;

    // Current Time Pointer
    public int currentTimePointer = 0;
    public int currentDisplayedTimePointer = 0;
    [SerializeField] private TextMeshProUGUI currentTimePointText;

    // Time Length
    private String[] _timePointList = new String[12]
    {
        "0-5 min",
        "5-10 min",
        "10-15 min",
        "15-20 min",
        "20-25 min",
        "25-30 min",
        "30-35 min",
        "35-40 min",
        "40-45 min",
        "45-50 min",
        "50-55 min",
        "55-60 min"
    };

    // Teacher's Code
    private String[] _teacherCodeList = new String[7]
    {
        "ORG",
        "MAN+",
        "MAN-",
        "LEC",
        "DIR",
        "MOD",
        "PLA"
    };

    [SerializeField] private Toggle[] teacherCodeToggles;

    // Students' Code
    private String[] _studentCodeList = new String[18]
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

    [SerializeField] private Toggle[] generalStudentCodeToggles;
    [SerializeField] private TMP_Dropdown generalOnTaskDropdown;
    [SerializeField] private TMP_Dropdown generalEngagedDropdown;
    [SerializeField] private TMP_InputField generalNotesInputField;
    
    [SerializeField] private Toggle[] group1Toggles;
    [SerializeField] private Toggle[] group2Toggles;
    [SerializeField] private Toggle[] group3Toggles;
    [SerializeField] private Toggle[] group4Toggles;
    [SerializeField] private Toggle[] group5Toggles;
    [SerializeField] private Toggle[] group6Toggles;
    [SerializeField] private TMP_Dropdown group1OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group2OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group3OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group4OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group5OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group6OnTaskDropdown;
    [SerializeField] private TMP_Dropdown group1EngagedDropdown;
    [SerializeField] private TMP_Dropdown group2EngagedDropdown;
    [SerializeField] private TMP_Dropdown group3EngagedDropdown;
    [SerializeField] private TMP_Dropdown group4EngagedDropdown;
    [SerializeField] private TMP_Dropdown group5EngagedDropdown;
    [SerializeField] private TMP_Dropdown group6EngagedDropdown;
    [SerializeField] private TMP_InputField group1NotesInputField;
    [SerializeField] private TMP_InputField group2NotesInputField;
    [SerializeField] private TMP_InputField group3NotesInputField;
    [SerializeField] private TMP_InputField group4NotesInputField;
    [SerializeField] private TMP_InputField group5NotesInputField;
    [SerializeField] private TMP_InputField group6NotesInputField;

    // Observation Data
    public Dictionary<int, Dictionary<string, bool>> teacherData = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group1Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group2Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group3Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group4Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group5Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, Dictionary<string, bool>> group6Data = new Dictionary<int, Dictionary<string, bool>>();
    public Dictionary<int, string> group1OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group2OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group3OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group4OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group5OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group6OnTaskData = new Dictionary<int, string>();
    public Dictionary<int, string> group1EngagedData = new Dictionary<int, string>();
    public Dictionary<int, string> group2EngagedData = new Dictionary<int, string>();
    public Dictionary<int, string> group3EngagedData = new Dictionary<int, string>();
    public Dictionary<int, string> group4EngagedData = new Dictionary<int, string>();
    public Dictionary<int, string> group5EngagedData = new Dictionary<int, string>();
    public Dictionary<int, string> group6EngagedData = new Dictionary<int, string>();
    public Dictionary<int, Dictionary<int, string>> notesData = new Dictionary<int, Dictionary<int, string>>();

    // Start is called before the first frame update
    void Start()
    {
        // First page dropdown
        cd = classDropdown.GetComponent<TMP_Dropdown>();
        cd.onValueChanged.AddListener(delegate { ClassDropdownValueChanged(cd); });

        sd = schoolDropdown.GetComponent<TMP_Dropdown>();
        sd.onValueChanged.AddListener(delegate { SchoolDropdownValueChanged(sd); });

        group1NumDropdown.onValueChanged.AddListener(delegate
        {
            Group1NumStudentsDropdownValueChanged(group1NumDropdown);
        });
        group2NumDropdown.onValueChanged.AddListener(delegate
        {
            Group2NumStudentsDropdownValueChanged(group2NumDropdown);
        });
        group3NumDropdown.onValueChanged.AddListener(delegate
        {
            Group3NumStudentsDropdownValueChanged(group3NumDropdown);
        });
        group4NumDropdown.onValueChanged.AddListener(delegate
        {
            Group4NumStudentsDropdownValueChanged(group4NumDropdown);
        });
        group5NumDropdown.onValueChanged.AddListener(delegate
        {
            Group5NumStudentsDropdownValueChanged(group5NumDropdown);
        });
        group6NumDropdown.onValueChanged.AddListener(delegate
        {
            Group6NumStudentsDropdownValueChanged(group6NumDropdown);
        });

        InitDictionaries();

        OnValueChanged();
    }

    # region SchoolClassGroupNumDropDownDelegateMethods

    void ClassDropdownValueChanged(TMP_Dropdown change)
    {
        className = change.options[change.value].text.ToString();
    }

    void SchoolDropdownValueChanged(TMP_Dropdown change)
    {
        schoolName = change.options[change.value].text.ToString();
    }

    void Group1NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group1num = change.value;
    }

    void Group2NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group2num = change.value;
    }

    void Group3NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group3num = change.value;
    }

    void Group4NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group4num = change.value;
    }

    void Group5NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group5num = change.value;
    }

    void Group6NumStudentsDropdownValueChanged(TMP_Dropdown change)
    {
        group6num = change.value;
    }

    #endregion

    #region Init Dictionaries

    void InitDictionaries()
    {
        for (int i = 0; i < _timePointList.Length; i++)
        {
            int timePoint = 5 * (i + 1);
            // Teacher code
            Dictionary<string, bool> tempTeacherCode = new Dictionary<string, bool>();
            for (int j = 0; j < _teacherCodeList.Length; j++)
            {
                string teacherCode = _teacherCodeList[j];
                tempTeacherCode.Add(teacherCode, false);
            }

            teacherData.Add(timePoint, tempTeacherCode);
            // Student Code
            Dictionary<int, string> tempNotesData = new Dictionary<int, string>();
            tempNotesData.Add(0, "");
            for (int x = 0; x < 6; x++)
            {
                Dictionary<string, bool> tempStudentCode = new Dictionary<string, bool>();
                for (int j = 0; j < _studentCodeList.Length; j++)
                {
                    string studentCode = _studentCodeList[j];
                    tempStudentCode.Add(studentCode, false);
                }

                switch (x)
                {
                    case 0:
                        group1Data.Add(timePoint, tempStudentCode);
                        group1OnTaskData.Add(timePoint, "0%");
                        group1EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(1, "");
                        break;
                    case 1:
                        group2Data.Add(timePoint, tempStudentCode);
                        group2OnTaskData.Add(timePoint, "0%");
                        group2EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(2, "");
                        break;
                    case 2:
                        group3Data.Add(timePoint, tempStudentCode);
                        group3OnTaskData.Add(timePoint, "0%");
                        group3EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(3, "");
                        break;
                    case 3:
                        group4Data.Add(timePoint, tempStudentCode);
                        group4OnTaskData.Add(timePoint, "0%");
                        group4EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(4, "");
                        break;
                    case 4:
                        group5Data.Add(timePoint, tempStudentCode);
                        group5OnTaskData.Add(timePoint, "0%");
                        group5EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(5, "");
                        break;
                    case 5:
                        group6Data.Add(timePoint, tempStudentCode);
                        group6OnTaskData.Add(timePoint, "0%");
                        group6EngagedData.Add(timePoint, "0%");
                        tempNotesData.Add(6, "");
                        break;
                }
            }

            notesData.Add(timePoint, tempNotesData);
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        Display();
    }

    void Display()
    {
        // Time point
        currentTimePointText.text = _timePointList[currentDisplayedTimePointer];

        // Teacher Code
        for (int i = 0; i < _teacherCodeList.Length; i++)
        {
            teacherCodeToggles[i].isOn = teacherData[(currentDisplayedTimePointer + 1) * 5][_teacherCodeList[i]];
        }

        // Student Code
        for (int j = 0; j < _studentCodeList.Length; j++)
        {
            group1Toggles[j].isOn = group1Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];
            group2Toggles[j].isOn = group2Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];
            group3Toggles[j].isOn = group3Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];
            group4Toggles[j].isOn = group4Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];
            group5Toggles[j].isOn = group5Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];
            group6Toggles[j].isOn = group6Data[(currentDisplayedTimePointer + 1) * 5][_studentCodeList[j]];

            // General Student Code
            if (group1Toggles[j].isOn && group2Toggles[j].isOn && group3Toggles[j].isOn
                && group4Toggles[j].isOn && group5Toggles[j].isOn && group6Toggles[j].isOn)
            {
                generalStudentCodeToggles[j].isOn = true;
            }
            else
            {
                generalStudentCodeToggles[j].isOn = false;
            }
        }

        // On Task and Engaged
        group1OnTaskDropdown.value = group1OnTaskDropdown.options.FindIndex(
            option => option.text == group1OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );
        group2OnTaskDropdown.value = group2OnTaskDropdown.options.FindIndex(
            option => option.text == group2OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );
        group3OnTaskDropdown.value = group3OnTaskDropdown.options.FindIndex(
            option => option.text == group3OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );
        group4OnTaskDropdown.value = group4OnTaskDropdown.options.FindIndex(
            option => option.text == group4OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );
        group5OnTaskDropdown.value = group5OnTaskDropdown.options.FindIndex(
            option => option.text == group5OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );
        group6OnTaskDropdown.value = group6OnTaskDropdown.options.FindIndex(
            option => option.text == group6OnTaskData[(currentDisplayedTimePointer + 1) * 5]
        );

        group1EngagedDropdown.value = group1EngagedDropdown.options.FindIndex(
            option => option.text == group1EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );
        group2EngagedDropdown.value = group2EngagedDropdown.options.FindIndex(
            option => option.text == group2EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );
        group3EngagedDropdown.value = group3EngagedDropdown.options.FindIndex(
            option => option.text == group3EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );
        group4EngagedDropdown.value = group4EngagedDropdown.options.FindIndex(
            option => option.text == group4EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );
        group5EngagedDropdown.value = group5EngagedDropdown.options.FindIndex(
            option => option.text == group5EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );
        group6EngagedDropdown.value = group6EngagedDropdown.options.FindIndex(
            option => option.text == group6EngagedData[(currentDisplayedTimePointer + 1) * 5]
        );

        // General On Task and Engaged
        if (group1EngagedDropdown.value == group2EngagedDropdown.value &&
            group2EngagedDropdown.value == group3EngagedDropdown.value &&
            group3EngagedDropdown.value == group4EngagedDropdown.value &&
            group4EngagedDropdown.value == group5EngagedDropdown.value &&
            group5EngagedDropdown.value == group6EngagedDropdown.value)
        {
            generalEngagedDropdown.value = group1EngagedDropdown.value;
        }
        else
        {
            generalEngagedDropdown.value = 5;
        }

        if (group1OnTaskDropdown.value == group2OnTaskDropdown.value &&
            group2OnTaskDropdown.value == group3OnTaskDropdown.value &&
            group3OnTaskDropdown.value == group4OnTaskDropdown.value &&
            group4OnTaskDropdown.value == group5OnTaskDropdown.value &&
            group5OnTaskDropdown.value == group6OnTaskDropdown.value)
        {
            generalOnTaskDropdown.value = group1OnTaskDropdown.value;
        }
        else
        {
            generalOnTaskDropdown.value = 5;
        }

        // Notes
        generalNotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][0];
        group1NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][1];
        group2NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][2];
        group3NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][3];
        group4NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][4];
        group5NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][5];
        group6NotesInputField.text = notesData[(currentDisplayedTimePointer + 1) * 5][6];
    }

    void OnValueChanged()
    {
        #region TeacherCode

        teacherCodeToggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[0], _teacherCodeList[0], "teacher");
        });
        teacherCodeToggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[1], _teacherCodeList[1], "teacher");
        });
        teacherCodeToggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[2], _teacherCodeList[2], "teacher");
        });
        teacherCodeToggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[3], _teacherCodeList[3], "teacher");
        });
        teacherCodeToggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[4], _teacherCodeList[4], "teacher");
        });
        teacherCodeToggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[5], _teacherCodeList[5], "teacher");
        });
        teacherCodeToggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(teacherCodeToggles[6], _teacherCodeList[6], "teacher");
        });

        #endregion

        #region StudentCode

        // General Student Code
        generalStudentCodeToggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[0], _studentCodeList[0], "student", 0);
        });
        generalStudentCodeToggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[1], _studentCodeList[1], "student", 0);
        });
        generalStudentCodeToggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[2], _studentCodeList[2], "student", 0);
        });
        generalStudentCodeToggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[3], _studentCodeList[3], "student", 0);
        });
        generalStudentCodeToggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[4], _studentCodeList[4], "student", 0);
        });
        generalStudentCodeToggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[5], _studentCodeList[5], "student", 0);
        });
        generalStudentCodeToggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[6], _studentCodeList[6], "student", 0);
        });
        generalStudentCodeToggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[7], _studentCodeList[7], "student", 0);
        });
        generalStudentCodeToggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[8], _studentCodeList[8], "student", 0);
        });
        generalStudentCodeToggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[9], _studentCodeList[9], "student", 0);
        });
        generalStudentCodeToggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[10], _studentCodeList[10], "student", 0);
        });
        generalStudentCodeToggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[11], _studentCodeList[11], "student", 0);
        });
        generalStudentCodeToggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[12], _studentCodeList[12], "student", 0);
        });
        generalStudentCodeToggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[13], _studentCodeList[13], "student", 0);
        });
        generalStudentCodeToggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[14], _studentCodeList[14], "student", 0);
        });
        generalStudentCodeToggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[15], _studentCodeList[15], "student", 0);
        });
        generalStudentCodeToggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[16], _studentCodeList[16], "student", 0);
        });
        generalStudentCodeToggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(generalStudentCodeToggles[17], _studentCodeList[17], "student", 0);
        });

        // 0
        group1Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[0], _studentCodeList[0], "student", 1);
        });
        group2Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[0], _studentCodeList[0], "student", 2);
        });
        group3Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[0], _studentCodeList[0], "student", 3);
        });
        group4Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[0], _studentCodeList[0], "student", 4);
        });
        group5Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[0], _studentCodeList[0], "student", 5);
        });
        group6Toggles[0].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[0], _studentCodeList[0], "student", 6);
        });

        // 1
        group1Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[1], _studentCodeList[1], "student", 1);
        });
        group2Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[1], _studentCodeList[1], "student", 2);
        });
        group3Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[1], _studentCodeList[1], "student", 3);
        });
        group4Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[1], _studentCodeList[1], "student", 4);
        });
        group5Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[1], _studentCodeList[1], "student", 5);
        });
        group6Toggles[1].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[1], _studentCodeList[1], "student", 6);
        });

        // 2
        group1Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[2], _studentCodeList[2], "student", 1);
        });
        group2Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[2], _studentCodeList[2], "student", 2);
        });
        group3Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[2], _studentCodeList[2], "student", 3);
        });
        group4Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[2], _studentCodeList[2], "student", 4);
        });
        group5Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[2], _studentCodeList[2], "student", 5);
        });
        group6Toggles[2].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[2], _studentCodeList[2], "student", 6);
        });

        // 3
        group1Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[3], _studentCodeList[3], "student", 1);
        });
        group2Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[3], _studentCodeList[3], "student", 2);
        });
        group3Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[3], _studentCodeList[3], "student", 3);
        });
        group4Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[3], _studentCodeList[3], "student", 4);
        });
        group5Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[3], _studentCodeList[3], "student", 5);
        });
        group6Toggles[3].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[3], _studentCodeList[3], "student", 6);
        });

        // 4
        group1Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[4], _studentCodeList[4], "student", 1);
        });
        group2Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[4], _studentCodeList[4], "student", 2);
        });
        group3Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[4], _studentCodeList[4], "student", 3);
        });
        group4Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[4], _studentCodeList[4], "student", 4);
        });
        group5Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[4], _studentCodeList[4], "student", 5);
        });
        group6Toggles[4].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[4], _studentCodeList[4], "student", 6);
        });

        // 5
        group1Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[5], _studentCodeList[5], "student", 1);
        });
        group2Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[5], _studentCodeList[5], "student", 2);
        });
        group3Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[5], _studentCodeList[5], "student", 3);
        });
        group4Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[5], _studentCodeList[5], "student", 4);
        });
        group5Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[5], _studentCodeList[5], "student", 5);
        });
        group6Toggles[5].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[5], _studentCodeList[5], "student", 6);
        });

        // 6
        group1Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[6], _studentCodeList[6], "student", 1);
        });
        group2Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[6], _studentCodeList[6], "student", 2);
        });
        group3Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[6], _studentCodeList[6], "student", 3);
        });
        group4Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[6], _studentCodeList[6], "student", 4);
        });
        group5Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[6], _studentCodeList[6], "student", 5);
        });
        group6Toggles[6].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[6], _studentCodeList[6], "student", 6);
        });

        // 7
        group1Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[7], _studentCodeList[7], "student", 1);
        });
        group2Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[7], _studentCodeList[7], "student", 2);
        });
        group3Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[7], _studentCodeList[7], "student", 3);
        });
        group4Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[7], _studentCodeList[7], "student", 4);
        });
        group5Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[7], _studentCodeList[7], "student", 5);
        });
        group6Toggles[7].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[7], _studentCodeList[7], "student", 6);
        });

        // 8
        group1Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[8], _studentCodeList[8], "student", 1);
        });
        group2Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[8], _studentCodeList[8], "student", 2);
        });
        group3Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[8], _studentCodeList[8], "student", 3);
        });
        group4Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[8], _studentCodeList[8], "student", 4);
        });
        group5Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[8], _studentCodeList[8], "student", 5);
        });
        group6Toggles[8].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[8], _studentCodeList[8], "student", 6);
        });

        // 9
        group1Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[9], _studentCodeList[9], "student", 1);
        });
        group2Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[9], _studentCodeList[9], "student", 2);
        });
        group3Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[9], _studentCodeList[9], "student", 3);
        });
        group4Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[9], _studentCodeList[9], "student", 4);
        });
        group5Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[9], _studentCodeList[9], "student", 5);
        });
        group6Toggles[9].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[9], _studentCodeList[9], "student", 6);
        });

        // 10
        group1Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[10], _studentCodeList[10], "student", 1);
        });
        group2Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[10], _studentCodeList[10], "student", 2);
        });
        group3Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[10], _studentCodeList[10], "student", 3);
        });
        group4Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[10], _studentCodeList[10], "student", 4);
        });
        group5Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[10], _studentCodeList[10], "student", 5);
        });
        group6Toggles[10].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[10], _studentCodeList[10], "student", 6);
        });

        // 11
        group1Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[11], _studentCodeList[11], "student", 1);
        });
        group2Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[11], _studentCodeList[11], "student", 2);
        });
        group3Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[11], _studentCodeList[11], "student", 3);
        });
        group4Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[11], _studentCodeList[11], "student", 4);
        });
        group5Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[11], _studentCodeList[11], "student", 5);
        });
        group6Toggles[11].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[11], _studentCodeList[11], "student", 6);
        });

        // 12
        group1Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[12], _studentCodeList[12], "student", 1);
        });
        group2Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[12], _studentCodeList[12], "student", 2);
        });
        group3Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[12], _studentCodeList[12], "student", 3);
        });
        group4Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[12], _studentCodeList[12], "student", 4);
        });
        group5Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[12], _studentCodeList[12], "student", 5);
        });
        group6Toggles[12].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[12], _studentCodeList[12], "student", 6);
        });

        // 13
        group1Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[13], _studentCodeList[13], "student", 1);
        });
        group2Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[13], _studentCodeList[13], "student", 2);
        });
        group3Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[13], _studentCodeList[13], "student", 3);
        });
        group4Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[13], _studentCodeList[13], "student", 4);
        });
        group5Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[13], _studentCodeList[13], "student", 5);
        });
        group6Toggles[13].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[13], _studentCodeList[13], "student", 6);
        });

        // 14
        group1Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[14], _studentCodeList[14], "student", 1);
        });
        group2Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[14], _studentCodeList[14], "student", 2);
        });
        group3Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[14], _studentCodeList[14], "student", 3);
        });
        group4Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[14], _studentCodeList[14], "student", 4);
        });
        group5Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[14], _studentCodeList[14], "student", 5);
        });
        group6Toggles[14].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[14], _studentCodeList[14], "student", 6);
        });

        // 15
        group1Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[15], _studentCodeList[15], "student", 1);
        });
        group2Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[15], _studentCodeList[15], "student", 2);
        });
        group3Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[15], _studentCodeList[15], "student", 3);
        });
        group4Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[15], _studentCodeList[15], "student", 4);
        });
        group5Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[15], _studentCodeList[15], "student", 5);
        });
        group6Toggles[15].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[15], _studentCodeList[15], "student", 6);
        });

        // 16
        group1Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[16], _studentCodeList[16], "student", 1);
        });
        group2Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[16], _studentCodeList[16], "student", 2);
        });
        group3Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[16], _studentCodeList[16], "student", 3);
        });
        group4Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[16], _studentCodeList[16], "student", 4);
        });
        group5Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[16], _studentCodeList[16], "student", 5);
        });
        group6Toggles[16].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[16], _studentCodeList[16], "student", 6);
        });

        // 17
        group1Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group1Toggles[17], _studentCodeList[17], "student", 1);
        });
        group2Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group2Toggles[17], _studentCodeList[17], "student", 2);
        });
        group3Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group3Toggles[17], _studentCodeList[17], "student", 3);
        });
        group4Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group4Toggles[17], _studentCodeList[17], "student", 4);
        });
        group5Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group5Toggles[17], _studentCodeList[17], "student", 5);
        });
        group6Toggles[17].onValueChanged.AddListener(delegate
        {
            OnToggleValueChanged(group6Toggles[17], _studentCodeList[17], "student", 6);
        });

        #endregion

        #region OnTaskEngaged

        generalOnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(generalOnTaskDropdown, 0);
        });
        group1OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group1OnTaskDropdown, 1);
        });
        group2OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group2OnTaskDropdown, 2);
        });
        group3OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group3OnTaskDropdown, 3);
        });
        group4OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group4OnTaskDropdown, 4);
        });
        group5OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group5OnTaskDropdown, 5);
        });
        group6OnTaskDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownOnTaskValueChanged(group6OnTaskDropdown, 6);
        });

        generalEngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(generalEngagedDropdown, 0);
        });
        group1EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group1EngagedDropdown, 1);
        });
        group2EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group2EngagedDropdown, 2);
        });
        group3EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group3EngagedDropdown, 3);
        });
        group4EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group4EngagedDropdown, 4);
        });
        group5EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group5EngagedDropdown, 5);
        });
        group6EngagedDropdown.onValueChanged.AddListener(delegate
        {
            OnDropdownEngagedValueChanged(group6EngagedDropdown, 6);
        });

        #endregion

        #region Notes

        generalNotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(generalNotesInputField, 0); });
        group1NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group1NotesInputField, 1); });
        group2NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group2NotesInputField, 2); });
        group3NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group3NotesInputField, 3); });
        group4NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group4NotesInputField, 4); });
        group5NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group5NotesInputField, 5); });
        group6NotesInputField.onValueChanged.AddListener(delegate { OnInputfieldChanged(group6NotesInputField, 6); });

        #endregion
    }

    void OnToggleValueChanged(Toggle change, string codeName, string group)
    {
        if (group == "teacher")
        {
            if (change.isOn)
            {
                teacherData[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
            }
            else
            {
                teacherData[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
            }
        }
    }

    void OnToggleValueChanged(Toggle change, string codeName, string group, int groupNum)
    {
        if (group == "student")
        {
            switch (groupNum)
            {
                case 0:
                    if (change.isOn)
                    {
                        group1Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                        group2Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                        group3Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                        group4Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                        group5Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                        group6Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        if (group1Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true &&
                            group2Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true &&
                            group3Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true &&
                            group4Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true &&
                            group5Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true &&
                            group6Data[(currentDisplayedTimePointer + 1) * 5][codeName] == true)
                        {
                            group1Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                            group2Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                            group3Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                            group4Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                            group5Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                            group6Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                        }
                    }

                    break;
                case 1:
                    if (change.isOn)
                    {
                        group1Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group1Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
                case 2:
                    if (change.isOn)
                    {
                        group2Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group2Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
                case 3:
                    if (change.isOn)
                    {
                        group3Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group3Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
                case 4:
                    if (change.isOn)
                    {
                        group4Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group4Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
                case 5:
                    if (change.isOn)
                    {
                        group5Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group5Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
                case 6:
                    if (change.isOn)
                    {
                        group6Data[(currentDisplayedTimePointer + 1) * 5][codeName] = true;
                    }
                    else
                    {
                        group6Data[(currentDisplayedTimePointer + 1) * 5][codeName] = false;
                    }

                    break;
            }

        }
    }

    void OnDropdownOnTaskValueChanged(TMP_Dropdown change, int groupNum)
    {
        switch (groupNum)
        {
            // General on task
            case 0:
                if (change.value == 0)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 1:
                if (change.value == 0)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group1OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 2:
                if (change.value == 0)
                {
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group2OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 3:
                if (change.value == 0)
                {
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group3OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 4:
                if (change.value == 0)
                {
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group4OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 5:
                if (change.value == 0)
                {
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group5OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 6:
                if (change.value == 0)
                {
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group6OnTaskData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
        }
    }

    void OnDropdownEngagedValueChanged(TMP_Dropdown change, int groupNum)
    {
        switch (groupNum)
        {
            // General on task
            case 0:
                if (change.value == 0)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 1:
                if (change.value == 0)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group1EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 2:
                if (change.value == 0)
                {
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group2EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 3:
                if (change.value == 0)
                {
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group3EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 4:
                if (change.value == 0)
                {
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group4EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 5:
                if (change.value == 0)
                {
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group5EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
            case 6:
                if (change.value == 0)
                {
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "0%";
                }
                else if (change.value == 1)
                {
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "25%";
                }
                else if (change.value == 2)
                {
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "50%";
                }
                else if (change.value == 3)
                {
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "75%";
                }
                else if (change.value == 4)
                {
                    group6EngagedData[(currentDisplayedTimePointer + 1) * 5] = "100%";
                }

                break;
        }
    }

    void OnInputfieldChanged(TMP_InputField change, int groupNum)
    {
        switch (groupNum)
        {
            case 0:
                notesData[(currentDisplayedTimePointer + 1) * 5][0] = change.text;
                break;
            case 1:
                notesData[(currentDisplayedTimePointer + 1) * 5][1] = change.text;
                break;
            case 2:
                notesData[(currentDisplayedTimePointer + 1) * 5][2] = change.text;
                break;
            case 3:
                notesData[(currentDisplayedTimePointer + 1) * 5][3] = change.text;
                break;
            case 4:
                notesData[(currentDisplayedTimePointer + 1) * 5][4] = change.text;
                break;
            case 5:
                notesData[(currentDisplayedTimePointer + 1) * 5][5] = change.text;
                break;
            case 6:
                notesData[(currentDisplayedTimePointer + 1) * 5][6] = change.text;
                break;
        }
    }
    
    void OnInputfieldChanged(InputField change, int groupNum)
    {
        switch (groupNum)
        {
            case 0:
                notesData[(currentDisplayedTimePointer + 1) * 5][0] = change.text;
                break;
            case 1:
                notesData[(currentDisplayedTimePointer + 1) * 5][1] = change.text;
                break;
            case 2:
                notesData[(currentDisplayedTimePointer + 1) * 5][2] = change.text;
                break;
            case 3:
                notesData[(currentDisplayedTimePointer + 1) * 5][3] = change.text;
                break;
            case 4:
                notesData[(currentDisplayedTimePointer + 1) * 5][4] = change.text;
                break;
            case 5:
                notesData[(currentDisplayedTimePointer + 1) * 5][5] = change.text;
                break;
            case 6:
                notesData[(currentDisplayedTimePointer + 1) * 5][6] = change.text;
                break;
        }
    }
}
