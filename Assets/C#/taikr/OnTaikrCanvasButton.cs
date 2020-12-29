using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTaikrCanvasButton : MonoBehaviour
{
    private GameObject backpack;
    private void Start()
    {
        //Backpack
        backpack = transform.Find("Backpack").gameObject;
    }
    public void OnBackpackButton()
    {
        backpack.SetActive(true);
    }
}