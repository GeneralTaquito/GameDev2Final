using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class Entry_Manager : MonoBehaviour
{
    [Header("RoomVars")]
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public enum Rooms
    {
        None = 0,
        Room1 = 1,
        Room2 = 2,
        Room3 = 3,
        Idle = 4,
    }
    public Rooms roomVal;

    [Header("BookVars")]
    public Collider BookSlot;
    public GameObject Book1;
    public Rigidbody Book1RB;
    public GameObject Book2;
    public Rigidbody Book2RB;
    public GameObject Book3;
    public Rigidbody Book3RB;

    [Header("DoorVars")]
    public Renderer DoorRenderer;
    public GameObject Door;

    void Start()
    {
        Room1.SetActive(false);
        Room2.SetActive(false);
        Room3.SetActive(false);
    }

    void Update()
    {
        switch (roomVal)
        {
            case Rooms.None:
                Door.SetActive(true);
                StartCoroutine(CloseDoor());
                Debug.Log("Nothing / DOOR CLOSED");
                break;

            case Rooms.Room1:
                StartCoroutine(OpenDoor());
                Room1.SetActive(true);
                Debug.Log("room1state / Open Door");
                break;

            case Rooms.Room2:
                StartCoroutine(OpenDoor());
                Room2.SetActive(true);
                Debug.Log("room2state / Open Door");
                break;

            case Rooms.Room3:
                StartCoroutine(OpenDoor());
                Room3.SetActive(true);
                Debug.Log("room3state / Open Door");
                break;
            case Rooms.Idle:
                //when not doing anything
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book1"))
        {
            Book1.transform.position = transform.position;
            Book1.transform.rotation = transform.rotation; 
            Book1RB.constraints = RigidbodyConstraints.FreezeAll;
            
            roomVal = Rooms.Room1;
            Debug.Log("Book is placed (1)");
        }
        else if (other.CompareTag("Book2"))
        {
            Book2.transform.position = transform.position;
            Book2.transform.rotation = transform.rotation;
            Book2RB.constraints = RigidbodyConstraints.FreezeAll;

            roomVal = Rooms.Room2;
            Debug.Log("Book is placed (2)");
        }
        else if (other.CompareTag("Book3"))
        {
            Book3.transform.position = transform.position;
            Book3.transform.rotation = transform.rotation;
            Book3RB.constraints = RigidbodyConstraints.FreezeAll;

            roomVal = Rooms.Room3;
            Debug.Log("Book is placed (3)");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Book1"))
        {
            Book1RB.constraints = RigidbodyConstraints.None;
            roomVal = Rooms.None;
            Debug.Log("Book is removed (1)");
        }
        if (other.CompareTag("Book2"))
        {
            Book2RB.constraints = RigidbodyConstraints.None;
            roomVal = Rooms.None;
            Debug.Log("Book is removed (2)");
        }
        if (other.CompareTag("Book3"))
        {
            Book3RB.constraints = RigidbodyConstraints.None;
            roomVal = Rooms.None;
            Debug.Log("Book is removed (3)");
        }
    }

    IEnumerator OpenDoor()
    {
        Color color = DoorRenderer.material.color;
        while (color.a > 0)
        {
            color.a -= 0.01f;
            DoorRenderer.material.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        if (color.a <= 0)
        {
            roomVal = Rooms.Idle;
            Door.SetActive(false);
        }
    }
    IEnumerator CloseDoor()
    {
        Color color = DoorRenderer.material.color;
        while (color.a < 1)
        {
            color.a += 0.01f;
            DoorRenderer.material.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        if (color.a >= 1)
        {
            roomVal = Rooms.Idle;
            Room1.SetActive(false);
            Room2.SetActive(false);
            Room3.SetActive(false);
        }
    }
}
