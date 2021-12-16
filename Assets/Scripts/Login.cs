using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour
{
    public InputField userInput;
    public InputField passInput;
    public Button enterButton;

     void Start()
    {
        enterButton.onClick.AddListener(() =>
        {
            // Main.instance.loadData.Login(userInput.text, passInput.text);
            StartCoroutine(Main.instance.loadData.Login(userInput.text, passInput.text));

        });
    }
}
