using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance; // �̱��� ������ �����Ͽ� ��𼭳� ���� �����ϰ� ��

    private void Awake() // Unity���� ��ü�� ������ �� ���� ���� ȣ��Ǵ� �޼���
    {
        if (Instance == null) // �̱��� �ν��Ͻ��� ���� �������� ���� ���
        {
            Instance = this; // ���� ��ü�� �ν��Ͻ��� ����
            DontDestroyOnLoad(gameObject); // �� ���� ������Ʈ�� ���� �ٲ� �ı����� �ʵ��� ����
        }
        else // �̹� �̱��� �ν��Ͻ��� �����ϴ� ���
        {
            Destroy(gameObject); // �ߺ��� ���� ������Ʈ�� ����
        }
    }
}
