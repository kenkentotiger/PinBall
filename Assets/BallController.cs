using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ő�l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o�[��\������e�L�X�g
    private GameObject gameoverText;

    //UI�ł���B_Text�̃e�L�X�g����C_text�ƒ�`
    public Text C_text;

    //�X�R�A�̏����l0
    public int score = 0;

    //Use this for initialization
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        // UI�ł���B_Text��T���A���̃e�L�X�g���ł���C_text�R���|�[�l���g���擾����
        this.C_text = GameObject.Find("B_Text").GetComponent<Text>();

        // UI�ł���B_Text��C�e�L�X�g���ɂ��āA�X�R�A��int�^��string�^�ɕϊ����ĕ\��
        C_text.text = score.ToString() + " �_"; 

    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //�Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            //�X�R�A��10�ǉ�
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            //�X�R�A��20�ǉ�
            score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            //�X�R�A��30�ǉ�
            score += 30;
        }
        // UI�ł���B_Text��C�e�L�X�g���ɂ��āA�X�R�A��int�^��string�^�ɕϊ����ĕ\��
        C_text.text = score.ToString() + " �_";
    }
}