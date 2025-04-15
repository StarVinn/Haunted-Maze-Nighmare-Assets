using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantKillFire : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instantly kill the player
            Debug.Log("Player has been killed by fire!");
            Time.timeScale = 0;
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }

    private void Update()
    {
        

    }
}
