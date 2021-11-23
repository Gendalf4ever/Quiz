using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using UnityEngine.UI;
public class DBQuestions : MonoBehaviour
{
    Action<string> _createQuestionsCallback;
    // Start is called before the first frame update
    void Start()
    {
        _createQuestionsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateQuestionsRoutine(jsonArrayString));
        };
        CreateQuestions();
    }

   public void CreateQuestions()
    {
        string level = Main.instance.userInfo.userLevel;
        Debug.Log("test: " + level);
        //string userId = Main.instance.userInfo.userLevel; //maybe question
        
        StartCoroutine(Main.instance.loadData.Questions_Answers(level, _createQuestionsCallback));
    }
    IEnumerator CreateQuestionsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false; //готова ли загрузка?
            string questionId = jsonArray[i].AsObject["question_id"];
            JSONObject questionJson = new JSONObject();

            Action<string> getQuestionCallback = (questionText) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                questionJson = tempArray[0].AsObject;
                Debug.Log("Question: " + questionJson);
            };

            StartCoroutine(Main.instance.loadData.GetQuestion(questionId, getQuestionCallback));
            //Wait until the callback is called from loadData (finished downloading)
            yield return new WaitUntil(() => isDone == true);
            /*
            GameObject question = Instantiate(Resources.Load("") as GameObject);
            question.transform.SetParent(this.transform);
            question.transform.localScale = Vector3.one;
            question.transform.localPosition = Vector3.zero;

            // fill information
            question.transform.Find("Name").GetComponent<Text>().text = questionJson["name"];
            //continue to the next question
            */
        }
      
    }
}
