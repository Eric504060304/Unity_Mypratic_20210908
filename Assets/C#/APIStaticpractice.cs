using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticpractice : MonoBehaviour
{
    /// <summary>
    /// �R�A�ݩʻP��kAPI�Ұ�m��
    /// </summary>
    // Start is called before the first frame update
    
    [Header("��P�v")]
    public float radius;

    void Start()
    {
        #region �Ҧ���v���ƶq
        print("�Ҧ���v���ƶq" + Camera.allCamerasCount);//1
        #endregion
        #region 2D�����O�j�p
        print("2D���O" + Physics2D.gravity);//0,-9.8
        #endregion
        #region ��P�v
        print("��P�v" + Mathf.PI);//3.1415926
        #endregion
        #region 2D�����O�j�p�]�w��Y-20
        Physics2D.gravity = new Vector2(0, -20);
        #endregion
        #region �ɶ��j�p�]�w��0.5(�C�ʧ@)
        Time.timeScale = 0.5f;
        #endregion
        #region ��9.999�h�p���I
        print("9.999�h�p���I���G" + Mathf.Round(9.999f));
        #endregion
        #region a b���I�������Z��
        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        print("a b���I�������Z��" + Vector3.Distance(a, b));
        #endregion
        #region �}��unity�x��
        Application.OpenURL("https://unity.com/");
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region �O�_��J���N��
        print("�O�_��J���N��" + Input.anyKey);
        #endregion
        #region �C���g�L�h�֮ɶ�
        print("�g�L�h�[" + Time.time);
        #endregion
        #region �O�_���U�ť���
        print("�O�_���U�ť���" + Input.GetKeyDown(KeyCode.Space));
        #endregion
    }
}
