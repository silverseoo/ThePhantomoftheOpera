using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // 싱글톤 인스턴스
    public Image fadeImage; // 페이드 효과를 줄 UI 이미지
    public float fadeDuration = 1f; // 페이드 시간
    private bool isFading = false; // 페이드 중인지 확인

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 후에도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    public void FadeToScene(string sceneName)
    {
        if (!isFading) // 이미 페이드 중이라면 무시
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true); // 페이드 이미지 활성화
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);
        fadeImage.gameObject.SetActive(false); // 페이드 이미지 비활성화
        isFading = false;
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true); // 페이드 이미지 활성화
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = time / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1);

        // 씬 로드
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 페이드 인
        StartCoroutine(FadeIn());
    }

    private void Start()
    {
        StartCoroutine(FadeIn()); // 처음 시작할 때 페이드인
    }
}
