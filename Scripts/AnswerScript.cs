using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public TriviaManager triviaManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            triviaManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            triviaManager.wrong();
        }
    }
}
