using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject[] countries; //present in stateHandler and clickHandler.
    public GameObject[] states;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI[] partyPops;
    public TextMeshProUGUI stabText;
    public TextMeshProUGUI warSupportText;
    public TextMeshProUGUI rulingPartyText;

    public string countryTag;
    public float totalPops;
    public float income;
    public float expenses;
    public float[] partyPopsFloat;

    string rulingParty;
    float warSupport;
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
        balanceText.text = "Balance: " + balance + "$";
    }
    void statCheck()
    {
        totalPops = 0;
        ownedStates = 0;
        for (int i = 0; i < states[i].GetComponent<state>().politics.Length; i++)
        {
            partyPopsFloat[i] = 0;
        }
        balCheck();
        for (int i = 0; i < countries.Length; i++)
        {
            if (countries[i].gameObject.name.Equals(countryTag))
            {
                curCountry = countries[i].gameObject.GetComponent<country>();
            }
        }
        rulingParty = curCountry.rulingParty;
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].GetComponent<state>().owner == countryTag)
            {
                totalPops += states[i].GetComponent<state>().population;
                for (int j = 0; j < states[i].GetComponent<state>().politics.Length; j++)
                {
                    partyPopsFloat[j] += states[i].GetComponent<state>().politics[j];
                }
                ownedStates += 1;
            }
        }
        for (int i = 0; i < states[i].GetComponent<state>().politics.Length; i++)
        {
            partyPopsFloat[i] /= ownedStates;
            partyPops[i].text = Mathf.Round(partyPopsFloat[i]) + "%";
        }
        warSupport = curCountry.warSupport;
        warSupportText.text = "War Support: " + warSupport + "%";
        rulingPartyText.text = rulingParty;
        stabText.text = "Stability: " + curCountry.stability + "%";
        popText.text = "Population: " + totalPops;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        statCheck();
    }
}
