using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    
    public void ClickedYes(){
        //GetGameState regresa un int y con eso el botón YES que
        //es el mismo en el menu de pause y del final
        //hace diferentes acciones
        if (FindObjectOfType<Manager>().GetGameState() == 1)
            FindObjectOfType<Manager>().HidePauseMenu();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClickedNo(){
        //GetGameState regresa un int y con eso el botón NO que
        //es el mismo en el menu de pause y del final
        //hace diferentes acciones
        if (FindObjectOfType<Manager>().GetGameState() == 1){
            if (SceneManager.GetActiveScene().name == "Game")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
            if (SceneManager.GetActiveScene().name == "Game")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
