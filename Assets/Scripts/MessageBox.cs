using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageBox : MonoBehaviour
{
    [SerializeField] public Button okButton;
    [SerializeField] public Text messageText;
    [SerializeField] public Text messageTitle;
    // Start is called before the first frame update
   public void ShowMessageBox(string title, string msgText) //string buttonText add
    { 
        Main.instance.messageBox.gameObject.SetActive(true);
        title = messageTitle.text;
        msgText = messageText.text;
       // title = messageTitle.ToString();
        //msgText = messageText.ToString();
       /// buttonText = okButton.text
    }
}
