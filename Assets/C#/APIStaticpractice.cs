using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticpractice : MonoBehaviour
{
    /// <summary>
    /// �R�A�ݩʻP��kAPI�Ұ�m��
    /// </summary>
    // Start is called before the first frame update
    [Header("�Ҧ���v���ƶq")]
    private int count;
    [Header("��P�v")]
    public float radius;

    void Start()
    {
        #region �Ҧ���v���ƶq
        int count = Camera.allCamerasCount;
        print("�Ҧ���v���ƶq" + count);
        #endregion
        #region 2D�����O�j�p
        Vector2 gravity2d = Physics2D.gravity;
        #endregion
        #region ��P�v
        float mathpi = Mathf.PI;
        #endregion
        #region 2D�����O�j�p�]�w��Y-20
        gravity2d.Set(0, -20);
        #endregion
        #region �ɶ��j�p�]�w��0.5(�C�ʧ@)
        Time.captureDeltaTime = 0.5f;
        #endregion
        #region ��9.999�h�p���I
        float newnum = Mathf.FloorToInt(9.999f);
        #endregion

        Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22));

        Application.OpenURL("https://unity.com/");
    }

    // Update is called once per frame
    void Update()
    {
        #region �O�_��J���N��
        if (Input.anyKey)
        {
            Debug.Log("�O�_��J���N��");
        }
        #endregion
        #region �C���g�L�h�֮ɶ�
        print("�g�L�h�[" + Time.timeSinceLevelLoad);
        #endregion
    }
}
