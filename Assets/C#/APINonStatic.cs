using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �{��API:�D�R�A Non Static
/// </summary>
public class APINonStatic : MonoBehaviour
{
    public Transform tra1;//�w�]�ȳ��O�ŭ�
    public Camera cam;
    public Light lig;
    public SpriteRenderer pic1;
    public Transform pic2;
    public Rigidbody2D pic3;
    void Start()
    {
        
        #region �D�R�A�ݩ�
        //�D�R�A�ݩʳ��Opublic�A�q�`�]�u��properties�Ӥw
        //�P�R�A�t��
        //1.�ݭn���骫��
        //2.���o���骫��-�w�q���ñN�n�s��������s�J���
        //3.�C������B���󥲶��s�b������
        //���o Get
        //�y�k: ���W��.�D�R�A�ܼ�
        print("��v�����y��" + tra1.position);
        print("��v�����`��" + cam.depth);

        //�]�w Set
        //�y�k: ���W��.�D�R�A�ݩ� ���w ��
        tra1.position = new Vector3(99, 99, 99);
        cam.depth = 7;
        #endregion

        #region �D�R�A��k
        //�I�s
        //�y�k:
        //���W��.�D�R�A��k�W��(�����޼�);
        lig.Reset();
        #endregion
        #region �m��
        print("��v���`��" + cam.depth);
        print("��ιϤ����C��"+pic1.color);

        cam.backgroundColor = Random.ColorHSV();
        pic1.flipY = true;
        
        
        
        #endregion
    }


    void Update()
    {
        pic2.Rotate(0, 0, 3);

        pic3.AddForce(new Vector2(0,10));
    }
}
