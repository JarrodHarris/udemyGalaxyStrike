using UnityEngine;

//Script is made to so the overall music doesnt restart but instead keeps on playing on death of player
public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;    //returning the amount of music players in scene without sorting it

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else    // when a new scene or reloading of a scene, keep this gameObject; 'MusicPlayer' persisting instead of destroying and making a new one
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
