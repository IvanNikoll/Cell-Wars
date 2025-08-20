using System;

public interface IClickable
{
    public event Action<CellView> Clicked;
    public void OnClick();
}
