using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopDialogue : MonoBehaviour
{
    public new string name;
    [TextArea(3, 10)]
    public string[] sentences;
}
