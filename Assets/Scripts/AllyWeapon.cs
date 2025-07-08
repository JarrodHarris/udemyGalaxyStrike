using System.Collections;
using UnityEngine;

public class AllyWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] GameObject[] enemyShips;

    [SerializeField] AudioClip laserShotSFX;
    AudioSource audioSource;
    bool enemiesAlive = true;

    IEnumerator WaitBeforeFiringRoutine()
    {
        yield return new WaitForSeconds(3.2f);
        ProcessFiring();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        StartCoroutine(WaitBeforeFiringRoutine());
        if (!enemiesAlive)
        {
            StopFiring();
        }
    }

    private void ProcessFiring()
    {
        foreach (GameObject enemy in enemyShips)
        {
            if (enemy != null)
            {
                foreach (GameObject laser in lasers)
                {
                    Debug.Log("shooting");
                    laser.transform.LookAt(enemy.transform.position);
                    var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                    emissionModule.enabled = true;

                    if (audioSource.isPlaying != true)
                    {
                        audioSource.PlayOneShot(laserShotSFX);
                    }
                }
            }
            enemiesAlive = false;
        }
    }

    private void StopFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }
}