using TMPro;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = HelloMessageMgr.HelloMessage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
