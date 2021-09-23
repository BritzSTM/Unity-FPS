using UnityEngine;

public class SimpleMenuUI : MonoBehaviour, IMenuUI
{
    [SerializeField] MenuUITypeSO _typeSO = null;
    public MenuUITypeSO TypeSO { get => _typeSO; }
    public bool IsOpened { get; private set; }

    public void Open(bool immediate)
    {
        // immediate는 무시됨

        gameObject.SetActive(true);
        IsOpened = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        IsOpened = false;
    }
}
