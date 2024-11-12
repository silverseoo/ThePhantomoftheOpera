using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{

    public float moveSpeed = 1f; // 오브젝트 이동 속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 방향키 입력
        float moveX = Input.GetAxis("Vertical"); // 위/아래 화살표 키
        float moveZ = Input.GetAxis("Horizontal");   // 왼쪽/오른쪽 화살표 키

        // 입력에 따라 오브젝트 이동
        Vector3 move = new Vector3(moveX, 0, -moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
