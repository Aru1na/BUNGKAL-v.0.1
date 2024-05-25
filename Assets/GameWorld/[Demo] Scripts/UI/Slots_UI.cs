using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slots_UI : MonoBehaviour
{

    public Image icon;
    public bool empty = true;
    public void SetItem(Artifacts art){
        icon.sprite = art.icon;
        icon.color = new Color(1,1,1,1);  
        empty = false;
        gameObject.SetActive(true);
    }


}
