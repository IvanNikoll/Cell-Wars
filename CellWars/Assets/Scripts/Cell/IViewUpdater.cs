using UnityEngine;

public interface IViewUpdater
{
    public void ShowText(string text);
    public void UpdateVisual(); // Send player or enemy visual prefab here
    public Vector3 GetDefaultScale();
    public void ShowScale(Vector3 scale);
}
