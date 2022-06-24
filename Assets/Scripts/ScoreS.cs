using UnityEngine;
using UnityEngine.UI;

public class ScoreS : MonoBehaviour{
    public Text _Score;
    public Text _Lives;
    // Update is called once per frame

    void Update(){
        //Son metodos que te regresan atributos del jugador y se ponen en la UI 
        // como textos
        _Score.text = FindObjectOfType<PlayerS>().getScore().ToString();
        _Lives.text = FindObjectOfType<PlayerS>().getLives().ToString();
    }
}
