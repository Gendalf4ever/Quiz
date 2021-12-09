using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using UnityEngine.UI;
public class DBQuestions : MonoBehaviour
{
    public Text questionText;
    [SerializeField] Image[] images = new Image[4];
    [SerializeField] Button[] answers = new Button[4];
    Action<string> _createQuestionsCallback;
    // Start is called before the first frame update
    void Start()
    {
        _createQuestionsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateQuestionsRoutine(jsonArrayString));
            questionText.text = jsonArrayString;
            Debug.Log("Question: " + jsonArrayString);
            StartCoroutine(CreateAnswersRoutine(jsonArrayString)); //maybe need an another callback
            Debug.Log("User level:" + Main.instance.userInfo.userLevel);
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
            int id = 1; //Костыль
            if (questionId == null) questionId = id.ToString();
                Debug.Log("Question id " + questionId);
                JSONObject questionJson = new JSONObject();
                Action<string> getQuestionCallback = (questionText) =>
                {
                    isDone = true;
                    JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                    questionJson = tempArray[0].AsObject;
                    //questionText.text = questionJson;
                    
                    //Debug.Log("Question json: " + questionJson);
                };

                StartCoroutine(Main.instance.loadData.GetQuestionID(questionId, getQuestionCallback));
                //Wait until the callback is called from loadData (finished downloading)
                yield return new WaitUntil(() => isDone == true);



         
            
        } //for
      
    } //Get questions routine


    IEnumerator CreateAnswersRoutine(string jsonAnswersArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonAnswersArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false; //готова ли загрузка?
            string answerId = jsonArray[i].AsObject["answer_id"];
            int id = 1; //Костыль
            if (answerId == null) answerId = id.ToString();
            Debug.Log("answer id " + answerId);
            JSONObject answerJson = new JSONObject();
            Action<string> getQuestionCallback = (questionText) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                answerJson = tempArray[0].AsObject;
                //questionText.text = questionJson;

                Debug.Log("Question json: " + answerJson);
            };

            StartCoroutine(Main.instance.loadData.GetQuestionID(answerId, getQuestionCallback)); //!!!
            //Wait until the callback is called from loadData (finished downloading)
            yield return new WaitUntil(() => isDone == true);


            byte[] bytes = ImageManager.Instance.LoadImage(answerId); //answer_id
            //download from web
            if (bytes.Length == 0)
            {
                Action<byte[]> getBytesCallback = (downloadedBytes) =>
                {
                    Sprite sprite = ImageManager.Instance.bytesToSprite(downloadedBytes);
                    images[0].sprite = sprite;
                    images[1].sprite = sprite;
                    images[2].sprite = sprite;
                    images[3].sprite = sprite;
                    ImageManager.Instance.SaveImage(answerId, downloadedBytes); 
                };
                StartCoroutine(Main.instance.loadData.GetImage(answerId, getBytesCallback));
            }
            //load from device
            else {

                Sprite sprite = ImageManager.Instance.bytesToSprite(bytes);
                images[0].sprite = sprite;
                images[1].sprite = sprite;
                images[2].sprite = sprite;
                images[3].sprite = sprite;
            } 
          
          




        } //for

    } // create answers routine
}
