using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class clickHandler : MonoBehaviour
{
    Vector2 downPosition = new Vector2(-810, -789);
    Vector2 topActivePos = new Vector2(-1065, 0);

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
    public TextMeshProUGUI income;
    public TextMeshProUGUI tax;
    public TextMeshProUGUI trade;
    public TextMeshProUGUI maintenance;

    float sinIncrement = 498;
    float topSinIncrement = 1000;
    float tradeFloat;
    float taxFloat;
    float maintenanceFloat;
    float incomeFloat;
    float topBarSin = 0;
    float topBarFrame = 0;
    float infoBarFrame = 0;
    float infoPosSin = 0;
    int curStateNum = 0;

    bool infoBarActive = false;
    bool topBarActive = false;

    void Start()
    {
        infoBar.rectTransform.anchoredPosition = downPosition;
        topBar.transform.localPosition = new Vector2(topActivePos.x + topBarSin, topActivePos.y);
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
    int findState(string str)
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
        num = int.Parse(numStr);
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
        if (!infoBarActive)
        {
            infoBarActive = true;
        }
        curStateNum = findState(EventSystem.current.currentSelectedGameObject.name) - 1;

        state curState = states[curStateNum].GetComponent<state>();
        country provOwner = findCountry(curState);

        taxFloat = curState.tax;
        tradeFloat = curState.trade;
        maintenanceFloat = curState.maintenance;
        incomeFloat = (taxFloat + tradeFloat) - maintenanceFloat;
        curState.income = incomeFloat;

        tax.text = "Tax: " + taxFloat + "$";
        trade.text = "Trade: " + tradeFloat + "$";
        maintenance.text = "Maintenance: " + maintenanceFloat + "$";
        stateName.text = curState.nametag;
        ownerText.text = provOwner.countryName;
        popText.text = "Population: " + curState.population;
        income.text = "Income: " + incomeFloat + "$";
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
        if (infoBarActive)
        {
            infoBarActive = false;
        }
    }
}