using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public TextAsset questions;
    string questionWithAnswer;
    public string currentQuestion;
    public string answers;
    public Text taskText;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    // Start is called before the first frame update
    void Start()
    {
        questionWithAnswer = questions.text;
        string[] questionsArray = questionWithAnswer.Split('/');
        currentQuestion = questionsArray[0];
        answers = questionsArray[1];
        taskText.text = currentQuestion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
