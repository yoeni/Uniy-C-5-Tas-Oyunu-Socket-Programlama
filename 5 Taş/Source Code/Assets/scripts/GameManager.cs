using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject panel;
    uiManager ui;
    private void Start()
    {
        ui = panel.GetComponent<uiManager>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    } 
    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        _position.x = 10.56F;
        _position.z = -1;
        if (_id == client.instance.myId)
        {
            _position.y = 6;
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _position.y = 7;
            _player = Instantiate(playerPrefab, _position, _rotation);
        }
        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
        ui.setPanelToServer(false);
    }
}
