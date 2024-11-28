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
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    private GameObject MainCamera;



    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        this.MainCamera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        //一定の距離ごとにアイテムを削除
        for (int i = startPos; i < goalPos; i += 15)
        {
            if(conePrefab.transform.position.z < MainCamera.transform.position.z)
            {
                Destroy(conePrefab);
                Debug.Log("successA");
            }
            
            //if

            //if()
            
        }
    }
}
