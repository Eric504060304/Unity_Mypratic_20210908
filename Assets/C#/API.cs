using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region �R�A�ݩ�
        //���o
        //�y�k
        //���O�W��,�R�A�ݩ�
        float r = Random.value;
        print("���o�R�A�ݩʡA�H����:" + r);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region �R�A�ݩ�
        print("�g�L�h�[" + Time.timeSinceLevelLoad);
        #endregion
    }
}
