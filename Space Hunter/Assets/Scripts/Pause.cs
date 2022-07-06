using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void playAgain()
    {
        
        SceneManager.LoadScene(2);
    }


    public void home()
    {
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit(); 
    }


    
}
