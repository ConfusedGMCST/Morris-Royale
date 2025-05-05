using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class clickHandler : MonoBehaviour
{
    Vector2 downPosition = new Vector2(-810, -789);
    float sinIncrement = 498;
    public GameObject[] states;
    float infoBarFrame = 0f;
    public float infoIncrement = 0.05f;
    float infoPosSin = 0;
    int curStateNum = 0;
    bool infoBarActive = false;
    public RawImage infoBar;
    public TextMeshProUGUI stateName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoBar.rectTransform.anchoredPosition = downPosition;
        
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