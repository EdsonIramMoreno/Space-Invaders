using UnityEngine;

public class BaseResistance : MonoBehaviour{

    int Resistance;
    public Animator anim;
    // Start is called before the first frame update
    void Start(){
        Resistance = 2;
        //anim es el objeto que contiene las animaciones de la base
        anim = GetComponent<Animator>();
        // IsDamage es el nombre de la animación
        anim.SetBool("IsDamage", false);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Enemy"){
            Resistance = 0;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    //Para saber si la base tiene "vida"
    public bool isUsable(){
        Resistance--;
        if (Resistance == 0)
            return false;
        return true;
    }

    //Simplemente reproduce la animacion
    public void PlayAnimation(){
         anim.SetBool("IsDamage", true);
    }
}
