using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public enum EVMProduct
    { Coke, Tissue, Bread, Letsbe, Vita500, OronamicC, Sprite, SSOrange }



    [System.Serializable]
    public struct SProductInfo
    {
        public EVMProduct product;
        public int price;
        public int stock;
    }

    [SerializeField] private UIMenu uiMenu = null;
    private void Awake()
    {
        if (uiMenu == null)
        {
            Debug.LogError("UIMenu is missing!");
            return;
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (uiMenu)
            {
                uiMenu.BuildButtons(productListInfo);
                uiMenu.gameObject.SetActive(true);
            }
        }


    }
    public static string VMProductToName(EVMProduct _product)
    {
        switch (_product)
        {
            case EVMProduct.Coke: return "�ݶ�";
            case EVMProduct.Tissue: return "����";
            case EVMProduct.Bread: return "��";
            case EVMProduct.Letsbe: return "������";
            case EVMProduct.Vita500: return "��Ÿ500";
            case EVMProduct.OronamicC: return "���γ���C";
            case EVMProduct.Sprite: return "��������Ʈ";
            case EVMProduct.SSOrange: return "�ٽ� ������";
            default: return "��";
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (uiMenu)
            {
                uiMenu.gameObject.SetActive(false);
            }
        }
    }
    // Template
    [SerializeField]
    private List<SProductInfo> productListInfo = new List<SProductInfo>();
}
