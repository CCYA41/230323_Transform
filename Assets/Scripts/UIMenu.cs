using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ��ǰ�� �ϳ��� ����� ��������
// ��ǰ�� �ΰ��� ����� �߽����� �¿� ����
// ��ǰ�� ������ ����� �߽����� �¿� ����
// ��ǰ�� �����̻��̸� ������߽����� 3���� ǥ���� �ٹٲ� �� ����

// Ÿ��Ʋ�޴� ����, �¿�� �������
// col�� ������ ���缭 1 row�� ǥ�õ� ��ư�� ũ�⸦ �ڵ����� ����
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
            // 5���̻��� y�ຯ�浵 ����ؾ���
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
