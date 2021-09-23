using System.Collections.Generic;
using UnityEngine;
using Fd;

public class MenuManager : MonoBehaviour
{
    [RequiredType(typeof(IMenuUI))] [SerializeField] private Object[] _menus;

    private Dictionary<MenuUITypeSO, IMenuUI> _menuDic;

    private void Awake()
    {
        BuildMenus();
    }

    public void SwitchMenu(MenuUITypeSO menuTypeSO)
    {
        if (!_menuDic.ContainsKey(menuTypeSO))
            return;

        if(!_menuDic[menuTypeSO].IsOpened)
            _menuDic[menuTypeSO].Open();
        else
            _menuDic[menuTypeSO].Close();
    }

    private void BuildMenus()
    {
        _menuDic = new Dictionary<MenuUITypeSO, IMenuUI>();

        foreach (IMenuUI ui in _menus)
        {
            _menuDic.Add(ui.TypeSO, ui);
        }
    }
}
