using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float moveSpeed = 5f; // ������Ʈ �̵� �ӵ�
    public float rotationSpeed = 10f; // ȸ�� �ӵ�
    public Transform boatModel;
    void Update()
    {
        // ����Ű �Է�
        float moveX = Input.GetAxis("Vertical"); // ��/�Ʒ� ȭ��ǥ Ű
        float moveZ = Input.GetAxis("Horizontal"); // ����/������ ȭ��ǥ Ű

        // �Է¿� ���� ������Ʈ �̵�
        Vector3 move = new Vector3(moveX, 0, -moveZ); // ���� ���� ����

        if (move != Vector3.zero) // �������� ���� ���� ����
        {
            // ������Ʈ �̵�
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            // �̵� �������� ȸ��
            //Quaternion targetRotation = Quaternion.LookRotation(move, boatModel.up);
            //boatModel.rotation = Quaternion.Slerp(boatModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            boatModel.LookAt(transform.position + move * 100 , boatModel.up);
        }
    }
}
