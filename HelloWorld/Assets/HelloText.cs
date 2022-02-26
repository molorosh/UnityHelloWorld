using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloText : MonoBehaviour
{
    private string _msg;

    // Start is called before the first frame update
    void Start()
    {
        _msg = HelloMessageMgr.HelloMessage;
        var textMesh = GetComponent<TMPro.TextMeshPro>();
        Debug.Log(textMesh);
        if(textMesh != null)
        {
            textMesh.text = _msg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
