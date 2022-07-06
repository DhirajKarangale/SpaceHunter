using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{


    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        deathScene();
    }      

    private void deathScene()
    {
        deathFX.SetActive(true);
        SendMessage("PlayerDyes");
        Invoke("reloadLevel", 2f);
    }

       
    private void reloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
                            