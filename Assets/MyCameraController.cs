using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    private GameObject MainCamera;

    //Unityちゃんとカメラの距離
    private float difference;


    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        this.MainCamera = GameObject.Find("Main Camera");

        //unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.MainCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.MainCamera.transform.position = new Vector3
            (

            0, this.MainCamera.transform.position.y, this.unitychan.transform.position.z-difference

            );
    }
}
