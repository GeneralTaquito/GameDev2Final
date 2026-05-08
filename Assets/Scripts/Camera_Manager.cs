using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public float LookSensX = 1f;
    public float LookSensY = 1f;
    float xrotation;
    float yrotation;
    public Transform orientation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * LookSensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * LookSensY;

        yrotation += mouseX;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);
    }
}
