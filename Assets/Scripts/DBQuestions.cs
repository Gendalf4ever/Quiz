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
           Debug.Log("Question: " + jsonArrayString);
        };
       CreateQuestions();
    }
    
   public void CreateQuestions()
    {
        
  string userId = Main.instance.userInfo.userID; //!
        //надо для логина чтобы загрузить Id вопроса
      StartCoroutine(Main.instance.loadData.Questions_Answers(userId, _createQuestionsCallback));
    } 
    IEnumerator CreateQuestionsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false; //готова ли загрузка?
            string questionId = jsonArray[i].AsObject["question_id"];
            if (questionId != null)
            {
                Debug.Log("Question" + questionId);
                JSONObject questionJson = new JSONObject();
                Action<string> getQuestionCallback = (questionText) =>
                {
                    isDone = true;
                    JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                    questionJson = tempArray[0].AsObject;
                    //Debug.Log("Question: " + questionJson);
                };

                StartCoroutine(Main.instance.loadData.GetQuestionID(questionId, getQuestionCallback));
                //Wait until the callback is called from loadData (finished downloading)
                yield return new WaitUntil(() => isDone == true);
            }
            else Debug.Log("Question id is equals 0");


         
            /*
           Action<Sprite> getSpriteCallback = (downloadedSprite) =>
            {
            
            }; */
            
           // GameObject question = Instantiate(Resources.Load("Prefabs/QuestionStructure") as GameObject);
            //question.transform.SetParent(this.transform);
            //question.transform.localScale = Vector3.one;
            //question.transform.localPosition = Vector3.zero;

            // fill information
           // question.transform.Find("DBQuestionText").GetComponent<Text>().text = questionJson["question"];
            //continue to the next question
            
        }
      
    }
}
