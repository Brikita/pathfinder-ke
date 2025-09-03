using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionsData : ScriptableObject
{
    public string question;
    public string category;
    [Tooltip("The correct answer should be first")]
    public string[] answers;
}
