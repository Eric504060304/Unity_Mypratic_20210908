using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 認識API:非靜態 Non Static
/// </summary>
public class APINonStatic : MonoBehaviour
{
    public Transform tra1;//預設值都是空值
    public Camera cam;
    public Light lig;
    public SpriteRenderer pic1;
    public Transform pic2;
    public Rigidbody2D pic3;
    void Start()
    {
        
        #region 非靜態屬性
        //非靜態屬性都是public，通常也只有properties而已
        //與靜態差異
        //1.需要實體物件
        //2.取得實體物件-定義欄位並將要存取的物件存入欄位
        //3.遊戲物件、元件必須存在場井內
        //取得 Get
        //語法: 欄位名稱.非靜態變數
        print("攝影機的座標" + tra1.position);
        print("攝影機的深度" + cam.depth);

        //設定 Set
        //語法: 欄位名稱.非靜態屬性 指定 值
        tra1.position = new Vector3(99, 99, 99);
        cam.depth = 7;
        #endregion

        #region 非靜態方法
        //呼叫
        //語法:
        //欄位名稱.非靜態方法名稱(對應引數);
        lig.Reset();
        #endregion
        #region 練習
        print("攝影機深度" + cam.depth);
        print("方形圖片的顏色"+pic1.color);

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
