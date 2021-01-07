using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    public GameObject tahtam;
    public GameObject panel;
    load tahtaScript;
    public GameObject trap;
    GameObject selected=null;
    public GameObject tasim;
    public Text gameStateText;
    public bool gameState = false;
    float seciliTopSatir = 0, seciliTopSutun = 0;
    int tasAdet = 0;
    float x = 10.52F;
    void Start()
    {
        tahtaScript = tahtam.GetComponent<load>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            seciliTopSatir = tasim.transform.position.x;
            seciliTopSutun = tasim.transform.position.y;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit)
            {
                GameObject clickObject = hit.collider.gameObject;
                if (clickObject.tag=="tas")
                {
                    selected = clickObject;
                }
                else if (selected!=null&&clickObject.tag!="trap")
                {
                    float mevTopX = clickObject.transform.position.x;
                    float mevTopY = clickObject.transform.position.y;
                    TextMesh metnim = selected.GetComponentInChildren<TextMesh>();
                    if (!gameState)
                    {
                        selected.transform.position = new Vector3(mevTopX, mevTopY, -1);
                        tahtaScript.tasMesafeOlcum();
                    }
                    else
                    {
                        if (int.Parse(metnim.text) > 0)
                        {
                            float seciliX = selected.transform.position.x;
                            float seciliY = selected.transform.position.y;
                            int mesafe = Convert.ToInt32((mevTopX > seciliX ? mevTopX - seciliX : seciliX - mevTopX) + (mevTopY > seciliY ? mevTopY - seciliY : seciliY - mevTopY));
                            Debug.Log($"({seciliTopSatir},{seciliTopSutun}) | ({mevTopX},{mevTopY}) - :{mesafe}");
                            if (mesafe == 1)
                            {
                                selected.transform.position = new Vector3(mevTopX, mevTopY, -1);
                                int mesafeHedef = Convert.ToInt32(metnim.text) - 1; 
                                
                                if (mesafeHedef == 0)
                                {

                                    if (seciliTopSatir == mevTopX && seciliTopSutun == mevTopY)
                                    {

                                        selected.SetActive(false);
                                        selected.transform.position = new Vector3(x, 6, -1);
                                        x++;
                                        tasAdet++;
                                        if (tasAdet == 6)
                                        {
                                            foreach (GameObject item in tahtaScript.tas)
                                            {
                                                item.SetActive(true);
                                            }
                                            gameStateText.text = "Oyun Bitti!..";
                                            gameStateText.color = Color.green;
                                            gameState = false;
                                            tahtaScript.tas[6].tag = "tas";
                                            tahtaScript.tasYerlestir(true);
                                        }


                                    }
                                    else
                                    {
                                        foreach (GameObject item in tahtaScript.tas)
                                        {
                                            item.SetActive(true);
                                        }
                                        gameStateText.text = "Oyun Bitti!..";
                                        gameStateText.color = Color.red;
                                        gameState = false;
                                        tahtaScript.tas[6].tag = "tas";
                                    }
                                }
                                metnim.text = mesafeHedef.ToString();
                                Debug.Log(metnim.text);
                            }
                        }
                    }
                    selected = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit)
            {
                GameObject clickObject = hit.collider.gameObject;
                Debug.Log(clickObject.tag + " : " + UnityEngine.Random.Range(0, 999));
                if (clickObject.tag == "tahtaParca")
                {
                    if (!gameState)
                    {

                        float mevTopX = clickObject.transform.position.x;
                        float mevTopY = clickObject.transform.position.y;

                        Instantiate(trap, new Vector3(mevTopX, mevTopY, -0.1F), Quaternion.identity);
                    }
                }
                else if(clickObject.tag=="trap")
                {
                    Destroy(clickObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tahtaScript.tasYerlestir(false);
            tahtaScript.finishManual();
            panel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool startCheck = false;
            foreach (GameObject item in tahtaScript.tas)
            {
                if (item.transform.position.x>10)
                {
                    startCheck = false;
                    break;
                }
                else
                {
                    startCheck = true;
                }
            }
            if (startCheck)
            {
                x = 10.52F;
                tasAdet = 0;
                gameStateText.color = Color.white;
                gameStateText.text = "Oyun Başladı";
                gameState = true;
                tahtaScript.tas[6].tag = "selected";
                tahtaScript.StartManual();
            }
        }
    }
}
