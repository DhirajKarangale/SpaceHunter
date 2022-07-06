using UnityEngine.SceneManagement;
using UnityEngine;

public class Home : MonoBehaviour
{


    public void play()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit() 
    {
        Application.Quit();
    }

}
