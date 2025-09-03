using Unity.Cinemachine; // Required for Cinemachine components
using UnityEngine;

/// <summary>
/// Manages the loading of the selected character and assigns its head as the
/// follow target for the main camera's Cinemachine components (v3.1.4+).
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [Tooltip("The main camera in this scene, which should have the CinemachineCamera and CinemachineThirdPersonFollow components.")]
    public Camera mainCamera;

    [Tooltip("The transform where the player character will be spawned.")]
    public Transform playerSpawnPoint;

    /// <summary>
    /// Start is called before the first frame update.
    /// This is where we will instantiate the character and set up the camera.
    /// </summary>
    private void Start()
    {
        // 1. Get the selected character prefab from the CharacterSelectionManager's Instance.
        if (CharacterSelectionManager.Instance == null)
        {
            Debug.LogError("CharacterSelectionManager is missing or not initialized! Cannot load character.");
            return;
        }

        GameObject selectedCharacterPrefab = CharacterSelectionManager.Instance.GetSelectedCharacterPrefab();
        if (selectedCharacterPrefab == null)
        {
            Debug.LogError("Selected character prefab is null. Cannot instantiate character. Ensure a character was selected in the previous scene.");
            return;
        }

        // 2. Instantiate the selected character at the spawn point.
        GameObject playerInstance = Instantiate(selectedCharacterPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);

        // 3. Find the head/camera target transform on the player character.
        Transform cameraTarget = FindCameraTarget(playerInstance);

        if (cameraTarget == null)
        {
            Debug.LogError("Could not find a camera target (e.g., 'Head' bone) on the player character. Check your character's hierarchy.");
            return;
        }

        // 4. Configure the main camera's Cinemachine components to follow the target.
        if (mainCamera != null)
        {
            // Get the CinemachineCamera component from the main camera.
            // This is the component that primarily holds the Follow and LookAt targets.
            CinemachineCamera cinemachineCamera = mainCamera.GetComponent<CinemachineCamera>();

            if (cinemachineCamera != null)
            {
                // Assign the found transform as the follow and look-at targets for the CinemachineCamera.
                cinemachineCamera.Follow = cameraTarget;
                //cinemachineCamera.LookAt = cameraTarget; // Usually, you'll want it to look at the same target.

                Debug.Log("Cinemachine camera is now following the player's head.");
            }
            else
            {
                Debug.LogError("CinemachineCamera component is not found on the main camera! Please add it.");
            }
        }
        else
        {
            Debug.LogError("Main Camera is not assigned in the GameSceneManager script! Please assign your Main Camera.");
        }
    }

    /// <summary>
    /// Helper method to find a specific transform (like the head bone) on the player instance.
    /// This assumes your character models have a consistent child object/bone named "Head".
    /// </summary>
    /// <param name="Player">The instantiated player GameObject.</param>
    /// <returns>The transform to follow, or null if not found.</returns>
    private Transform FindCameraTarget(GameObject Player)
    {
        string targetName = "Head"; // Common name for Mixamo head bone. Adjust if yours is different (e.g., "mixamorig:Head").

        Transform target = Player.transform.Find(targetName);

        // If not a direct child, search in all children recursively.
        if (target == null)
        {
            foreach (Transform child in Player.GetComponentsInChildren<Transform>())
            {
                if (child.name == targetName)
                {
                    target = child;
                    break;
                }
            }
        }

        return target;
    }
}
