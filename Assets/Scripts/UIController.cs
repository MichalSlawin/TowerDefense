﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject buildingsMenu = null;
    private TextMeshProUGUI moneyText;

    private void Start()
    {
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
    }

    public void SetMoneyText(int money)
    {
        moneyText.text = money.ToString();
    }

    public void ToggleBuildingsMenu()
    {
        buildingsMenu.SetActive(!buildingsMenu.activeSelf);
    }
}
