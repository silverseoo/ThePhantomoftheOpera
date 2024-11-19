using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키 1
        {
            FadeManager.Instance.FadeToScene("ChandelierScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 키 2
        {
            FadeManager.Instance.FadeToScene("BoatScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 키 3
        {
            FadeManager.Instance.FadeToScene("BridgeScene");
        }
    }
}
