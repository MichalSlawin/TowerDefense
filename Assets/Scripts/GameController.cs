using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private static Vector3 respawn;
    private static Vector3 finish;
    private static int playerHealth = 10;
    private static TextMeshProUGUI hpText;

    private BuildingController buildingController;

    public static Vector3 Respawn { get => respawn; set => respawn = value; }
    public static Vector3 Finish { get => finish; set => finish = value; }
    public static int PlayerHealth
    {
        get => playerHealth;

        set
        {
            playerHealth = value;
            hpText.text = playerHealth.ToString();
        }
    }

    private void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>().position;

        hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        hpText.text = playerHealth.ToString();

        buildingController = FindObjectOfType<BuildingController>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject selectedObject = hit.transform.gameObject;
                if (selectedObject.CompareTag("BuildArea"))
                {
                    BuildArea buildArea = selectedObject.GetComponent<BuildArea>();
                    buildingController.PlaceTurret(buildArea);
                }
            }
        }
    }
}
