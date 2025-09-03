using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class TriviaManager : MonoBehaviour
{
    public GameObject instructionPanel;
    public GameObject questionPanel;

    public List<TriviaQA> QnA;
    public GameObject[] options; // Each option should be a Button with a Text child
    public int currentQuestion;

    public GameObject QuestionPanel;
    public GameObject GOPanel;

    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad; // Set this in the Inspector

    private void Start()
    {
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowQuestionPanel()
    {
        instructionPanel.SetActive(false);
        questionPanel.SetActive(true);
    }

    void GameOver()
    {
        QuestionPanel.SetActive(false);
        GOPanel.SetActive(true);
        ScoreTxt.text = score + " / " + totalQuestions;
    }
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);

        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            Debug.Log("All questions answered! Showing Game Over panel.");
            GameOver();
        }
    }


    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);

        if (QnA.Count > 0)
        {
            generateQuestion();
        }
        else
        {
            Debug.Log("All questions answered! Showing Game Over panel.");
            GameOver();
        }
    }

    void SetAnswers()
    {
        if (QnA[currentQuestion].Answers == null || QnA[currentQuestion].Answers.Length < options.Length)
        {
            Debug.LogError("Answer list is missing or incomplete for current question!");
            return;
        }

        for (int i = 0; i < options.Length; i++)
        {
            var answerBtn = options[i];
            if (answerBtn == null)
            {
                Debug.LogError($"Option {i} is not assigned.");
                continue;
            }

            var answerScript = answerBtn.GetComponent<AnswerScript>();
            if (answerScript == null)
            {
                Debug.LogError($"Missing AnswerScript on option {i}.");
                continue;
            }

            answerScript.isCorrect = false;

            //  Updated to TMP_Text
            var textComponent = answerBtn.transform.GetChild(0).GetComponent<TMP_Text>();
            if (textComponent == null)
            {
                Debug.LogError($"Missing TMP_Text component on child of option {i}.");
                continue;
            }

            textComponent.text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                answerScript.isCorrect = true;
            }
        }
    }


    void generateQuestion()
    {
        if (QnA.Count == 0)
        {
            Debug.Log("No questions left.");
            GameOver();
            return;
        }

        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }

    public void EndGame()
    {
        Debug.Log("Leaving quiz and loading scene: " + sceneToLoad);

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("TriviaManager: sceneToLoad is not set in the Inspector.");
        }
    }
}
