using UnityEngine;
using TMPro;
using System.Collections;

public class NPC_Script : MonoBehaviour
{
    public TextMeshProUGUI Text1;
    public string[] lines;
    public float textspeed;
    private int index;

    void Start()
    {
        Text1.text = string.Empty;
        DialogueStart();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Text1.text == lines[index])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                Text1.text = lines[index];
            }
        }
    }
    void DialogueStart()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            Text1.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextDialogue()
    {
        if (index < lines.Length - 1)
        {
            index++;
            Text1.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
        }
    }
}
