using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure to use TextMeshPro namespace
using UnityEngine.SceneManagement; // Added for scene loading if needed directly

/// <summary>
/// Manages character selection UI and persists the selected character data.
/// Implements a Singleton pattern to be accessible across scenes.
/// </summary>
public class CharacterSelectionManager : MonoBehaviour
{
    // Singleton instance for global access
    public static CharacterSelectionManager Instance { get; private set; }

    [Header("Character Data")]
    public CharacterData Alvin;
    public CharacterData Maria;

    [Header("UI Elements")]
    public Image selectedCharacterImage;
    public TextMeshProUGUI selectedCharacterNameText;
    public Button playButton;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Used to set up the Singleton pattern and ensure persistence.
    /// </summary>
    private void Awake()
    {
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate managers
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// Initializes the UI and sets up button listeners.
    /// </summary>
    private void Start()
    {
        // Ensure GameManager instance exists (good practice, though GameManager handles its own persistence)
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found! Please ensure it exists in the scene and has DontDestroyOnLoad.");
            // You might want to handle this more gracefully, e.g., load a fallback scene.
            return;
        }

        // Set initial selection (e.g., select Alvin by default)
        SetSelection(Alvin);

        // Add listeners to buttons
        // Ensure these GameObjects exist in your CharacterSelectionScene and are named correctly.
        // It's generally safer to link these in the Inspector if possible, or use FindObjectOfType.
        Button AlvinButton = GameObject.Find("AlvinButton")?.GetComponent<Button>();
        if (AlvinButton != null)
        {
            AlvinButton.onClick.AddListener(() => SetSelection(Alvin));
        }
        else
        {
            Debug.LogWarning("AlvinButton not found in scene. Please ensure it exists and is named 'AlvinButton'.");
        }

        Button MariaButton = GameObject.Find("MariaButton")?.GetComponent<Button>();
        if (MariaButton != null)
        {
            MariaButton.onClick.AddListener(() => SetSelection(Maria));
        }
        else
        {
            Debug.LogWarning("MariaButton not found in scene. Please ensure it exists and is named 'MariaButton'.");
        }

        // Link the Play button to the GameManager's StartGame method
        if (playButton != null)
        {
            playButton.onClick.AddListener(GameManager.Instance.StartGame);
        }
        else
        {
            Debug.LogWarning("PlayButton not assigned in the Inspector or not found in scene.");
        }
    }

    /// <summary>
    /// Updates the selected character in the GameManager and refreshes the UI.
    /// </summary>
    /// <param name="character">The CharacterData ScriptableObject of the selected character.</param>
    public void SetSelection(CharacterData character)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetSelectedCharacter(character);
            Debug.Log($"Selected character: {character.characterName}");

            // Update UI feedback
            if (selectedCharacterImage != null)
            {
                selectedCharacterImage.sprite = character.characterIcon;
                selectedCharacterImage.color = Color.white; // Ensure it's not transparent
            }
            if (selectedCharacterNameText != null)
            {
                selectedCharacterNameText.text = character.characterName;
            }
        }
        else
        {
            Debug.LogError("GameManager instance is null when trying to set selected character.");
        }
    }

    /// <summary>
    /// Retrieves the selected character's prefab from the GameManager.
    /// This method is intended to be called from a different scene (e.g., the Game scene)
    /// to retrieve the selected character.
    /// </summary>
    /// <returns>The GameObject of the selected character's prefab.</returns>
    public GameObject GetSelectedCharacterPrefab()
    {
        if (GameManager.Instance != null && GameManager.Instance.selectedCharacter != null)
        {
            return GameManager.Instance.selectedCharacter.characterPrefab;
        }
        else
        {
            Debug.LogError("GameManager or selected character is null. Cannot retrieve prefab.");
            return null; // Or return a default prefab if you have one
        }
    }
}
