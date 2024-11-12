using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{

    public float moveSpeed = 1f; // ������Ʈ �̵� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ű �Է�
        float moveX = Input.GetAxis("Vertical"); // ��/�Ʒ� ȭ��ǥ Ű
        float moveZ = Input.GetAxis("Horizontal");   // ����/������ ȭ��ǥ Ű

        // �Է¿� ���� ������Ʈ �̵�
        Vector3 move = new Vector3(moveX, 0, -moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
