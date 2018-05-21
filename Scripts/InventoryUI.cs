using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    // Note: Open shop screen is controlled in Nicky_Behaviour.cs


    public GameObject shop_screen;
    public Button close_shop_screen;

    public void OnCloseButton()
    {
        shop_screen.SetActive(!shop_screen.activeSelf);
    }

    
}
