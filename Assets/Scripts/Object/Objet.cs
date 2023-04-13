using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour
{
     public enum EType { Plugged, Unplugged}

    [SerializeField] protected string productName = "Unkwon";
    [SerializeField] protected EType type = EType.Unplugged;


}
