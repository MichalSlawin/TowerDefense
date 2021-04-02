using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] Turret turretCubePrefab = null;
    [SerializeField] Turret bigTurretCubePrefab = null;

    public void PlaceTurret(BuildArea buildArea)
    {
        if(!buildArea.Occupied)
        {
            Vector3 pos = new Vector3(buildArea.transform.position.x, turretCubePrefab.transform.localScale.y, buildArea.transform.position.z);

            Instantiate(turretCubePrefab, pos, Quaternion.identity);
            buildArea.Occupied = true;
        }
    }
}
