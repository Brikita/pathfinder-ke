using UnityEngine;

public class WavingScript : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float wavingDistance = 3f;
    [SerializeField] private string wavingBool = "isWaving"; // Animator bool parameter name

    private Animator animator;
    private Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        if (player == null || animator == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);
        bool shouldWave = distance <= wavingDistance;
        animator.SetBool(wavingBool, shouldWave);
    }
}
