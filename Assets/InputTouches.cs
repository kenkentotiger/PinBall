using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouches : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Use this for initialization
    private void Start()
    {
        //HingeJoint�R���|�[�l���g
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 0)
        {
            SetAngle(this.defaultAngle);
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            // ���Wx���X�N���[���̂Q���̂P�ȏ�̏ꍇ
            if (Input.touches[i].position.x <= Screen.width / 2)
            {
                //�����L�[�������������t���b�p�[�𓮂���
                if (Input.touches[i].phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else if (Input.touches[i].position.x >= Screen.width / 2)
            {
                //�E���L�[�����������E�t���b�p�[�𓮂���
                if (Input.touches[i].phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //�����L�[�����ꂽ�Ƃ��t���b�p�[�����ɖ߂�
            }
            if (Input.touches[i].phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
                //�E���L�[�𗣂��ꂽ�Ƃ��E�t���b�p�[�����ɖ߂�
            if (Input.touches[i].phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }
    }
    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
