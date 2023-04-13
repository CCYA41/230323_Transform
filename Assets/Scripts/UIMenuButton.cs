using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenuButton : MonoBehaviour
{
    public enum EMBInfo { Name, Price, Stock };

    [SerializeField]
    private TextMeshProUGUI[] texts = null;
    private void Awake()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        //foreach(TextMeshProUGUI text in texts)
        //{
        //    Debug.Log(text.name);
        //}
    }

    //private void Start()
    //{
    //    InitInfos("ÄÝ¶ó", 600, 3);
    //}

    public void InitInfos(string _name, int _price, int _stock)
    {
        texts[(int)EMBInfo.Name].text = _name;
        texts[(int)EMBInfo.Price].text = _price.ToString();
        texts[(int)EMBInfo.Stock].text = _stock.ToString();
    }

    public void InitInfos(VendingMachine.SProductInfo _productInfo)
    {
        InitInfos(VendingMachine.VMProductToName(_productInfo.product), _productInfo.price, _productInfo.stock);
    }
}
