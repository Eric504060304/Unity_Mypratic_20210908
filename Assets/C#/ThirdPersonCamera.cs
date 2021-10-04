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
    public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);
    public Vector2 limitAngleFromTarget = new Vector2(-0.2f, 0);
    private Vector3 _posForward;
    private float lengthForward = 1;

    
    
    #endregion

    #region �ݩ�
    private float inputMouseX { get => Input.GetAxis("Mouse X"); }

    private float inputMouseY { get => Input.GetAxis("Mouse Y"); }
    public Vector3 posForward
    {
        get
        {
            _posForward = transform.position + transform.forward * lengthForward;
            _posForward.y = target.position.y;
            return _posForward;
        }
    }
    #endregion

    #region �ƥ�
    //�bUpdate �����A�i�H�ΨӳB�z��v�����l�ܦ欰
    private void LateUpdate()
    {
        TrackTarget();
        LimitAngleX();
        FreezeAngleZ();
        TurnCamera();
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
        //�e��y��=������y��+������e��*����
        _posForward = transform.position + transform.forward * lengthForward;
        //�e��y��.y=�ؼ�.�y��.y(���e��y�Ъ����׻P�ؼЬۦP)
        _posForward.y = target.position.y;
        Gizmos.DrawSphere(posForward, 0.15f);
    }

    #region ��k

    private void TrackTarget()
    {
        Vector3 posTarget = target.position;// ���o �ؼ� �y��
        Vector3 posCamera = transform.position;//���o ��v�� �y��

        posCamera = Vector3.Lerp(posTarget, posCamera, speedTrack * Time.deltaTime);//��v���y�� = ����

        transform.position = posCamera;//������y�� = ��v���y��
    }
    private void TurnCamera()
    {
        transform.Rotate(
            inputMouseY * Time.deltaTime * speedTurnVertical,
            inputMouseX * Time.deltaTime * speedTurnHorizontal, 0);
        //print(transform.rotation);
    }
    private void LimitAngleX()
    {
        Quaternion angle = transform.rotation;                                         //���o�|�줸����
        angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y);                  //������X�b
        angle.z = Mathf.Clamp(angle.z, limitAngleFromTarget.x, limitAngleFromTarget.y);//������Z�b
        transform.rotation = angle;                                                    //��s���󨤫�
    }
    private void FreezeAngleZ()
    {
        Vector3 angle = transform.eulerAngles;//���o�T������
        angle.z = 0;                          //�ᵲZ�b��0
        transform.eulerAngles = angle;        //��s���󨤫�
    }
    #endregion

}
