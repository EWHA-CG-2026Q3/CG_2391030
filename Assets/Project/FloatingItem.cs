using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float speed = 2f;    // 떠다니는 속도
    public float height = 0.3f; // 위아래로 움직이는 폭

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + (Mathf.Sin(Time.time * speed) * height);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}