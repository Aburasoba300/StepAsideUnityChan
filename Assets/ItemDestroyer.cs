using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //coinprefabを入れる
    public GameObject coinPrefab;
    //carprefabを入れる
    public GameObject carPrefab;
    //coneprefabを入れる
    public GameObject conePrefab;
    
    private GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {

        this.MainCamera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("TrafficConeTag");
        GameObject[] h = GameObject.FindGameObjectsWithTag("CoinTag");
        GameObject[] f = GameObject.FindGameObjectsWithTag("CarTag");

        for (int i = 0; i < g.Length; i++)
        {
            //コーンを削除
            if (g[i].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(g[i]);
                Debug.Log("A");
            }
        }

        for (int j = 0; j < h.Length; j++)
        {
            //コインを削除
            if (h[j].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(h[j]);
                Debug.Log("B");
            }
        }

        for (int k = 0; k < f.Length; k++)
            //車を削除
            if (f[k].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(f[k]);
                Debug.Log("C");
            }
        }
    }
