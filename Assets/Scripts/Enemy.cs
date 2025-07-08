using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int hitPoints = 8; //hit points should be divisible by 2 as the player is firing two lasers each time they fire
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();   //goes through entire project until it comes to the first Scoreboard object. Computationally expensive 
    }
    private void OnParticleCollision(GameObject other)  //method works when the gameObject that this script is attached to, it's collider, doesn't have 'isTrigger' enabled
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(explosionVFX, this.transform.position, Quaternion.identity); //'Quaternion.identity' gives that property no default rotation/0,0,0. The VFX that is being used is spherical and thus does not matter
            Destroy(this.gameObject);

        }
    }
}
