using UnityEngine;

public interface IViewUpdater
{
    public void ShowText(string text);
    public void UpdateVisual(Color color); 
    public Vector3 GetDefaultScale();
    public void ShowScale(Vector3 scale);
}
