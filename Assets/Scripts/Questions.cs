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
    QuestionList currentQuestion;
    private void Start()
    {
        questionsList = new List<object>(questions);
        questionGenerator();
    }
    public void answerButtonClick(int index)
    {
        if (answersOnButtonText[index].text.ToString() == currentQuestion.answers[0]) print("Правильный ответ");
        else print("Неправильный ответ");
        questionsList.RemoveAt(randomQuestionNumber);
        questionGenerator();
    }
    public void questionGenerator()
    {
        if (questionsList.Count > 0)
        {
            randomQuestionNumber = Random.Range(0, questionsList.Count);
            currentQuestion = questionsList[randomQuestionNumber] as QuestionList;
            questionText.text = currentQuestion.question;
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
    public string[] answers = new string[4]; //maybe 3
}