using System.Collections;       // IEnumerator를 위한 네임스페이스
using UnityEngine;              // Unity 관련 클래스
using UnityEngine.UI;           // UI 컴포넌트를 위한 네임스페이스

public class UIFade : MonoBehaviour
{
    public Image fadeImage; // 캔버스의 Image 컴포넌트를 연결
    public float fadeDuration = 1f; // 페이드 시간

    private void Start()
    {
        // 처음 시작할 때 페이드 인 효과
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1 - (time / fadeDuration); // Alpha 값을 점차 낮춤
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0); // 완전히 투명
    }

    public IEnumerator FadeOut()
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = time / fadeDuration; // Alpha 값을 점차 높임
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1); // 완전히 검게
    }

    // 씬 전환 시 호출할 함수
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        yield return StartCoroutine(FadeOut()); // 페이드 아웃
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // 씬 전환
    }
}
