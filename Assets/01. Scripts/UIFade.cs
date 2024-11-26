using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour // UI 페이드 인/아웃 효과를 관리하는 클래스
{
    public Image fadeImage; // 페이드 효과를 담당할 캔버스의 Image 컴포넌트를 연결
    public float fadeDuration = 1f; // 페이드 효과의 지속 시간(초)

    private void Start()
    {
        // 씬이 시작될 때 자동으로 페이드 인 효과를 실행
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn() // 화면을 밝게 하는 페이드 인 효과를 구현한 코루틴
    {
        float time = 0; // 경과 시간 초기화
        while (time < fadeDuration) // 페이드 시간이 끝날 때까지 실행
        {
            time += Time.deltaTime; // 경과 시간 증가
            float alpha = 1 - (time / fadeDuration); // 알파 값을 점차 줄임 (화면이 밝아짐)
            fadeImage.color = new Color(0, 0, 0, alpha); // 알파 값 업데이트
            yield return null; // 다음 프레임까지 대기
        }
        fadeImage.color = new Color(0, 0, 0, 0); // 페이드가 끝나면 완전히 투명하게 설정
    }

    public IEnumerator FadeOut() // 화면을 어둡게 하는 페이드 아웃 효과를 구현한 코루틴
    {
        float time = 0; // 경과 시간 초기화
        while (time < fadeDuration) // 페이드 시간이 끝날 때까지 실행
        {
            time += Time.deltaTime; // 경과 시간 증가
            float alpha = time / fadeDuration; // 알파 값을 점차 증가 (화면이 어두워짐)
            fadeImage.color = new Color(0, 0, 0, alpha); // 알파 값 업데이트
            yield return null; // 다음 프레임까지 대기
        }
        fadeImage.color = new Color(0, 0, 0, 1); // 페이드가 끝나면 완전히 검게 설정
    }

    // 씬 전환 시 호출할 함수
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName)); // 페이드 효과와 함께 씬 전환 실행
    }

    private IEnumerator Transition(string sceneName) // 페이드 효과와 씬 전환을 조합한 코루틴
    {
        yield return StartCoroutine(FadeOut()); // 화면을 어둡게 하는 페이드 아웃 효과 실행
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // 지정된 씬으로 전환
    }
}
