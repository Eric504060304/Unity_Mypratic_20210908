using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticpractice : MonoBehaviour
{
    /// <summary>
    /// 靜態屬性與方法API課堂練習
    /// </summary>
    // Start is called before the first frame update
    
    [Header("圓周率")]
    public float radius;

    void Start()
    {
        #region 所有攝影機數量
        print("所有攝影機數量" + Camera.allCamerasCount);//1
        #endregion
        #region 2D的重力大小
        print("2D重力" + Physics2D.gravity);//0,-9.8
        #endregion
        #region 圓周率
        print("圓周率" + Mathf.PI);//3.1415926
        #endregion
        #region 2D的重力大小設定為Y-20
        Physics2D.gravity = new Vector2(0, -20);
        #endregion
        #region 時間大小設定為0.5(慢動作)
        Time.timeScale = 0.5f;
        #endregion
        #region 到9.999去小數點
        print("9.999去小數點結果" + Mathf.Round(9.999f));
        #endregion
        #region a b兩點之間的距離
        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        print("a b兩點之間的距離" + Vector3.Distance(a, b));
        #endregion
        #region 開啟unity官網
        Application.OpenURL("https://unity.com/");
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region 是否輸入任意鍵
        print("是否輸入任意鍵" + Input.anyKey);
        #endregion
        #region 遊戲經過多少時間
        print("經過多久" + Time.time);
        #endregion
        #region 是否按下空白鍵
        print("是否按下空白鍵" + Input.GetKeyDown(KeyCode.Space));
        #endregion
    }
}
