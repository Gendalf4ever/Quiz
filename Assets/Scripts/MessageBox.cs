using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{
    [SerializeField] public Button okButton;
    [SerializeField] public Text okButtonText;
    [SerializeField] public Text messageText;
    [SerializeField] public Text messageTitle;
 
   public void ShowMessageBox(string title, string msgText, string buttonText) // add string buttonText
    {
        Main.instance.box.SetActive(true);
        print("This is message box");
        messageTitle.text = title;
        messageText.text = msgText;
        okButtonText.text = buttonText;

        okButton.onClick.AddListener(() =>
        {
            Main.instance.box.SetActive(false);
        });
    } //ShowMessageBox  
}
