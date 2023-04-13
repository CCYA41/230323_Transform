using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 상품이 하나면 가운데를 기준정렬
// 상품이 두개면 가운데를 중심으로 좌우 정렬
// 상품이 세개면 가운데를 중심으로 좌우 정렬
// 상품이 세개이상이면 가운데를중심으로 3개를 표시후 줄바꿈 후 정렬

// 타이틀메뉴 공간, 좌우로 여백삽입
// col의 갯수에 맞춰서 1 row에 표시될 버튼의 크기를 자동으로 조절
public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBtnPrefab = null;

    private List<UIMenuButton> menuBtnList = null;

    public void BuildButtons(List<VendingMachine.SProductInfo> _productInfoList)
    {
        if (_productInfoList == null || _productInfoList.Count == 0) return;

        if (menuBtnList != null && menuBtnList.Count > 0)
            ClearMenuButtonList();

        menuBtnList = new List<UIMenuButton>();
        //menuBtnList.Clear();

        for (int i = 0; i < _productInfoList.Count; i++)
        {
            GameObject go = Instantiate(menuBtnPrefab);
            //go.transform.SetParent(transform);
            //go.transform.localPosition = Vector3.zero;
            RectTransform rectTr = go.GetComponent<RectTransform>();
            rectTr.SetParent(GetComponent<RectTransform>());


            // Button & Font Size Setting
            switch (_productInfoList.Count)
            {
                case 1: rectTr.localScale = new Vector2(1, 1); break;
                case 2: rectTr.localScale = new Vector2(0.8f, 0.8f); break;
                case 3: rectTr.localScale = new Vector2(0.7f, 0.7f); break;
                default: rectTr.localScale = new Vector2(0.5f, 0.5f); break;
            }


            // Button Position
            // 5개이상은 y축변경도 고려해야함
            if (_productInfoList.Count < 5)
            {
                
            }
            else
            {

            }


            UIMenuButton btn = go.GetComponent<UIMenuButton>();
            btn.InitInfos(_productInfoList[i]);

            menuBtnList.Add(btn);
        }
    }

    private void ClearMenuButtonList()
    {
        // Range Based Loop
        foreach (UIMenuButton btn in menuBtnList)
        {
            Destroy(btn.gameObject);
        }
        menuBtnList.Clear();
    }
}
