using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public void home()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
