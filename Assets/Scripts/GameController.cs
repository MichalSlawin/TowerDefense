using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static Vector3 respawn;
    private static Vector3 finish;

    public static Vector3 Respawn { get => respawn; set => respawn = value; }
    public static Vector3 Finish { get => finish; set => finish = value; }

    private void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>().position;
    }
}
