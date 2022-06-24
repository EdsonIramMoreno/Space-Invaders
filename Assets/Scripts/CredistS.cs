using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CredistS : MonoBehaviour{
    public Button BReturn;
    public void ReturnOp(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
