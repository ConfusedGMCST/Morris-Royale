using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class clickHandler : MonoBehaviour
{
    Vector2 downPosition = new Vector2(-810, -789);
    Vector2 topActivePos = new Vector2(-1270, 0);

    public GameObject[] states;
    public GameObject[] countryArray;
    public GameObject countries;

    public float infoIncrement = 0.05f;

    public RawImage infoBar;
    public GameObject topBar;
    public TextMeshProUGUI stateName;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI ownerText;
    public TextMeshProUGUI[] parties;

    float sinIncrement = 498;
    float topSinIncrement = 1000;
    float topBarSin = 0;
    float topBarFrame = 0;
    float infoBarFrame = 0;
    float infoPosSin = 0;
    int curStateNum = 0;

    bool infoBarActive = false;
    bool topBarActive = false;

    Transform countryTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countryTransform = countries.transform;
        infoBar.rectTransform.anchoredPosition = downPosition;
        topBar.transform.localPosition = new Vector2(topActivePos.x + topBarSin, topActivePos.y);
        Debug.Log(countryTransform.Find("DEF").GetComponent<country>().countryName);
    }

    country findCountry(state s)
    {
        country foundCountry = null;
        for (int i = 0; i < countryArray.Length; i++)
        {
            if (countryArray[i].name.Equals(s.owner))
            {
                foundCountry = countryArray[i].GetComponent<country>();
            }
        }
        Debug.Log(foundCountry);
        return foundCountry;
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
    
    void FixedUpdate()
    {
        if (infoBarActive)
        {
            if (infoBarFrame < 0.5f)
            {
                infoBarFrame += infoIncrement;
            }
        }
        else
        {
            if (infoBarFrame > -0.1f)
            {
                infoBarFrame -= infoIncrement;
            }
        }
        //infobar ^^^
        if (topBarActive)
        {
            if (topBarFrame < 0.5f)
            {
                topBarFrame += infoIncrement;
            }
        }
        else
        {
            if (topBarFrame > 0f)
            {
                topBarFrame -= infoIncrement;
            }
        }
        //top infobar ^^^
        topBarSin = Mathf.Sin(Mathf.PI * topBarFrame) * topSinIncrement;
        infoPosSin = Mathf.Sin(Mathf.PI * infoBarFrame) * sinIncrement;
        infoBar.rectTransform.anchoredPosition = new Vector2(downPosition.x, downPosition.y + infoPosSin);
        topBar.transform.localPosition = new Vector2(topActivePos.x + topBarSin, topActivePos.y);
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
        country provOwner = findCountry(curState);
        stateName.text = curState.nametag;
        ownerText.text = provOwner.countryName;
        popText.text = "Population: " + curState.population;
        for (int i = 0; i < parties.Length; i++)
        {
            parties[i].text = curState.politics[i] + "%";
        }
    }

    public void topBarButton()
    {
        if (!topBarActive)
        {
            topBarActive = true;
        } else
        {
            topBarActive = false;
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