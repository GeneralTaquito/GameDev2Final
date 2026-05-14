using UnityEngine;

public class Eye_Script : MonoBehaviour
{
    public bool Looking;
    public Transform Player;
    float SpeedRot = 5f;

    void Awake()
    {
        gameObject.SetActive(false);
        Looking = false;
    }
    void Update()
    {
        if (Looking == true)
        {
            var lookpos = Player.position - transform.position;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * SpeedRot);
        }
    }
}
