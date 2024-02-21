using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlipperRight : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;

    public float rotationSpeed = 900f;
    public KeyCode key = KeyCode.RightShift;

    public float maxRotation = -20f;
    public float minRotation = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            // 计算每帧的旋转量
            float rotationAmount = rotationSpeed * Time.deltaTime;
            // 计算新的旋转角度，但不超过最大角度
            float newRotation = Mathf.Min(rb.rotation + rotationAmount, maxRotation);
            rb.MoveRotation(newRotation);
        }
        else
        {
            // 如果挡板当前角度大于休息位置，让它回落
            if (rb.rotation != minRotation)
            {
                // 根据当前角度和休息位置的差值，适当减速回落
                float returnSpeed = (rb.rotation - minRotation) * 5f; // 5f是回落速度系数，可根据需要调整
                rb.MoveRotation(minRotation);
            }
        }
    }

    void RotateFlipper(float speed)
    {
        float rotationAmount = speed * Time.deltaTime; 
        float newRotation = rb.rotation + rotationAmount; 
        rb.MoveRotation(newRotation); 
    }
}
