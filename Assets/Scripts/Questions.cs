using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Questions : MonoBehaviour
{
   // public Text dbText;
    //public Button answerButton;
    public QuestionList[] questions;
    public Text[] answersOnButtonText;
    public Text questionText;
    public Text level;
    int levelCounter = 1;
    public Text numberOfTries;
    int intNumberOfTries;
    public Image[] questionImage = new Image[4];
    List<object> questionsList;
    int randomQuestionNumber;
    QuestionList currentQuestion;
    [SerializeField] private float _percentShowAds;
    private void Start()
    {
        questionsList = new List<object>(questions);
        level.text = levelCounter.ToString();
        questionGenerator();
    }
    public void answerButtonClick(int index)
    {
        if (answersOnButtonText[index].text.ToString() == currentQuestion.answers[0])
        {
            float tempPercent = Random.Range(0f, 1f);
            print("Правильный ответ");
            questionsList.RemoveAt(randomQuestionNumber);
            levelCounter++;
            level.text = levelCounter.ToString();
            if (tempPercent < _percentShowAds)
            { AdsScript.ShowAdsVideo("Interstitial_Android"); }
            questionGenerator();
        }
        else
        {
            print("Неправильный ответ");
            intNumberOfTries--;
            numberOfTries.text = intNumberOfTries.ToString();
            if (intNumberOfTries <= 1)
                intNumberOfTries = 1;
        } 
      

    }
    // interactible помогает сделать кнопку неактивной
     void questionGenerator()
    {
        if (questionsList.Count > 0)
        {
            intNumberOfTries = 4;
            numberOfTries.text = intNumberOfTries.ToString();
            randomQuestionNumber = Random.Range(0, questionsList.Count);
            currentQuestion = questionsList[randomQuestionNumber] as QuestionList;
            questionText.text = currentQuestion.question;
            //numberOfTries.text =intNumberOfTries.ToString();
            //questionImage.sprite = currentQuestion.question;
           
            List<string> answers = new List<string>(currentQuestion.answers);
            for (int i = 0; i < currentQuestion.answers.Length; i++)
            {
                int random = Random.Range(0, answers.Count);
                answersOnButtonText[i].text = answers[random];
                answers.RemoveAt(random);
            } //for

        } //if
        else print("Конец");

    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
    public Sprite[] questionSprite = new Sprite[4];
    
}