using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LoadData : MonoBehaviour
{
    void Start()
    {

        //StartCoroutine(GetRequest("http://192.168.64.2/UnityData/GetData.php"));
        //StartCoroutine(GetRequest("https://error.html"));
        //StartCoroutine(Login("Pro", "1234"));
       //StartCoroutine(Questions_Answers());
        // StartCoroutine(Register("Master", "123"));
    }
    
    public void ShowUserID()
    {
        StartCoroutine(Questions_Answers(Main.instance.userInfo.userID));
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    } //GetRequest

    public IEnumerator Login(string nickname, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", nickname);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.instance.userInfo.SetCredentials(nickname, password);
                Main.instance.userInfo.SetID(www.downloadHandler.text);
            }
        }
    }//Login
     //, string right_answer, string second_answer, string third_answer, string fourth_answer
    IEnumerator Register(string nickname, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", nickname);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }//Register

    public IEnumerator Questions_Answers(string question)
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question);
     
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/questionsAnswers.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
                // call callback function to pass results
            }
        }

    }
}