using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        if(SceneManager.GetActiveScene().name != scene) SceneManager.LoadScene(scene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "Main_menu") SceneManager.LoadScene("Main_menu");
            else
            {
                Application.Quit();
            }
        }
    }
    
}
