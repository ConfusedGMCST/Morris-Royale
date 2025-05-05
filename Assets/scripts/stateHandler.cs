using UnityEngine;

public class stateHandler : MonoBehaviour
{
    public GameObject[] states;
    public GameObject[] countries;
    void Start()
    {
        for (int i = 0; i < states.Length; i++) 
        { 
            state state_data = states[i].GetComponent<state>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
