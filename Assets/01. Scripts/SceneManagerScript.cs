using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    void Update() // �� �����Ӹ��� ȣ��
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� Ű 1�� ���ȴ��� Ȯ��
        {
            FadeManager.Instance.FadeToScene("ChandelierScene"); // ���̵� ȿ���� �Բ� "ChandelierScene"���� �� ��ȯ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� Ű 2�� ���ȴ��� Ȯ��
        {
            FadeManager.Instance.FadeToScene("BoatScene"); // ���̵� ȿ���� �Բ� "BoatScene"���� �� ��ȯ
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // ���� Ű 3�� ���ȴ��� Ȯ��
        {
            FadeManager.Instance.FadeToScene("BridgeScene"); // ���̵� ȿ���� �Բ� "BridgeScene"���� �� ��ȯ
        }
    }
}
