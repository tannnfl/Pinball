using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;

    public float rotationSpeed;
    public KeyCode key;

    public float maxRotation;
    public float minRotation;
    public bool isRight;
    private float newRotation;

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
            if (isRight)
            {
                newRotation = Mathf.Max(rb.rotation + rotationAmount, maxRotation);
            }
            else
            {
                newRotation = Mathf.Min(rb.rotation + rotationAmount, maxRotation);
            }
            rb.MoveRotation(newRotation);
        }
        else
        {
            // 如果挡板当前角度大于休息位置，让它回落
            if (rb.rotation != minRotation)
            {
                rb.MoveRotation(minRotation);
            }
        }
    }
}
