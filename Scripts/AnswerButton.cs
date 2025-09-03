using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AnswerButton : MonoBehaviour
{
    private int score = 0;
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;

    // Add a reference to QuestionSetup
    private QuestionSetup questionSetup;

    private void Start()
    {
        // Find the QuestionSetup instance in the scene
        questionSetup = FindFirstObjectByType<QuestionSetup>();
    }

    public void setAnswerText(string newText)
    {
        answerText.text = newText;
    }
    public void setIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void SetQuestionSetup(QuestionSetup setup)
    {
        questionSetup = setup;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer!");
            questionSetup.IncrementScore();
        }
        else
        {
            Debug.Log("Wrong Answer!");
        }
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValue();
        questionSetup.SetAnswerValues();
    }
}
