using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] Turret turretCubePrefab = null;
    [SerializeField] Turret bigTurretCubePrefab = null;

    private BuildArea buildArea;

    public BuildArea BuildArea { get => buildArea; set => buildArea = value; }

    private void PlaceTurret(Turret turretPrefab)
    {
        if(!buildArea.Occupied)
        {
            Vector3 pos = new Vector3(BuildArea.transform.position.x, turretCubePrefab.transform.localScale.y, BuildArea.transform.position.z);

            Instantiate(turretPrefab, pos, Quaternion.identity);
            BuildArea.Occupied = true;
        }
    }

    public void PlaceTurretCube()
    {
        PlaceTurret(turretCubePrefab);
    }

    public void PlaceBigTurretCube()
    {
        PlaceTurret(bigTurretCubePrefab);
    }
}
