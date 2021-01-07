using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class load : MonoBehaviour
{
    public GameObject tahtaParcam;
    public GameObject tahtaParcam2;
    public GameObject[] tas;
    public TextMesh[] text;
    public GameObject banner;
    public List<List<int>> tahtam = new List<List<int>>();
    List<List<GameObject>> tahtaParcalarim = new List<List<GameObject>>();
    public float seciliTopSatir = 0, seciliTopSutun = 0;
    public void Start()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
    }
    public void StartManual()
    {

        tahtaParcaReset();
        tahtaYerlestir();
        tasMesafeOlcum();

    }
    public void finishManual()
    {
        foreach (List<GameObject> item in tahtaParcalarim)
        {
            foreach (GameObject item2 in item)
            {
                Destroy(item2);
            }
        }
        tahtam.Clear();
        foreach (GameObject item in tas)
        {
            item.SetActive(false);
        }
        banner.SetActive(false);

    }
    void tahtaParcaReset()
    {
        foreach (List<GameObject> item in tahtaParcalarim)
        {
            foreach (GameObject item2 in item)
            {
                GameObject.Destroy(item2);
            }
        }
        tahtam.Clear();
        for (int k = 0; k < 10; k++)
        {
            List<int> sutunlar = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                sutunlar.Add(0);
            }
            tahtam.Add(sutunlar);
        }
    }
    public void tasMesafeOlcum()
    {
        seciliTopSatir = tas[6].transform.position.x;
        seciliTopSutun = tas[6].transform.position.y;
        for (int k = 0; k < tas.Length-1; k++)
        {
            float mevTopX = tas[k].transform.position.x;
            float mevTopY = tas[k].transform.position.y;
            if (mevTopX<10)
            {
                int mesafe = Convert.ToInt32((mevTopX > seciliTopSatir ? mevTopX - seciliTopSatir : seciliTopSatir - mevTopX) + (mevTopY > seciliTopSutun ? mevTopY - seciliTopSutun : seciliTopSutun - mevTopY));
                text[k].text = mesafe.ToString();
            }
        }

    }
    void tahtaYerlestir()
    {
        for (int i = 0; i < tahtam.Count; i++)
        {
            List<GameObject> satirTahtaParcalarm = new List<GameObject>();
            for (int k = 0; k < (tahtam[i]).Count; k++)
            {
                if (i % 2 == 0)
                {
                    if (k % 2 == 0)
                    {
                        satirTahtaParcalarm.Add(Instantiate(tahtaParcam, new Vector3(i, k, 0), Quaternion.identity));
                    }
                    else
                    {

                        satirTahtaParcalarm.Add(Instantiate(tahtaParcam2, new Vector3(i, k, 0), Quaternion.identity));
                    }
                }
                else
                {
                    if (k % 2 == 1)
                    {
                        satirTahtaParcalarm.Add(Instantiate(tahtaParcam, new Vector3(i, k, 0), Quaternion.identity));
                    }
                    else
                    {

                        satirTahtaParcalarm.Add(Instantiate(tahtaParcam2, new Vector3(i, k, 0), Quaternion.identity));
                    }
                }
            }
            tahtaParcalarim.Add(satirTahtaParcalarm);
        }
    }
    public void tasYerlestir(bool resetGame)
    {
        double x = 10.52;
        for (int k = 0; k < 7; k++)
        {
            tas[k].transform.position = new Vector3((float)x, 6, -1);
            if (resetGame)
            {
                tas[k].SetActive(true);
            }
            if (k!=6)
            {
                text[k].text = "0";
            }
            x++;
        }
    }
}
