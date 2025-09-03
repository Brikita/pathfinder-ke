using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterIcon; // For displaying in the UI
    public GameObject characterPrefab; // The actual prefab to instantiate
}