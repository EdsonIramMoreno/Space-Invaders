using UnityEngine;

public class Bullet : MonoBehaviour{

    void Update(){
        transform.position += Vector3.up * Time.deltaTime * 5;

        if (transform.position.y > 8.8){
            //Si la bala sale del terreno se destruye
            Destroy(gameObject);
        }
    }

    //Hay dos formas de hacer "rigido" a un objeto Trigger y normal
    //Las colisiones se checan en diferentes metodos
    
    /////Trigger//////
    private void OnTriggerEnter2D(Collider2D collision){
        //Se checa la colision tag es el nombre que se le puso en unity
        if (collision.tag == "Enemy"){
            FindObjectOfType<PlayerS>().AddScore();
            //Para poder jugar sin el haptico verificamos si esta conectdo antes de 
            //llamar un metodo del arduino
            if (FindObjectOfType<ArduinoController>().isConnected()){
                FindObjectOfType<ArduinoController>().LedOn();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    /////Normal//////
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Base"){
            Destroy(gameObject);
        }
    }
}
