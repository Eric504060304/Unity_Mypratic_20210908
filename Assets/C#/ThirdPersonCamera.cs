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
    #endregion

    #region 屬性
    private float inputMouseX { get => Input.GetAxis("Mouse X"); }

    private float inputMouseY { get => Input.GetAxis("Mouse Y"); }
    #endregion

    #region 事件
    //在Update 後執行，可以用來處理攝影機的追蹤行為
    private void LateUpdate()
    {
        TrackTarget();
    }
    #endregion

    #region 方法

    private void TrackTarget()
    {
        Vector3 posTarget = target.position;// 取得 目標 座標
        Vector3 posCamera = transform.position;//取得 攝影機 座標

        posCamera = Vector3.Lerp(posTarget, posCamera, speedTrack*Time.deltaTime);//攝影機座標 = 插值

        transform.position = posCamera;//此物件座標 = 攝影機座標
    }
    private void TurnCamera()
    {
        transform.Rotate(
            inputMouseY*Time.deltaTime*speedTurnVertical,
            inputMouseX*Time.deltaTime*speedTurnHorizontal,0);
    }
    #endregion

}
