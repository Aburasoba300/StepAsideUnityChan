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
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;

    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;

    private GameObject MainCamera;



    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");

        this.MainCamera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        //���̋������ƂɃA�C�e�����폜
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
