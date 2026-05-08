using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Animator Transitions;

    public void OnbuttonClick()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadTrans(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadTrans(int levelIndex)
    {
        Transitions.SetTrigger("Start");

        yield return new WaitForSeconds (1);

        SceneManager.LoadScene(levelIndex);
    }

}
