using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundBall : MonoBehaviour
{
    // 과제
    // 1. 시계만들기 초침과 분침 만들기
    // 2. 초침과 분침에 큐브를 달아서 각 침의 각도에 맞게 기울여서
    // 3. 모두 동잃한 부모와 자식 오브젝트로 구성
    // 4. 시간을 표시하는 시계 인디케이터를 자동으로 배치하기
    private Transform ballTr = null;

    private float angle = 0f;
    [SerializeField, Range(0f, 200f)]
    private float angleSpeed = 10f;

    private void Awake()
    {
        ballTr = transform.GetChild(0);
        Debug.Log(ballTr.name);
    }

    private void Update()
    {
        angle += Time.deltaTime * angleSpeed;
        // Clamp도 사용가능
        if (angle > 360f) angle = 0f;

        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = 0f;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad);
        ballTr.position = new Vector3(x, y, z);
    }
}
