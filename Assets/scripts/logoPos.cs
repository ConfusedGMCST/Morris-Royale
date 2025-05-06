using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class logoPos : MonoBehaviour
{
    public bool direction; //left = false, right = true
    public Vector2 initPos;
    public TextMeshProUGUI politText;
    public RawImage logo;
    
    void Update()
    {
        if (direction)
        {
            if (politText.text.Length > 3)
            {
                logo.transform.localPosition = new Vector2(initPos.x + 27, initPos.y);
            }
            else if (politText.text.Length < 3)
            {
                logo.transform.localPosition = new Vector2(initPos.x - 17, initPos.y);
            }
            else
            {
                logo.transform.localPosition = new Vector2(initPos.x, initPos.y);
            }
        } else
        {
            if (politText.text.Length > 3)
            {
                logo.transform.localPosition = new Vector2(initPos.x - 27, initPos.y);
            } else if (politText.text.Length < 3)
            {
                logo.transform.localPosition = new Vector2(initPos.x + 17, initPos.y);
            } else
            {
                logo.transform.localPosition = new Vector2(initPos.x, initPos.y);
            } 
        }
    }
}
