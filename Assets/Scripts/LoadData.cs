using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    void Start()
    {
        
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
                //if login success
                if (www.downloadHandler.text.Contains("Wrong Credentials") || www.downloadHandler.text.Contains("Username does not exist"))
                {
                    Debug.Log("Try again");
                    //добавить всплывающее окно
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }//Login
     
    public IEnumerator Register(string nickname, string password)
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

    public IEnumerator Questions_Answers(string question_id, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("question_id", question_id);
     
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/getQuestionAnswers.php", form))
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
                callback(jsonArray);
            }
        }

    }//Questions_Answers

    public IEnumerator Answers(string answer_id, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("answer_id", answer_id);

        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/answers.php", form))
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
                callback(jsonArray);
            }
        }

    }//Answers

    public IEnumerator GetQuestionID(string question, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("question", question);

        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/getQuestionsAnswersID.php", form))
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
                callback(jsonArray);
            }
        }

    }//GetQuestion

    public IEnumerator GetImage(string questionID, System.Action<byte[]> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("image", questionID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.64.2/UnityData/GetImages.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("downloading icon: " + questionID);
                //show results as byte array
                byte[] bytes = www.downloadHandler.data;
               callback(bytes); 
            }
        }

    }//GetImage


}