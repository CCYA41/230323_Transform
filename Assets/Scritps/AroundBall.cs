using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[ExecuteInEditMode]
public class AroundBall : MonoBehaviour
{
    // Rotation Direction
    // CW: Clockwise CCW: Counter Clockwise

    private enum ERotDir { CW, CCW }
    private enum ERotType { Pitch, Yaw, Roll };


    #region Variables
    [Header("- GameObjects -")]
    [SerializeField] private GameObject ballPreFab = null;
    [SerializeField] private Transform targetTr = null;

    [Header("- Values -")]
    [SerializeField, Range(0f, 300f)] private float angleSpeed = 10f;
    [SerializeField, Range(0f, 10f)] private float distnceRange = 1f;

    [Header("- Type -")]
    [SerializeField] private ERotDir rotDir = ERotDir.CCW;
    [SerializeField] private ERotType rotType = ERotType.Yaw;

    #endregion

    // ����
    // 1. �ð踸��� ��ħ�� ��ħ �����
    // 2. ��ħ�� ��ħ�� ť�긦 �޾Ƽ� �� ħ�� ������ �°� ��￩��
    // 3. ��� ������ �θ�� �ڽ� ������Ʈ�� ����
    // 4. �ð��� ǥ���ϴ� �ð� �ε������͸� �ڵ����� ��ġ�ϱ�
    private Transform ballTr = null;

    private float angle = 0f;



    public class TestClass
    {
        public int i;
    }
    public struct TestStruct
    {
        public int i;
    }
    //private void Test()
    //{
    //    TestClass tc = new TestClass();
    //    tc.i = 1;
    //    TestClass cpyClass = tc;
    //    cpyClass.i = 10;
    //    Debug.Log("tc.i: " + tc.i);

    //    TestStruct ts = new TestStruct();
    //    ts.i = 1;
    //    TestStruct cpyStruct = ts;
    //    cpyStruct.i = 10;
    //    Debug.Log("ts.i: " + ts.i);


    //}


    private void Awake()
    {
        //Test();
        if (ballPreFab == null)
        {
            Debug.LogError("ballPreFab is missing!");
            return;
        }
        //ballTr = transform.GetChild(0);
        //Debug.Log(ballTr.name);

        GameObject go = Instantiate(ballPreFab);
        //go.transform.parent = transform;
        go.transform.SetParent(transform);
        ballTr = go.transform;

    }

    private void Update()
    {
        if (targetTr == null) return;

        switch (rotDir)
        {
            case ERotDir.CW:
                angle -= Time.deltaTime * angleSpeed;
                if (angle < 0f) angle = 360f;
                break;
            case ERotDir.CCW:
                angle += Time.deltaTime * angleSpeed;
                if (angle > 360f) angle = 0f;
                break;
        }

        // Clamp�� ��밡��

        //Mathf.Clamp(angle, 0f, 360f);

        Vector3 anglePos = new Vector3();
        CalcAnglePosWithRotType(rotType, angle, ref anglePos);

        Vector3 targetPos = (anglePos + targetTr.position) * distnceRange;
        ballTr.position = targetPos;
    }


    // ref : �������� ���� ������ �ʿ�� ����
    // out : ������������ ���� ������ �ٲ� ���� �����ϱ⋚���� �ݵ�� ���� �ٲ�����
    private void CalcAnglePosWithRotType(ERotType _rotType, float _angle, ref Vector3 _pos)
    {
        float angle2Rad = _angle * Mathf.Deg2Rad;
        switch (_rotType)
        {
            case ERotType.Pitch:
                _pos.x = 0f;
                _pos.y = Mathf.Sin(angle2Rad);
                _pos.z = Mathf.Cos(angle2Rad);
                break;
            case ERotType.Yaw:
                _pos.x = Mathf.Cos(angle2Rad);
                _pos.y = 0f;
                _pos.z = Mathf.Sin(angle2Rad);
                break;
            case ERotType.Roll:
                _pos.x = Mathf.Cos(angle2Rad);
                _pos.y = Mathf.Sin(angle2Rad);
                _pos.z = 0f;
                break;
        }
    }
}
