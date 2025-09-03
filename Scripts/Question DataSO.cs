using UnityEngine;
using System.Collections.Generic; // Required for List

// This attribute allows you to create instances of this ScriptableObject
// directly from the Unity Editor (Assets -> Create -> Quiz Data)
[CreateAssetMenu(fileName = "NewComputerStudiesQuiz", menuName = "Quiz/Computer Studies Quiz Data")]
public class QuizDataSO : ScriptableObject
{
    public List<QuestionData> questions; // A list of all your quiz questions

    // Optional: Add a method to get a random question or shuffle them
    public QuestionData GetRandomQuestion()
    {
        if (questions == null || questions.Count == 0)
        {
            Debug.LogWarning("No questions in the quiz data!");
            return null;
        }
        return questions[Random.Range(0, questions.Count)];
    }
}