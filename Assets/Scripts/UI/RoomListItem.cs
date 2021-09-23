using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    private TMP_Text _text;
    private RoomInfo _roomInfo;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void Assign(RoomInfo info)
    {
        _roomInfo = info;

        _text.text = info.Name;
    }

    public void OnClick()
    {
        // 메뉴에 룸 접속 콜
    }
}
