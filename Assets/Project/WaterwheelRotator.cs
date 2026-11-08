using UnityEngine;

public class WaterwheelRotator : MonoBehaviour
{
    public float speed = 30f; // 회전 속도

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime,0,0);
    }
}