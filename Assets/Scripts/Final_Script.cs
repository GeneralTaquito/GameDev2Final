using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Final_Script : MonoBehaviour
{
    public bool Goal1;
    public bool Goal2;
    public bool Goal3;
    public Collider PedestalSlot;
    public Animator Transitions;

    private void Update()
    {
        if (Goal1 && Goal2 && Goal3)
        {
            LoadScene();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trophy1"))
        {
            Goal1 = true;
            Debug.Log("Trophy 1 present");
        }
        else if (other.CompareTag("Trophy2"))
        {
            Goal2 = true;
            Debug.Log("Trophy 2 present");
        }
        else if (other.CompareTag("Trophy3"))
        {
            Goal3 = true;
            Debug.Log("Trophy 3 present");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trophy1"))
        {
            Goal1 = false;
            Debug.Log("Trophy 1 gone");
        }
        else if (other.CompareTag("Trophy2"))
        {
            Goal2 = false;
            Debug.Log("Trophy 2 gone");
        }
        else if (other.CompareTag("Trophy3"))
        {
            Goal3 = false;
            Debug.Log("Trophy 3 gone");
        }
    }

    public void LoadScene()
    {
        StartCoroutine(LoadTrans(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadTrans(int levelIndex)
    {
        Transitions.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

}
