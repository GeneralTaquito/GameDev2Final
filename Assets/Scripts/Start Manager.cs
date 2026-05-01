using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void OnbuttonClick()
    {
        SceneManager.LoadScene("Game");
    }
}
