using System.Buffers;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject[] countries; //present in stateHandler and clickHandler.
    public GameObject[] states;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI[] partyPops; 

    public string countryTag;
    public float totalPops;
    public float rulingParty;
    public float income;
    public float expenses;
    public float[] partyPopsFloat;

    float balance = 0;
    int ownedStates;

    country curCountry;

    void balCheck()
    {
        balance = 0;
        income = 0;
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].GetComponent<state>().owner == countryTag)
            {
                income += states[i].GetComponent<state>().income;
            }
        }
        balance = income;
        balanceText.text = "Balance: " + balance;
    }
    void Start()
    {
        balCheck();
        for (int i = 0; i < countries.Length; i++)
        {
            if (countries[i].gameObject.name.Equals(countryTag))
            {
                curCountry = countries[i].gameObject.GetComponent<country>();
            }
        }
        for (int i = 0; i < states.Length; i++) 
        {
            if (states[i].GetComponent<state>().owner == countryTag)
            {
                totalPops += states[i].GetComponent<state>().population;
                for (int j = 0; j < 5; j++) {
                    partyPopsFloat[j] += states[i].GetComponent<state>().politics[j];
                }
                ownedStates += 1;
            }
        }
        // for (int i = 0; i < 5; i++) {
        //     Debug.Log(partyPopsFloat[i]);
        //     partyPopsFloat[i] /= ownedStates;
        //     Debug.Log(partyPopsFloat[i]);
        //     partyPopsFloat[i] *= 10;
        //     Debug.Log(partyPopsFloat[i]);
        //     Mathf.Floor(partyPopsFloat[i]);
        //     Debug.Log(partyPopsFloat[i]);
        //     partyPopsFloat[i] /= 10;
        //     Debug.Log(partyPopsFloat[i]);
        //     partyPops[i].text = partyPopsFloat[i] + "%";
        // } didnt properly work on this get this done tmr ASAP
        popText.text = "Population: " + totalPops;
    }

    // Update is called once per frame
    void Update()
    {
        //balCheck();
    }
}
