using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class clickHandler : MonoBehaviour
{
    Vector2 downPosition = new Vector2(-810, -789);
    public GameObject[] states;
    public float infoIncrement = 0.05f;
    public RawImage infoBar;
    public TextMeshProUGUI stateName;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI[] parties;
    public GameObject countries;
    float sinIncrement = 498;
    float infoBarFrame = 0f;
    float infoPosSin = 0;
    int curStateNum = 0;
    bool infoBarActive = false;
    Transform countryTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countryTransform = countries.transform;
        infoBar.rectTransform.anchoredPosition = downPosition;
        Debug.Log(countryTransform.Find("DEF").GetComponent<country>().countryName);
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
                infoPosSin = Mathf.Sin(Mathf.PI * infoBarFrame) * sinIncrement;
                infoBarFrame += infoIncrement;
            }
        }
        if (!infoBarActive)
        {
            if (infoBarFrame > -0.1f)
            {
                infoPosSin = Mathf.Sin(Mathf.PI * infoBarFrame) * sinIncrement;
                infoBarFrame -= infoIncrement;
            }
        }
        infoBar.rectTransform.anchoredPosition = new Vector2(downPosition.x, downPosition.y + infoPosSin);
    }

    public void provinceClicked()
    {
        Debug.Log("hi");
        if (!infoBarActive)
        {
            infoBarActive = true;
        }
        curStateNum = findStateName(EventSystem.current.currentSelectedGameObject.name) - 1;
        state curState = states[curStateNum].GetComponent<state>();
        stateName.text = curState.nametag;
        popText.text = "Population: " + curState.population;
        for (int i = 0; i < parties.Length; i++)
        {
            parties[i].text = curState.politics[i] + "%";
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