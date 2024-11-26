using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;

    //Unity�������ړ�������R���|�[�l���g������(�ǉ�)
    private Rigidbody myRigidbody;

    //�O�����̑��x(�ǉ�)
    private float velocityZ = 16f;
    //�������̑��x
    private float velocityX = 10f;
    //������̑��x
    private float velocityY = 10f;
    //���E�̈ړ��ł���͈�
    private float movableRange = 3.4f;

    //����������������W��
    private float coefficient = 0.99f;
    //�Q�[���I���̔���
    private bool isEnd = false;

    //�Q�[���I�����ɕ\������e�L�X�g
    private GameObject stateText;

    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;

    //���_
    private int score = 0;

    //���{�^�������̔���i�ǉ��j
    private bool isLButtonDown = false;
    //�E�{�^�������̔���i�ǉ��j
    private bool isRButtonDown = false;
    //�W�����v�{�^�������̔���i�ǉ��j
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed",1);

        //Rigidbody�R���|�[�l���g���擾(�ǉ�)
        this.myRigidbody = GetComponent<Rigidbody>();

        //�V�[������stateText�I�u�W�F�N�g���擾
        this.stateText = GameObject.Find("GameResultText");

        //�V�[������ScoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {

        //�Q�[���I���Ȃ�Unity�����̓�������������
        if(this.isEnd)
        {

            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }


        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;

        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������B���̕��œ�����͈͊O�ɏo������if���̓��e�𖞂����Ȃ��Ȃ�A���͂��Ă����͈͓̔��Ɏ��܂�悤�ɂȂ��Ă���B
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x) 
        {
            //�������ւ̑��x����
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange) 
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        
        }

        //�W�����v���Ă��Ȃ��Ƃ��ɃX�y�[�X�������ꂽ��W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f) 
        {
            this.myAnimator.SetBool("Jump",true);
            //������̑��x����
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x����
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇ��Jump��false���Z�b�g����i�ǉ��j
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
           this.myAnimator.SetBool("Jump", false);
        }

        //Unity�����ɑ��x��^����(�ǉ�)
        this.myRigidbody.velocity = new Vector3(inputVelocityX,inputVelocityY,this.velocityZ);
    }

    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏���
    private void OnTriggerEnter(Collider other)
    {
        
        //��Q���ɏՓ˂����ꍇ
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {

            this.isEnd = true;

            //stateText��GAME OVER��\���i�ǉ��j
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //�S�[���n�_�ɓ��B�����ꍇ
        if (other.gameObject.tag == "GoalTag") 
        {
            this.isEnd = true;

            //stateText��CLEAR��\���i�ǉ��j
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

        }

        //�R�C���ɏՓ˂����ꍇ
        if(other.gameObject.tag == "CoinTag")
        {
            //�X�R�A�����Z
            score += 10;
            //ScoreText�Ɋl�������_����\��
            this.scoreText.GetComponent<Text>().text = "Score" + score + "pt";

            //�p�[�e�B�N���̍Đ�
            GetComponent<ParticleSystem>().Play();

            //�ڐG�����R�C���̃I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }
    //�W�����v�{�^�����������ꍇ�̏����i�ǉ��j
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }

    //�W�����v�{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //���{�^���������������ꍇ�̏����i�ǉ��j
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //���{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //�E�{�^���������������ꍇ�̏����i�ǉ��j
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //�E�{�^���𗣂����ꍇ�̏����i�ǉ��j
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}