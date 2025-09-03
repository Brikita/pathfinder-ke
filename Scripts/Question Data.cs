using UnityEngine;
using System.Collections.Generic; // Required for List

// This attribute makes it visible in the Unity Inspector when part of another script
[System.Serializable]
public class QuestionData
{
    [TextArea(3, 5)] // Makes the string field a multi-line text area in Inspector
    public string questionText;

    public List<string> answers; // List to hold multiple answer options

    [Tooltip("The zero-based index of the correct answer in the 'answers' list.")]
    public int correctAnswerIndex;

    // Optional: Add a property to check if the question is valid
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(questionText) &&
               answers != null &&
               answers.Count > 0 &&
               correctAnswerIndex >= 0 &&
               correctAnswerIndex < answers.Count;
    }
}