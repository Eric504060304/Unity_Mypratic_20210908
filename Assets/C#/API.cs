using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region �R�A�ݩ�
        //���o get
        //�y�k
        //���O�W��,�R�A�ݩ�
        float r = Random.value;
        print("���o�R�A�ݩʡA�H����:" + r);

        //�]�w
        //�y�k:
        //���O�W��.�R�A�ݩ� ���w ��;
        Cursor.visible = false;
        //Random.visable = 99.9f;//��Ū�ݩʤ���]�w
        #endregion


        #region �R�A��k
        //�I�s�A�ѼơB�Ǧ^
        //ñ��: �ѼơB�Ǧ^
        //�h��:���P�����B���P�ѼơB���@�˪���k��i�P�@���O
        //�y�k:
        //���O�W��.�R�A��k(�����ޭz)
        float range = Random.Range(10.5f, 20.9f);
        print("�H���d��10.5~20.9" + range);

        int rangeInt = Random.Range(1, 3);
        print("����H���d��1~3: " + rangeInt);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region �R�A�ݩ�
        //print("�g�L�h�[" + Time.timeSinceLevelLoad);
        #endregion

        #region �R�A��k
        float h = Input.GetAxis("Horizontal");
        print("������" + h);
        #endregion
    }
}
