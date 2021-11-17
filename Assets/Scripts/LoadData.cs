using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LoadData : MonoBehaviour
{
    void Start()
    {

        StartCoroutine(GetRequest("http://192.168.64.2/UnityData/GetData.php"));
        StartCoroutine(GetRequest("https://error.html"));
        StartCoroutine(Login("Pro", "1234"));
        StartCoroutine(Questions_Answers("1+1=?", "2", "3", "4", "1"));
        // StartCoroutine(Register("Master", "123"));
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
            }
        }
    }//Login

    public IEnumerator Questions_Answers(string question, string right_answer, string second_answer, string third_answer, string fourth_answer)
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question);
        form.AddField("right_answer", right_answer);
        form.AddField("second_answer", second_answer);
        form.AddField("third_answer", third_answer);
        form.AddField("fourth_answer", fourth_answer);
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/questionsAnswers.php", form))
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

    }
}