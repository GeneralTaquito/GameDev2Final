using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Entry_Manager : MonoBehaviour
{
    public Collider BookSlot;
    public GameObject Book1;
    public enum Rooms
    {
        None = 0,
        Room1 = 1,
        Room2 = 2,
        Room3 = 3,
    }
    public Rooms roomVal;

    [Header("DoorVars")]
    public GameObject myDoor;
    public Material doorMat;

    void Update()
    {
        switch (roomVal)
        {
            case Rooms.None:
                StartCoroutine(FadeDoor(60f));
                Debug.Log("defaultstate");
                break;

            case Rooms.Room1:
                
            break;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book1"))
        {
            
            Debug.Log("Bookplaced");
        }
    }

    IEnumerator FadeDoor(float speed)
    {
        while(doorMat.color.a > 0)
        {
            Color Color = doorMat.color;
            Color.a -= 1f;
            yield return new WaitForSeconds(1 / speed);
            Debug.Log("reachedhere");
        }
        if (doorMat.color.a == 0)
        {
            myDoor.SetActive(false);
        }
    }

}
