using UnityEngine;

public class CellController : MonoBehaviour
{
    
    private Cell _cell;
    private CellView _cellView; 
    public CellController(Cell cell, CellView cellView)
    {
        _cell = cell;
        _cellView = cellView;
    }


}
