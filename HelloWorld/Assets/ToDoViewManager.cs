using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoViewManager : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Button addButton;
    [SerializeField]
    private TMPro.TMP_InputField addField;

    // Start is called before the first frame update
    void Start()
    {
        if(addButton == null) { return; }
        if(addField == null) { return; }
        AddTextChanged();
    }

    // Update is called once per frame
    void Update()
    {
        // Exit Sample  
        if (IsEscapePressed())
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public void AddButtonClick()
    {
        Debug.Log("click the button " + DateTime.Now.ToLongTimeString());
        if(addField == null) { return; }
        string textInput = addField.text;
        if(textInput == null) { return; }
        Debug.Log("txt = [" + textInput + "]");
        if (!string.IsNullOrWhiteSpace(textInput))
        {
            ToDoMgr.Add(textInput);
            addField.text = string.Empty;
            AddTextChanged();
        }
    }

    public void AddTextChanged()
    {
        if(addButton == null) { return; }
        string textInput = addField.text;
        Debug.Log("txt = [" + textInput + "]");
        if (string.IsNullOrWhiteSpace(textInput))
        {
            addButton.enabled = false;

        }
        else
        {
            addButton.enabled = true;
        }
        Debug.Log("addButton.enabled = " + addButton.enabled.ToString() + "");
        
    }

    bool IsEscapePressed()
    {
#if ENABLE_INPUT_SYSTEM
            return Keyboard.current != null ? Keyboard.current.escapeKey.isPressed : false; 
#else
        return Input.GetKey(KeyCode.Escape);
#endif
    }
}
