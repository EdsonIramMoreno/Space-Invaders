using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour{
    public Text TPause;
    public Text TFinish;
    public Text TGameOver;
    public Button BYes;
    public Button BNo;
    public GameObject panel;
    int GameState;

    private void Start(){
        SetGameState(0);
        TGameOver.enabled = false;
        panel.SetActive(false);
        HideFinishMenu();
        HidePauseMenu();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.P)){
            SetGameState(1);
            ShowPauseMenu();
        }
        if (!FindObjectOfType<PlayerS>().isAlive()){
            //Hace un delay de 2 segundos para llamar el metodo
            Invoke("EndGame", 2.0f);
        }
    }

    public void EndGame(){
        TGameOver.text = "Game Lost";
        //Cambia el color RGB
        TGameOver.color = new Color(1, 0, 0);
        ShowFinishMenu();
    }

    public void HideFinishMenu(){
        //Esconde todos los elementos del menu
        FindObjectOfType<PlayerS>().enabled = true;
        FindObjectOfType<Canvas>().GetComponent<PauseMenu>().enabled = false;
        TFinish.enabled = false;
        panel.SetActive(false);
        BNo.gameObject.SetActive(false);
        BYes.gameObject.SetActive(false);
        //Regresa el juego a la velovidad normal
        Time.timeScale = 1f;
    }

    public void ShowFinishMenu() { 
        //Muestra los elementos del menu
        FindObjectOfType<PlayerS>().enabled = false;
        FindObjectOfType<Canvas>().GetComponent<PauseMenu>().enabled = true;
        TFinish.enabled = true;
        TGameOver.enabled = true;
        panel.SetActive(true);
        BNo.gameObject.SetActive(true);
        BYes.gameObject.SetActive(true);
        //Hace que el tiempo no avance, la velocidad es 0
        Time.timeScale = 0f;
    }

    public void GameWon(){
        TGameOver.text = "Game Won";
        //Cambia el color RGB
        TGameOver.color = new Color(0, 1, 0);
        ShowFinishMenu();
    }

    public void HidePauseMenu(){
        //Esconde todos los elementos del menu
        SetGameState(0);
        FindObjectOfType<PlayerS>().enabled = true;
        FindObjectOfType<Canvas>().GetComponent<PauseMenu>().enabled = false;
        TPause.enabled = false;
        panel.SetActive(false);
        BNo.gameObject.SetActive(false);
        BYes.gameObject.SetActive(false);
        //Regresa el juego a la velovidad normal
        Time.timeScale = 1f;
    }

    public void ShowPauseMenu(){
        //Muestra los elementos del menu
        SetGameState(1);
        FindObjectOfType<PlayerS>().enabled = false;
        FindObjectOfType<Canvas>().GetComponent<PauseMenu>().enabled = true;
        TPause.enabled = true;
        panel.SetActive(true);
        BNo.gameObject.SetActive(true);
        BYes.gameObject.SetActive(true);
        //Hace que el tiempo no avance, la velocidad es 0
        Time.timeScale = 0f;
    }

    public int GetGameState() {
        return GameState;
    }

    public void SetGameState(int gameState){
        GameState = gameState;
    }

}
