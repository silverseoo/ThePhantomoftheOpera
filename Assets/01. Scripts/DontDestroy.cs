using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance; // �̱��� �ν��Ͻ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �Ŀ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }
}
