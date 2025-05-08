using UnityEngine;
using UnityEngine.UI;

public class stateHandler : MonoBehaviour
{
    public Button[] stateButtons;
    public GameObject[] states;
    public GameObject[] countries;
    void Start()
    {
        for (int i = 0; i < states.Length; i++) 
        { 
            state state_data = states[i].GetComponent<state>();
            for (int j = 0; j < countries.Length; j++) 
            { 
                if (state_data.owner.Equals(countries[j].name))
                {
                    ColorBlock colorBlock = new ColorBlock();
                    colorBlock = stateButtons[i].colors;
                    colorBlock.normalColor = countries[j].GetComponent<country>().color;
                    stateButtons[i].colors = colorBlock;
                    state_data.income = (state_data.tax + state_data.trade) - state_data.maintenance;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
