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
    private int money = 50;
    
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
        Application.targetFrameRate = 60;

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
        respawn.CubesNumber = turn;
        respawn.SmallCubesNumber = turn;

        if (turn > 3)
        {
            respawn.RespawnTime = 0.5f;
            respawn.BigCubesNumber = turn - 3;
        }
        if (turn > 7)
        {
            respawn.RespawnTime = 0.25f;
            respawn.BigCubesNumber = turn - 7;
            respawn.BossCubesNumber = turn - 7;
        }
        if (turn > 13)
        {
            respawn.CubesNumber = turn - 7;
            respawn.SmallCubesNumber = turn - 7;
            respawn.BigCubesNumber = turn - 13;
            respawn.BossCubesNumber = turn - 13;
            respawn.SmallBossCubesNumber = turn - 13;
        }
        if (turn > 17)
        {
            respawn.CubesNumber = turn - 13;
            respawn.SmallCubesNumber = turn - 13;
            respawn.BigCubesNumber = turn - 17;
            respawn.BossCubesNumber = turn - 17;
            respawn.SmallBossCubesNumber = turn - 17;
            respawn.SplitEnemyNumber = turn - 17;
        }
        respawn.StartTurn();
    }

    public void NextTurn()
    {
        startButton.SetActive(true);
    }
}
