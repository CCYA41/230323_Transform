using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Electronics : Objet
{
    [SerializeField] private int price = 0;
    // 전원 커넥어가 연결되었는지 확인
    [SerializeField] private bool isPlugConnect = true;
    [SerializeField] private bool isPowerOn = false;


    public int Price { get { return price; } }
    // Inline Function
    public bool GetIsPowerOn() { return isPowerOn; }

    public virtual void Awake()
    {
        type = EType.Plugged;
    }

    public void PowerOn()
    {

        if (isPlugConnect)
        {
            isPowerOn = true;
            Debug.Log(productName + "Power On");
        }
    }
    public void PowerOff()
    {
        if (isPowerOn)
        {
            isPowerOn = false;
            Debug.Log(productName + "Power Off");
        }
    }
    public abstract void Use();


}
