using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] 
    public List<QuestionsData> questions;
    private QuestionsData currentQuestion;
    private int score = 0;
    private int totalQuestions = 0;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI categoryText;
    [SerializeField] private AnswerButton[] answerButtons;
    [SerializeField] private int correctAnswerChoice;
    [SerializeField] private TextMeshProUGUI correctAnswersText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject gameOverPanel; // <-- Add this line

    private void Awake()
    {
        GetQuestions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectNewQuestion();
        SetQuestionValue();
        SetAnswerValues();
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetQuestions()
    {
        questions = new List<QuestionsData>(Resources.LoadAll<QuestionsData>("Questions"));
        totalQuestions = questions.Count;
    }

    internal void SelectNewQuestion()
    {
        if (questions == null || questions.Count == 0)
        {
            Debug.LogWarning("No more questions available.");
            ShowGameOverPanel(); // <-- Show the panel
            return;
        }
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];
        questions.RemoveAt(randomIndex);
    }

    private void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            scoreText.text = $"Final Score: {score}/{totalQuestions}";
        }
    }

    internal void SetQuestionValue()
    {
        questionText.text = currentQuestion.question;
        categoryText.text = currentQuestion.category;
    }


    internal void SetAnswerValues()
    {
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Create a temporary boolean to pass to the buttons
            bool isCorrect = false;

            // If it is the correct answer, set the bool to true
            if (i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtons[i].setIsCorrect(isCorrect);
            answerButtons[i].SetQuestionSetup(this);
            answerButtons[i].setAnswerText(answers[i]);
        }
    }

    internal void SetScore()
    {
        correctAnswersText.text = $"Score: {score}/{totalQuestions}";
    }

    internal void IncrementScore()
    {
        score++;
        SetScore();
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Get a random number of the remaining choices
            int random = Random.Range(0, originalList.Count);

            // If the random number is 0, this is the correct answer, MAKE SURE THIS IS ONLY USED ONCE
            if (random == 0 && !correctAnswerChosen)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            // Add this to the new list
            newList.Add(originalList[random]);
            //Remove this choice from the original list (it has been used)
            originalList.RemoveAt(random);
        }


        return newList;
    }
}

