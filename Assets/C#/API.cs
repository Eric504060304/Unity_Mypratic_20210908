using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 靜態屬性
        //取得
        //語法
        //類別名稱,靜態屬性
        float r = Random.value;
        print("取得靜態屬性，隨機值:" + r);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region 靜態屬性
        print("經過多久" + Time.timeSinceLevelLoad);
        #endregion
    }
}
