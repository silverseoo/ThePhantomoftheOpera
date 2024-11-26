using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    void Update() // 매 프레임마다 호출
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자 키 1이 눌렸는지 확인
        {
            FadeManager.Instance.FadeToScene("ChandelierScene"); // 페이드 효과와 함께 "ChandelierScene"으로 씬 전환
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 숫자 키 2가 눌렸는지 확인
        {
            FadeManager.Instance.FadeToScene("BoatScene"); // 페이드 효과와 함께 "BoatScene"으로 씬 전환
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 숫자 키 3이 눌렸는지 확인
        {
            FadeManager.Instance.FadeToScene("BridgeScene"); // 페이드 효과와 함께 "BridgeScene"으로 씬 전환
        }
    }
}
