public interface IMenuUI
{
    MenuUITypeSO TypeSO { get; }
    bool IsOpened { get; }

    void Open(bool immediate = false);
    void Close();
}