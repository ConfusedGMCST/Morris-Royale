using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject[] countries; //present in stateHandler and clickHandler.

    public string countryTag;
    public float totalPops;
    public float rulingParty;
    public float income;
    public float expenses;

    country curCountry;
    void Start()
    {
        for (int i = 0; i < countries.Length; i++)
        {
            if (countries[i].gameObject.name.Equals(countryTag))
            {
                curCountry = countries[i].gameObject.GetComponent<country>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
