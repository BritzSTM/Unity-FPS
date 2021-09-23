using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    private TMP_Text _text;
    private Player _player;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void Assign(Player player)
    {
        _player = player;

        _text.text = player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (_player != otherPlayer)
            return;

        Destroy(gameObject);
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
