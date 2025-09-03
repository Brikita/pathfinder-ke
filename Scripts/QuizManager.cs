using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [Header("Quiz Data")]
    public QuizDataSO quizData;

    [Header("UI Elements")]
    public GameObject quizPanel;
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text feedbackText;
    public TMP_Text scoreText;

    public GameObject quizEndPanel; // Panel to show when quiz is over
    public TMP_Text finalScoreText; // Text inside quizEndPanel for final score

    public GameObject startGamePanel; // Reference to your start game panel

    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad; // Set this in the Inspector

    private List<QuestionData> currentQuestions;
    private int currentQuestionIndex = 0;
    private int score = 0;

    public delegate void QuizEventHandler();
    public static event QuizEventHandler OnQuizStarted;
    public static event QuizEventHandler OnQuizEnded;

    void Start()
    {
        if (quizPanel == null || questionText == null || answerButtons.Length == 0 || quizData == null || startGamePanel == null)
        {
            Debug.LogError("QuizManager: Missing UI references or QuizDataSO. Please assign them in the Inspector.", this);
            return;
        }

        if (feedbackText != null) feedbackText.gameObject.SetActive(false);
        if (scoreText != null) scoreText.text = "Score: 0";
        if (quizEndPanel != null) quizEndPanel.SetActive(false);
        quizPanel.SetActive(false); // Hide quiz panel initially

        startGamePanel.SetActive(true); // Show start panel

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(buttonIndex));
        }
    }

    public void PublicStartQuiz()
    {
        if (quizData == null || quizData.questions == null || quizData.questions.Count == 0)
        {
            Debug.LogError("QuizManager: No questions found in the QuizDataSO!", this);
            quizPanel.SetActive(false);
            return;
        }

        score = 0;
        currentQuestionIndex = 0;
        if (scoreText != null) scoreText.text = "Score: 0";
        if (quizEndPanel != null) quizEndPanel.SetActive(false);
        if (feedbackText != null) feedbackText.gameObject.SetActive(false);

        currentQuestions = quizData.questions.OrderBy(x => Random.value).ToList();

        startGamePanel.SetActive(false);
        quizPanel.SetActive(true);

        DisplayQuestion();

        OnQuizStarted?.Invoke();
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex >= currentQuestions.Count)
        {
            EndQuiz();
            return;
        }

        QuestionData currentQuestion = currentQuestions[currentQuestionIndex];

        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Count)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
                answerButtons[i].interactable = true;
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }

        if (feedbackText != null) feedbackText.gameObject.SetActive(false);
    }

    public void OnAnswerSelected(int selectedAnswerIndex)
    {
        foreach (Button btn in answerButtons)
        {
            btn.interactable = false;
        }

        QuestionData currentQuestion = currentQuestions[currentQuestionIndex];

        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            score++;
            if (feedbackText != null)
            {
                feedbackText.text = "Correct!";
                feedbackText.color = Color.green;
                feedbackText.gameObject.SetActive(true);
            }
        }
        else
        {
            if (feedbackText != null)
            {
                feedbackText.text = "Incorrect. Correct answer was: " + currentQuestion.answers[currentQuestion.correctAnswerIndex];
                feedbackText.color = Color.red;
                feedbackText.gameObject.SetActive(true);
            }
        }

        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}/{currentQuestionIndex + 1}";
        }

        Invoke("NextQuestion", 1.5f);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void EndQuiz()
    {
        quizPanel.SetActive(false);
        if (quizEndPanel != null)
        {
            quizEndPanel.SetActive(true);
            if (finalScoreText != null)
            {
                finalScoreText.text = $"Quiz Complete!\nYour Score: {score}/{currentQuestions.Count}";
            }
        }
        OnQuizEnded?.Invoke();
    }

    public void RestartQuiz()
    {
        if (quizEndPanel != null) quizEndPanel.SetActive(false);
        PublicStartQuiz();
    }

    public void ExitGame()
    {
        Debug.Log("Leaving quiz and loading scene: " + sceneToLoad);
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("QuizManager: sceneToLoad is not set in the Inspector.");
        }
    }
}
