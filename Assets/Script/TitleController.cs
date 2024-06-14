using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    void Update(){
        if (Input.GetMouseButton((int)MouseButton.Left)) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
