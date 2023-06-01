public interface IInteractable
{
    bool IsButton { get; }
    void OnPointerEnter();
    void OnPointerExit();
    void OnPointerClick();
}

