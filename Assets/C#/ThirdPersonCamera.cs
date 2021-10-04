using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ���")]
    public Transform target;
    [Header("�l�ܳt��"), Range(0, 100)]
    public float speedTrack = 1.5f;
    [Header("���४�k�t��"), Range(0, 100)]
    public float speedTurnHorizontal = 5;
    [Header("����W�U�t��"), Range(0, 100)]
    public float speedTurnVertical = 5;
    #endregion

    #region �ݩ�
    private float inputMouseX { get => Input.GetAxis("Mouse X"); }

    private float inputMouseY { get => Input.GetAxis("Mouse Y"); }
    #endregion

    #region �ƥ�
    //�bUpdate �����A�i�H�ΨӳB�z��v�����l�ܦ欰
    private void LateUpdate()
    {
        TrackTarget();
    }
    #endregion

    #region ��k

    private void TrackTarget()
    {
        Vector3 posTarget = target.position;// ���o �ؼ� �y��
        Vector3 posCamera = transform.position;//���o ��v�� �y��

        posCamera = Vector3.Lerp(posTarget, posCamera, speedTrack*Time.deltaTime);//��v���y�� = ����

        transform.position = posCamera;//������y�� = ��v���y��
    }
    private void TurnCamera()
    {
        transform.Rotate(
            inputMouseY*Time.deltaTime*speedTurnVertical,
            inputMouseX*Time.deltaTime*speedTurnHorizontal,0);
    }
    #endregion

}
