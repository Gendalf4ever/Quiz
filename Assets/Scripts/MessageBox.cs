using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{

    
    [SerializeField] public Button okButton;
    [SerializeField] public Text messageText;
    [SerializeField] public Text messageTitle;
 


   public void ShowMessageBox() // add string buttonText
    {
        print("This is message box");

        // string title;
        //string msgText;
        //  title = "beba";
        // msgText = "baba";
        
       // Main.instance.messageBox.gameObject.SetActive(true);
        //messageTitle.text = title;
        //messageText.text = msgText;
       // title = messageTitle.ToString();
        //msgText = messageText.ToString();
       /// buttonText = okButton.text
    }

   
}
