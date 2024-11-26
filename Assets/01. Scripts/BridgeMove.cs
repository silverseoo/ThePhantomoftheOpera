using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMove : MonoBehaviour
{
    public float rotationAmplitude = 5f; // �ִ� ȸ�� ���� (��/��� �������� ����)
    public float rotationSpeed = 1f;     // ȸ�� �ӵ� (1�ʴ� �պ� Ƚ��)

    private float initialZRotation;     // �ʱ� Z�� ȸ����

    void Start()
    {
        // �ʱ� Z�� ȸ���� ����
        initialZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Mathf.Sin�� �̿��� �ε巴�� �Դ� ���� �ϴ� Z�� ȸ���� ���
        float zRotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        // ���� X, Y���� �����ϰ� Z�ุ ����
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, initialZRotation + zRotation);
    }
}
