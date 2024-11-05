using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    void Update()
    {
        // 키 입력 확인
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키 1
        {
            SceneManager.LoadScene("ChandelierScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 키 2
        {
            SceneManager.LoadScene("VoatScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 키 3
        {
            SceneManager.LoadScene("BridgeScene");
        }
       
    }
}
