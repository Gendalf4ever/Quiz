using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using UnityEngine.UI;
public class DBQuestions : MonoBehaviour
{
    Char[] limitation = { '[',']','{','}',':', ',','"'};
    string question;
    string someString;
    string[] questionArray;
    public Text questionText;
    [SerializeField] Image[] images = new Image[4];
    [SerializeField] Button[] answers = new Button[4];
    Action<string> _createQuestionsCallback;
    public Text numberOfTries;
    int intNumberOfTries;
    // Start is called before the first frame update
    void Start()
    {
        _createQuestionsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateQuestionsRoutine(jsonArrayString));
            questionText.text = jsonArrayString;


            Shit(jsonArrayString);

            
            

           
            //StartCoroutine(CreateAnswersRoutine(jsonArrayString)); //maybe need an another callback
       
        };
       
        CreateQuestions();
    }
    public void Shit(string jsonArrayString)
    {
        question = jsonArrayString;
        if (question.Contains("["))
        {
            question = question.Replace("[", "");
            if (question.Contains("{"))
            {
                question = question.Replace("{", "");
            }
            if (question.Contains("}"))
            {
                question = question.Replace("}", "");
            }
            if (question.Contains("]"))
            {
                question = question.Replace("]", "");
            }
            if (question.Contains("question"))
            {
                question = question.Replace("question", "");
            }
            if (question.Contains(":"))
            {
                question = question.Replace(":", "").Replace(",", "");
            }
        }//if
        questionArray = question.Split('"');
        for (int i = 0; i < questionArray.Length; i++)
        {
            question = questionArray[i];
            Debug.Log("buba: " + question);
        }
        Debug.Log("zaebal: " + question);
    } //Shit
    public void Crutch(string jsonArrayString)
    {
        question = jsonArrayString;
        if (question.Contains("question"))
        {
            question.Replace("question", ""); //не убирает question
        }
        questionArray = question.Split(limitation);
        for (int i = 0; i < questionArray.Length; i++)
        {
            someString = questionArray[i];
            print("sas: " + someString);
        }
    }//Crutch
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
                //Debug.Log("Question id " + questionId);
                JSONObject questionJson = new JSONObject();
                Action<string> getQuestionCallback = (questionText) =>
                {
                    isDone = true;
                    JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                   

                    questionJson = tempArray[0].AsObject;
                   
                   
                  
                };

                StartCoroutine(Main.instance.loadData.Questions_Answers(questionId, getQuestionCallback));
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
            //Debug.Log("answer id before " + answerId);
            int id = 1; //Костыль
            if (answerId == null) answerId = id.ToString();
           // Debug.Log("answer id " + answerId);
            JSONObject answerJson = new JSONObject();
            Action<string> getAnswerCallback = (questionText) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(questionText) as JSONArray;
                answerJson = tempArray[0].AsObject;
               // Debug.Log("Answer json: " + answerJson);
            };

            StartCoroutine(Main.instance.loadData.Answers(answerId, getAnswerCallback)); //!!!
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
