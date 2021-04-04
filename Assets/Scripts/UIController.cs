using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject buildingsMenu = null;

    public void ToggleBuildingsMenu()
    {
        buildingsMenu.SetActive(!buildingsMenu.activeSelf);
    }
}
