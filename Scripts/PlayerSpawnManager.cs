using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform spawnPoint; // Assign an empty GameObject in the scene as the spawn point

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found! Cannot spawn player.");
            return;
        }

        if (GameManager.Instance.selectedCharacter != null)
        {
            // Instantiate the selected character's prefab
            GameObject player = Instantiate(GameManager.Instance.selectedCharacter.characterPrefab, spawnPoint.position, spawnPoint.rotation);

            // You might want to do further initialization here, e.g.,
            // player.GetComponent<PlayerController>().Initialize(GameManager.Instance.selectedCharacter.health);
        }
        else
        {
            Debug.LogError("No character selected! Spawning default or nothing.");
            // Optionally, instantiate a default character if no selection was made
        }
    }
}