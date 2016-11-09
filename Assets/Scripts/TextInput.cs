using System;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
    public Text Output;

    private InputField _input;
    private InputField.SubmitEvent _se;

    // Use this for initialization
    void Start () {
        _input = gameObject.GetComponent<InputField>();
        _se = new InputField.SubmitEvent();
        _se.AddListener(SubmitInput);
        _input.onEndEdit = _se;
    }

    private void SubmitInput(String input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            Output.text = string.Format("{0}\n<color=#00FF00FF>You: \"{1}\"</color>", Output.text, input);
            
            _input.text = string.Empty;
        }

        _input.ActivateInputField();
    }
}
