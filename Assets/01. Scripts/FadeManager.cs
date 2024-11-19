using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // �̱��� �ν��Ͻ�
    public Image fadeImage; // ���̵� ȿ���� �� UI �̹���
    public float fadeDuration = 1f; // ���̵� �ð�
    private bool isFading = false; // ���̵� ������ Ȯ��

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

    public void FadeToScene(string sceneName)
    {
        if (!isFading) // �̹� ���̵� ���̶�� ����
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true); // ���̵� �̹��� Ȱ��ȭ
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);
        fadeImage.gameObject.SetActive(false); // ���̵� �̹��� ��Ȱ��ȭ
        isFading = false;
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true); // ���̵� �̹��� Ȱ��ȭ
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = time / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1);

        // �� �ε�
        yield return SceneManager.LoadSceneAsync(sceneName);

        // ���̵� ��
        StartCoroutine(FadeIn());
    }

    private void Start()
    {
        StartCoroutine(FadeIn()); // ó�� ������ �� ���̵���
    }
}
