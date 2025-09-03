using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CharacterData selectedCharacter;

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    public void SetSelectedCharacter(CharacterData character)
    {
        selectedCharacter = character;
        Debug.Log($"Selected character: {selectedCharacter.characterName}");
    }

    public void StartGame()
    {
        if (selectedCharacter != null)
        {
            SceneManager.LoadScene("highschool scene"); // Load your main game scene
        }
        else
        {
            Debug.LogWarning("Please select a character first!");
        }
    }
}