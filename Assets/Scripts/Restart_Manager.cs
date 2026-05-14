using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Manager : MonoBehaviour
{
    public Animator Transitions;

    public void OnbuttonClick()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadTrans());
    }

    IEnumerator LoadTrans()
    {
        Transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);
    }

}
