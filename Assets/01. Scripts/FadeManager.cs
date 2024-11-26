using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance; // �̱��� ����
    public Image fadeImage; // ���̵� ȿ���� �� UI �̹���
    public float fadeDuration = 1.0f; // ���̵� ȿ���� �Ϸ�Ǵ� �� �ɸ��� �ð�(��)
    private bool isFading = false; // ���� ���̵� ������ ���θ� �����ϴ� �÷���

    private void Awake()
    {
        if (Instance == null) // �̱��� �ν��Ͻ��� ���� ���
        {
            Instance = this; // ���� ��ü�� �ν��Ͻ��� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ �Ŀ��� �� ������Ʈ�� ����
        }
        else // �̹� �̱��� �ν��Ͻ��� �����ϴ� ���
        {
            Destroy(gameObject); // �ߺ��� ������Ʈ�� ����
        }
    }

    public void FadeToScene(string sceneName) // �� ��ȯ ��û �޼���
    {
        if (!isFading) // ���̵尡 ���� ������ ���� ���� ����
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName)); // ���̵� �ƿ� �� �� ��ȯ �ڷ�ƾ ����
        }
    }

    private IEnumerator FadeIn() // ȭ���� ��� �ϴ� ���̵� �� ȿ���� ó���ϴ� �ڷ�ƾ
    {
        isFading = true; // ���̵� ���� ����
        fadeImage.gameObject.SetActive(true); // ���̵� �̹����� Ȱ��ȭ
        float time = 0f; // ��� �ð� �ʱ�ȭ
        while (time < fadeDuration) // ���̵� �ð��� ���� ������ �ݺ�
        {
            time += Time.deltaTime; // ��� �ð� ����
            float alpha = 1 - (time / fadeDuration); // ���� �� ��� (���� ��������)
            fadeImage.color = new Color(0, 0, 0, alpha); // ���� �� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }
        fadeImage.color = new Color(0, 0, 0, 0); // ������ �����ϰ� ����
        fadeImage.gameObject.SetActive(false); // ���̵� �̹����� ��Ȱ��ȭ
        isFading = false; // ���̵� ���� ����
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName) // ���̵� �ƿ� �� �� ��ȯ�� ó���ϴ� �ڷ�ƾ
    {
        isFading = true; // ���̵� ���� ����
        fadeImage.gameObject.SetActive(true); // ���̵� �̹����� Ȱ��ȭ
        float time = 0f; // ��� �ð� �ʱ�ȭ
        while (time < fadeDuration) // ���̵� �ð��� ���� ������ �ݺ�
        {
            time += Time.deltaTime; // ��� �ð� ����
            float alpha = time / fadeDuration; // ���� �� ��� (���� ����������)
            fadeImage.color = new Color(0, 0, 0, alpha); // ���� �� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }
        fadeImage.color = new Color(0, 0, 0, 1); // ������ �������ϰ� ����

        // �� �ε�
        yield return SceneManager.LoadSceneAsync(sceneName); // �񵿱������� �� ��ȯ

        // ���̵� �� ����
        StartCoroutine(FadeIn()); // ȭ���� ��� �ϴ� ���̵� �� �ڷ�ƾ ����
    }

    private void Start() // ��ũ��Ʈ�� ���۵� �� ȣ��Ǵ� Unity �޼���
    {
        StartCoroutine(FadeIn()); // ó�� �� ���� �� ���̵� �� ȿ���� ����
    }
}
