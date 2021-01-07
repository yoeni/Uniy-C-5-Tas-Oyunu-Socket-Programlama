using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public static uiManager instance;
    public InputField username;
    public GameObject panel;
    public GameObject[] tas;
    public GameObject banner;
    public GameObject tahtam;
    load tahtaScript;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=null)
        {
            Debug.Log("instance already exists");
            Destroy(this);
        }
    }
    private void Start()
    {
        tahtaScript = tahtam.GetComponent<load>();
    }
    public void connectToServer()
    {
        //setPanel(false);
        username.interactable = false;
        client.instance.ConnectToServer();
    }
    public void onePlayer()
    {
        setPanel(false);
    }
    public void setPanel(bool panelState)
    {
        if (!panelState)
        {
            foreach (GameObject item in tas)
            {
                item.SetActive(true);
            }
            banner.SetActive(true);
        }
        else
        {
            foreach (GameObject item in tas)
            {
                item.SetActive(false);
            }
            banner.SetActive(false);
            username.interactable = true;
        }
        tahtaScript.StartManual();
        panel.SetActive(panelState);
    }
    public void setPanelToServer(bool panelState)
    {
        tahtaScript.StartManual();
        panel.SetActive(panelState);
    }
}
