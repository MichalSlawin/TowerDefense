using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private static Vector3 finish;
    private static int playerHealth = 10;
    private static TextMeshProUGUI hpText;
    private GameObject startButton;
    private UIController uIController;
    private BuildingController buildingController;
    private int turn = 0;
    private Respawn respawn;
    private int money = 25;
    
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

    public int Money
    {
        get => money;
        set
        {
            money = value;
            uIController.SetMoneyText(value);
        }
    }

    private void Start()
    {
        respawn = FindObjectOfType<Respawn>();
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>().position;

        hpText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        hpText.text = playerHealth.ToString();

        buildingController = FindObjectOfType<BuildingController>();
        uIController = FindObjectOfType<UIController>();
        startButton = GameObject.Find("StartButton");

        uIController.SetMoneyText(money);
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
                if (selectedObject.CompareTag("BuildArea") && !EventSystem.current.IsPointerOverGameObject())
                {
                    BuildArea buildArea = selectedObject.GetComponent<BuildArea>();
                    buildingController.BuildArea = buildArea;

                    if(buildArea.Occupied)
                    {
                        uIController.ToggleDestroyMenu();
                    }
                    else
                    {
                        uIController.ToggleBuildingsMenu();
                    }
                }
            }
        }
    }

    public void StartTurn()
    {
        turn++;
        respawn.CubesNumber = Respawn.BaseCubesNumber * turn;
        respawn.SmallCubesNumber = Respawn.BaseSmallCubesNumber * turn;

        if (turn > 3) respawn.RespawnTime = 0.5f;
        else if (turn > 7) respawn.RespawnTime = 0.25f;

        respawn.StartTurn();
    }

    public void NextTurn()
    {
        startButton.SetActive(true);
    }
}
