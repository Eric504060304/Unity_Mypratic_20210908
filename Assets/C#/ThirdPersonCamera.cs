using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    #region 欄位
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speedTrack = 1.5f;
    [Header("旋轉左右速度"), Range(0, 100)]
    public float speedTurnHorizontal = 5;
    [Header("旋轉上下速度"), Range(0, 100)]
    public float speedTurnVertical = 5;
    public Vector2 limitAngleX = new Vector2(-0.2f, 0.2f);
    public Vector2 limitAngleFromTarget = new Vector2(-0.2f, 0);
    private Vector3 _posForward;
    private float lengthForward = 1;

    
    
    #endregion

    #region 屬性
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

    #region 事件
    //在Update 後執行，可以用來處理攝影機的追蹤行為
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
        //前方座標=此物件座標+此物件前方*長度
        _posForward = transform.position + transform.forward * lengthForward;
        //前方座標.y=目標.座標.y(讓前方座標的高度與目標相同)
        _posForward.y = target.position.y;
        Gizmos.DrawSphere(posForward, 0.15f);
    }

    #region 方法

    private void TrackTarget()
    {
        Vector3 posTarget = target.position;// 取得 目標 座標
        Vector3 posCamera = transform.position;//取得 攝影機 座標

        posCamera = Vector3.Lerp(posTarget, posCamera, speedTrack * Time.deltaTime);//攝影機座標 = 插值

        transform.position = posCamera;//此物件座標 = 攝影機座標
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
        Quaternion angle = transform.rotation;                                         //取得四位元角度
        angle.x = Mathf.Clamp(angle.x, limitAngleX.x, limitAngleX.y);                  //夾住角度X軸
        angle.z = Mathf.Clamp(angle.z, limitAngleFromTarget.x, limitAngleFromTarget.y);//夾住角度Z軸
        transform.rotation = angle;                                                    //更新物件角度
    }
    private void FreezeAngleZ()
    {
        Vector3 angle = transform.eulerAngles;//取得三維角度
        angle.z = 0;                          //凍結Z軸為0
        transform.eulerAngles = angle;        //更新物件角度
    }
    #endregion

}
