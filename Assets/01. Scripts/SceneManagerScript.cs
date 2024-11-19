using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� Ű 1
        {
            FadeManager.Instance.FadeToScene("ChandelierScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� Ű 2
        {
            FadeManager.Instance.FadeToScene("BoatScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // ���� Ű 3
        {
            FadeManager.Instance.FadeToScene("BridgeScene");
        }
    }
}
