using UnityEngine;

public class EnemyShot : MonoBehaviour{
    Transform bullet;
    void Start(){
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate(){
        bullet.position += Vector3.down * 5 * Time.deltaTime;

        if (bullet.position.y <= -1){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Player"){
            collision.collider.GetComponent<PlayerS>().Damage();
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Base"){
            collision.collider.GetComponent<BaseResistance>().PlayAnimation();
            if (!collision.collider.GetComponent<BaseResistance>().isUsable()){
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

}
