using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 靜態屬性
        //取得 get
        //語法
        //類別名稱,靜態屬性
        float r = Random.value;
        print("取得靜態屬性，隨機值:" + r);

        //設定
        //語法:
        //類別名稱.靜態屬性 指定 值;
        Cursor.visible = false;
        //Random.visable = 99.9f;//唯讀屬性不能設定
        #endregion


        #region 靜態方法
        //呼叫，參數、傳回
        //簽章: 參數、傳回
        //多載:不同類型、不同參數、不一樣的方法放進同一類別
        //語法:
        //類別名稱.靜態方法(對應引述)
        float range = Random.Range(10.5f, 20.9f);
        print("隨機範圍10.5~20.9" + range);

        int rangeInt = Random.Range(1, 3);
        print("整數隨機範圍1~3: " + rangeInt);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region 靜態屬性
        //print("經過多久" + Time.timeSinceLevelLoad);
        #endregion

        #region 靜態方法
        float h = Input.GetAxis("Horizontal");
        print("水平值" + h);
        #endregion
    }
}
