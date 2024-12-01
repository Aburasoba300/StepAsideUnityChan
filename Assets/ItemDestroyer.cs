using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //coinprefab������
    public GameObject coinPrefab;
    //carprefab������
    public GameObject carPrefab;
    //coneprefab������
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
            //�R�[�����폜
            if (g[i].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(g[i]);
                Debug.Log("A");
            }

            //�R�C�����폜
            if (h[i].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(h[i]);
                Debug.Log("B");
            }

            //�Ԃ��폜
            if (f[i].transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(f[i]);
                Debug.Log("C");
            }
        }
    }
}
