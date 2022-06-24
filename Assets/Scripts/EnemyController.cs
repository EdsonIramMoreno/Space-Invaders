using UnityEngine;

public class EnemyController : MonoBehaviour{
    public GameObject enemy;
    public GameObject _Bullet;
    Transform enemyHolder;
    float speedEnemy = 1f;

    private void Start(){
        InvokeRepeating("EnemyMovment", .1f, .25f);
        enemyHolder = GetComponent<Transform>();
    }

    void EnemyMovment(){
        enemyHolder.position += new Vector3(speedEnemy * .5f, 0, 0);

        //El foreach sirve para revisar todos los "hijos" (Enemy) de enemyHolder
        foreach(Transform Enemy in enemyHolder){
            if(Enemy.position.x > 12){
                speedEnemy = -speedEnemy;
                enemyHolder.position += new Vector3(0, -.5f, 0);
                return;
            }
            if (Enemy.position.x < 0){
                speedEnemy = -speedEnemy;
                enemyHolder.position += new Vector3(0, -.5f, 0);
                return;
            }
            if (enemyHolder.childCount == 1){
                CancelInvoke();
                InvokeRepeating("EnemyMovment", .1f, .2f);
            }
            if (Enemy.position.y < 2){
                FindObjectOfType<Manager>().EndGame();
            }
            if (Random.value >= .996){
                //Insatncia una bala con la posiscion del enemigo y con gravedad para que caiga
                Instantiate(_Bullet, Enemy.position, Quaternion.identity);
            }
        }
        if (enemyHolder.childCount == 0){
            FindObjectOfType<Manager>().GameWon();
        }
    }
}
