using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour // UI ���̵� ��/�ƿ� ȿ���� �����ϴ� Ŭ����
{
    public Image fadeImage; // ���̵� ȿ���� ����� ĵ������ Image ������Ʈ�� ����
    public float fadeDuration = 1f; // ���̵� ȿ���� ���� �ð�(��)

    private void Start()
    {
        // ���� ���۵� �� �ڵ����� ���̵� �� ȿ���� ����
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn() // ȭ���� ��� �ϴ� ���̵� �� ȿ���� ������ �ڷ�ƾ
    {
        float time = 0; // ��� �ð� �ʱ�ȭ
        while (time < fadeDuration) // ���̵� �ð��� ���� ������ ����
        {
            time += Time.deltaTime; // ��� �ð� ����
            float alpha = 1 - (time / fadeDuration); // ���� ���� ���� ���� (ȭ���� �����)
            fadeImage.color = new Color(0, 0, 0, alpha); // ���� �� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }
        fadeImage.color = new Color(0, 0, 0, 0); // ���̵尡 ������ ������ �����ϰ� ����
    }

    public IEnumerator FadeOut() // ȭ���� ��Ӱ� �ϴ� ���̵� �ƿ� ȿ���� ������ �ڷ�ƾ
    {
        float time = 0; // ��� �ð� �ʱ�ȭ
        while (time < fadeDuration) // ���̵� �ð��� ���� ������ ����
        {
            time += Time.deltaTime; // ��� �ð� ����
            float alpha = time / fadeDuration; // ���� ���� ���� ���� (ȭ���� ��ο���)
            fadeImage.color = new Color(0, 0, 0, alpha); // ���� �� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }
        fadeImage.color = new Color(0, 0, 0, 1); // ���̵尡 ������ ������ �˰� ����
    }

    // �� ��ȯ �� ȣ���� �Լ�
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName)); // ���̵� ȿ���� �Բ� �� ��ȯ ����
    }

    private IEnumerator Transition(string sceneName) // ���̵� ȿ���� �� ��ȯ�� ������ �ڷ�ƾ
    {
        yield return StartCoroutine(FadeOut()); // ȭ���� ��Ӱ� �ϴ� ���̵� �ƿ� ȿ�� ����
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // ������ ������ ��ȯ
    }
}
