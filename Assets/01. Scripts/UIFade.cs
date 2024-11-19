using System.Collections;       // IEnumerator�� ���� ���ӽ����̽�
using UnityEngine;              // Unity ���� Ŭ����
using UnityEngine.UI;           // UI ������Ʈ�� ���� ���ӽ����̽�

public class UIFade : MonoBehaviour
{
    public Image fadeImage; // ĵ������ Image ������Ʈ�� ����
    public float fadeDuration = 1f; // ���̵� �ð�

    private void Start()
    {
        // ó�� ������ �� ���̵� �� ȿ��
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1 - (time / fadeDuration); // Alpha ���� ���� ����
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0); // ������ ����
    }

    public IEnumerator FadeOut()
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = time / fadeDuration; // Alpha ���� ���� ����
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1); // ������ �˰�
    }

    // �� ��ȯ �� ȣ���� �Լ�
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        yield return StartCoroutine(FadeOut()); // ���̵� �ƿ�
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // �� ��ȯ
    }
}
