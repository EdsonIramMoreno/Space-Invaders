using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public GameObject bullet;
    Animator anim;
    float FireRate;
    float nextShot;
    int Lives;
    int Score;
    int OutsideMov;
    bool Shooting;

    void Start() {
        Lives = 3;
        FireRate = .75f;
        nextShot = 0;
        Score = 0;
        OutsideMov = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (!FindObjectOfType<ArduinoController>().isConnected()){
            if (Input.GetKeyDown(KeyCode.LeftArrow) || setOutsideMov() == 1)
            {
                transform.position += new Vector3(-1, 0, 0);
                if (isValidMove())
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || setOutsideMov() == 2)
            {
                transform.position += new Vector3(1, 0, 0);
                if (isValidMove())
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            if ((Input.GetKeyDown(KeyCode.Space) && Time.time > nextShot) || (isShooting() && Time.time > nextShot))
            {
                anim.SetBool("IsShooting", true);
                nextShot = Time.time + FireRate;
                setShooting(false);
                Shot();
            }
            else
            {
                anim.SetBool("IsShooting", false);
            }
        }
        else
        {
            if (setOutsideMov() == 1)
            {
                transform.position += new Vector3(-1, 0, 0);
                if (isValidMove())
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            if (setOutsideMov() == 2)
            {
                transform.position += new Vector3(1, 0, 0);
                if (isValidMove())
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            if ((isShooting() && Time.time > nextShot))
            {
                anim.SetBool("IsShooting", true);
                nextShot = Time.time + FireRate;
                setShooting(false);
                Shot();
            }
            else
            {
                anim.SetBool("IsShooting", false);
            }
        }
    }

    int setOutsideMov() {
        return OutsideMov;
    }

    public void getOutsideMov(int OutsideMov) {
        if (OutsideMov >= 0 && OutsideMov <= 2) {
            this.OutsideMov = OutsideMov;
        }
    }

    private bool isValidMove() {
        if (transform.position.x < 0 || transform.position.x > 12)
            return true;
        return false;
    }

    void Shot() {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 1, 0);
        Instantiate(bullet, pos, Quaternion.identity);
    }

    bool isShooting(){
        return Shooting;
    }

    public void setShooting(bool shooting){
        this.Shooting = shooting;
    }

    public bool isAlive(){
        if (Lives > 0)
            return true;
        Destroy(gameObject);
        return false;
    }

    public void Damage(){
        Lives--;
    }

    public void AddScore(){
        Score += 10;
    }

    public int getLives(){
        return Lives;
    }
    public int getScore(){
        return Score;
    }

}


