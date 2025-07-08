using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"You have collided with: {other.gameObject.name}");
        Instantiate(explosionVFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        gameSceneManager.ReloadLevel();
    }
}
