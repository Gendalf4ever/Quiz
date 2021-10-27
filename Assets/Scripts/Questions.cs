using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Questions : MonoBehaviour
{
    public QuestionList[] questions;
    public Text questionText;

    public void Game()
    {
        questionText.text = questions[Random.Range(0, questions.Length)].question;
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}