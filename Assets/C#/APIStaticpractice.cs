using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticpractice : MonoBehaviour
{
    /// <summary>
    /// 靜態屬性與方法API課堂練習
    /// </summary>
    // Start is called before the first frame update
    [Header("所有攝影機數量")]
    private int count;
    [Header("圓周率")]
    public float radius;

    void Start()
    {
        #region 所有攝影機數量
        int count = Camera.allCamerasCount;
        print("所有攝影機數量" + count);
        #endregion
        #region 2D的重力大小
        Vector2 gravity2d = Physics2D.gravity;
        #endregion
        #region 圓周率
        float mathpi = Mathf.PI;
        #endregion
        #region 2D的重力大小設定為Y-20
        gravity2d.Set(0, -20);
        #endregion
        #region 時間大小設定為0.5(慢動作)
        Time.captureDeltaTime = 0.5f;
        #endregion
        #region 到9.999去小數點
        float newnum = Mathf.FloorToInt(9.999f);
        #endregion

        Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22));

        Application.OpenURL("https://unity.com/");
    }

    // Update is called once per frame
    void Update()
    {
        #region 是否輸入任意鍵
        if (Input.anyKey)
        {
            Debug.Log("是否輸入任意鍵");
        }
        #endregion
        #region 遊戲經過多少時間
        print("經過多久" + Time.timeSinceLevelLoad);
        #endregion
    }
}
