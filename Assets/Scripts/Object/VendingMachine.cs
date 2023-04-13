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
            case EVMProduct.Coke: return "ÄÝ¶ó";
            case EVMProduct.Tissue: return "ÈÞÁö";
            case EVMProduct.Bread: return "»§";
            case EVMProduct.Letsbe: return "·¹¾²ºñ";
            case EVMProduct.Vita500: return "ºñÅ¸500";
            case EVMProduct.OronamicC: return "¿À·Î³ª¹ÎC";
            case EVMProduct.Sprite: return "½ºÇÁ¶óÀÌÆ®";
            case EVMProduct.SSOrange: return "½Ù½Ù ¿À·»Áö";
            default: return "¸ð¸§";
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
