using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMove : MonoBehaviour
{
    public float rotationAmplitude = 5f; // 최대 회전 각도 (좌/우로 기울어지는 정도)
    public float rotationSpeed = 1f;     // 회전 속도 (1초당 왕복 횟수)

    private float initialZRotation;     // 초기 Z축 회전값

    void Start()
    {
        // 초기 Z축 회전값 저장
        initialZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Mathf.Sin을 이용해 부드럽게 왔다 갔다 하는 Z축 회전값 계산
        float zRotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        // 기존 X, Y축은 유지하고 Z축만 수정
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, initialZRotation + zRotation);
    }
}
