using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Questions : MonoBehaviour
{
    public QuestionList[] questions;
    public Text[] answersOnButtonText;
    public Text questionText;
    List<object> questionsList;
    int randomQuestionNumber;
   
    public void Game()
    {
        questionsList = new List<object>(questions);
        questionGenerator();
    }
    public void answerButtonClick()
    {
        questionsList.RemoveAt(randomQuestionNumber);
        questionGenerator();
    }
    public void questionGenerator()
    {
        randomQuestionNumber = Random.Range(0, questionsList.Count);
        QuestionList currentQuestion = questionsList[randomQuestionNumber] as QuestionList;
        questionText.text = currentQuestion.question;
        for (int i = 0; i < currentQuestion.answers.Length; i++) answersOnButtonText[i].text = currentQuestion.answers[i];

    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4]; //maybe 3
}