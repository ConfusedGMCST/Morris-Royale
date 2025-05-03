using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.IO;

public class stateData
{
    public string stateName;
}

public class clickHandler : MonoBehaviour
{
    Vector2 upPosition = new Vector2(-390.2f, -117.5f);
    Vector2 downPosition = new Vector2(-390.2f, -283.5f);
    string[] stateArray = {"test",
        "Washington",
        "Mount Olive",
        "Chester",
        "Roxbury",
        "Mine Hill",
        "Randolph",
        "Mendham Boro",
        "Mendham Township",
        "Wharton",
        "Dover",
        "South Jefferson",
        "North Jefferson",
        "Rockaway Township",
        "Rockaway Boro",
        "Denville",
        "Kinnelon",
        "Butler-Riverdale",
        "Pequannock",
        "Lincoln Park",
        "Montville",
        "Boonton",
        "Mountain Lakes",
        "East Parsippany",
        "West Parsippany",
        "Morris Plains",
        "West Morris Township",
        "Morristown",
        "East Morris Township",
        "Hanover",
        "East Hanover",
        "Florham Park",
        "Madison",
        "Chatham Boro",
        "Chatham Township",
        "Long Hill",
        "Harding"
    };
    float infoBarFrame = 0f;
    public float infoIncrement = 0.05f;
    float infoPosSin = 0;
    int curState = 0;
    bool infoBarActive = false;
    public RawImage infoBar;
    public TextMeshProUGUI stateName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoBar.rectTransform.anchoredPosition = downPosition;
        var yuh = Resources.Load<TextAsset>("state_data/state_1");
        string jsonText = File.ReadAllText(Application.streamingAssetsPath + "/state_data/state_1.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int findStateName(string str)
    {
        string numStr = "";
        int num = 0;
        bool foundUnderscore = false;
        foreach (char c in str) 
        {
            if (foundUnderscore)
            {
                numStr += c;
            }
            else
            {
                if (c == '_')
                {
                    foundUnderscore = true;
                }
            }
        }
        num = Int32.Parse(numStr);
        return num;
    }

    private void FixedUpdate()
    {
        if (infoBarActive) 
        {
            if (infoBarFrame < 0.5f)
            {
                infoPosSin = Mathf.Sin(Mathf.PI * infoBarFrame) * 166;
                infoBarFrame += infoIncrement;
                infoBar.rectTransform.anchoredPosition = new Vector2(-306.5f, -283.5f + infoPosSin);
            }
        }
        if (!infoBarActive)
        {
            if (infoBarFrame > -0.1f)
            {
                infoPosSin = Mathf.Sin(Mathf.PI * infoBarFrame) * 166;
                infoBarFrame -= infoIncrement;
                infoBar.rectTransform.anchoredPosition = new Vector2(-306.5f, -283.5f + infoPosSin);
            }
        }
    }

    public void provinceClicked()
    {
        Debug.Log("hi");
        if (!infoBarActive)
        {
            infoBarActive = true;
            curState = findStateName(EventSystem.current.currentSelectedGameObject.name);
            //stateName.text = #;

        } else
        {
            curState = findStateName(EventSystem.current.currentSelectedGameObject.name);
            stateName.text = stateArray[curState];
        }
    }
    public void exitButton()
    {
        Debug.Log("bye");
        if (infoBarActive)
        {
            infoBarActive = false;
        }
    }
}
