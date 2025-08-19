using UnityEngine;

public class CellFactory: MonoBehaviour
{
    public Cell GetCell(Cell owner)
    {
        Cell spawnedCell = Instantiate(owner, Vector3.zero, Quaternion.identity);
        return spawnedCell;
    }
}
