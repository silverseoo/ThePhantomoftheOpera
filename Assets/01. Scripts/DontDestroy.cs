using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance; // 싱글톤 패턴을 구현하여 어디서나 접근 가능하게 함

    private void Awake() // Unity에서 객체가 생성될 때 가장 먼저 호출되는 메서드
    {
        if (Instance == null) // 싱글톤 인스턴스가 아직 생성되지 않은 경우
        {
            Instance = this; // 현재 객체를 인스턴스로 설정
            DontDestroyOnLoad(gameObject); // 이 게임 오브젝트를 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else // 이미 싱글톤 인스턴스가 존재하는 경우
        {
            Destroy(gameObject); // 중복된 게임 오브젝트를 삭제
        }
    }
}
