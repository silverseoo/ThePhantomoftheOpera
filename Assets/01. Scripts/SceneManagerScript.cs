using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    void Update()
    {
        // Ű �Է� Ȯ��
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� Ű 1
        {
            SceneManager.LoadScene("ChandelierScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� Ű 2
        {
            SceneManager.LoadScene("VoatScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // ���� Ű 3
        {
            SceneManager.LoadScene("BridgeScene");
        }
       
    }
}
