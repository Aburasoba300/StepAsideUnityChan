using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;

    private GameObject MainCamera;

    //Unity�����ƃJ�����̋���
    private float difference;


    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");

        this.MainCamera = GameObject.Find("Main Camera");

        //unity�����ƃJ�����̈ʒu�iz���W�j�̍������߂�
        this.difference = unitychan.transform.position.z - this.MainCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.MainCamera.transform.position = new Vector3
            (

            0, this.MainCamera.transform.position.y, this.unitychan.transform.position.z-difference

            );
    }
}
