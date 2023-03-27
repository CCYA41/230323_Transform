using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundBall : MonoBehaviour
{
    // ����
    // 1. �ð踸��� ��ħ�� ��ħ �����
    // 2. ��ħ�� ��ħ�� ť�긦 �޾Ƽ� �� ħ�� ������ �°� ��￩��
    // 3. ��� ������ �θ�� �ڽ� ������Ʈ�� ����
    // 4. �ð��� ǥ���ϴ� �ð� �ε������͸� �ڵ����� ��ġ�ϱ�
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
        // Clamp�� ��밡��
        if (angle > 360f) angle = 0f;

        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = 0f;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad);
        ballTr.position = new Vector3(x, y, z);
    }
}
