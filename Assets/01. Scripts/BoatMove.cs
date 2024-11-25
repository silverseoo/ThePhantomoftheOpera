using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 오브젝트 이동 속도
    public float rotationSpeed = 10f; // 회전 속도
    public Transform boatModel;
    void Update()
    {
        // 방향키 입력
        float moveX = Input.GetAxis("Vertical"); // 위/아래 화살표 키
        float moveZ = Input.GetAxis("Horizontal"); // 왼쪽/오른쪽 화살표 키

        // 입력에 따라 오브젝트 이동
        Vector3 move = new Vector3(moveX, 0, -moveZ); // 기존 방향 유지

        if (move != Vector3.zero) // 움직임이 있을 때만 실행
        {
            // 오브젝트 이동
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            // 이동 방향으로 회전
            //Quaternion targetRotation = Quaternion.LookRotation(move, boatModel.up);
            //boatModel.rotation = Quaternion.Slerp(boatModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            boatModel.LookAt(transform.position + move * 100 , boatModel.up);
        }
    }
}
