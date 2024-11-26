using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // 싱글톤 패턴
    public Image fadeImage; // 페이드 효과를 줄 UI 이미지
    public float fadeDuration = 1.0f; // 페이드 효과가 완료되는 데 걸리는 시간(초)
    private bool isFading = false; // 현재 페이드 중인지 여부를 추적하는 플래그

    private void Awake()
    {
        if (Instance == null) // 싱글톤 인스턴스가 없을 경우
        {
            Instance = this; // 현재 객체를 인스턴스로 설정
            DontDestroyOnLoad(gameObject); // 씬 전환 후에도 이 오브젝트를 유지
        }
        else // 이미 싱글톤 인스턴스가 존재하는 경우
        {
            Destroy(gameObject); // 중복된 오브젝트를 삭제
        }
    }

    public void FadeToScene(string sceneName) // 씬 전환 요청 메서드
    {
        if (!isFading) // 페이드가 진행 중이지 않을 때만 실행
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName)); // 페이드 아웃 후 씬 전환 코루틴 실행
        }
    }

    private IEnumerator FadeIn() // 화면을 밝게 하는 페이드 인 효과를 처리하는 코루틴
    {
        isFading = true; // 페이드 상태 설정
        fadeImage.gameObject.SetActive(true); // 페이드 이미지를 활성화
        float time = 0f; // 경과 시간 초기화
        while (time < fadeDuration) // 페이드 시간이 끝날 때까지 반복
        {
            time += Time.deltaTime; // 경과 시간 증가
            float alpha = 1 - (time / fadeDuration); // 알파 값 계산 (점점 투명해짐)
            fadeImage.color = new Color(0, 0, 0, alpha); // 알파 값 업데이트
            yield return null; // 다음 프레임까지 대기
        }
        fadeImage.color = new Color(0, 0, 0, 0); // 완전히 투명하게 설정
        fadeImage.gameObject.SetActive(false); // 페이드 이미지를 비활성화
        isFading = false; // 페이드 상태 해제
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName) // 페이드 아웃 후 씬 전환을 처리하는 코루틴
    {
        isFading = true; // 페이드 상태 설정
        fadeImage.gameObject.SetActive(true); // 페이드 이미지를 활성화
        float time = 0f; // 경과 시간 초기화
        while (time < fadeDuration) // 페이드 시간이 끝날 때까지 반복
        {
            time += Time.deltaTime; // 경과 시간 증가
            float alpha = time / fadeDuration; // 알파 값 계산 (점점 불투명해짐)
            fadeImage.color = new Color(0, 0, 0, alpha); // 알파 값 업데이트
            yield return null; // 다음 프레임까지 대기
        }
        fadeImage.color = new Color(0, 0, 0, 1); // 완전히 불투명하게 설정

        // 씬 로드
        yield return SceneManager.LoadSceneAsync(sceneName); // 비동기적으로 씬 전환

        // 페이드 인 실행
        StartCoroutine(FadeIn()); // 화면을 밝게 하는 페이드 인 코루틴 실행
    }

    private void Start() // 스크립트가 시작될 때 호출되는 Unity 메서드
    {
        StartCoroutine(FadeIn()); // 처음 씬 시작 시 페이드 인 효과를 실행
    }
}
