using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuS : MonoBehaviour{
   
    public void ClickedCredits(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void ClickedGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
