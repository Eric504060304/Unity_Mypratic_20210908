using System.Collections;
using System.Collections.Generic;
using UnityEngine;// 引用 Unity API (倉庫 - 資料與功能)
using UnityEngine.Video;


// 修飾詞 類別 類別名稱 : 繼承類別
//MonBehaviour Unity 基底類別，要掛在物件上衣定要繼承
//繼承後會享有該類別的成員
//在類別以及成員上方添加三條斜線會添加摘要
//常用成員:欄位 Field、屬性Property(變數)、方法Method、事件Event
/// <summary>
/// Eric 2021.09.29
/// 第三人稱控制器
/// 移動、跳躍
/// </summary>
public class ThirdPersonController1 : MonoBehaviour
{
    #region 欄位Field
    //儲存遊戲資料，例如:移動速度、跳躍高度等等...
    //常用四大類型: 整數、浮點數、字串、布林值
    //欄位語法: 修飾詞(如public) 資料類型 欄位名稱 (指定 預設值) 結尾
    //修飾詞:
    // 1. 公開 public  - 允許所有類別存取 - 顯示在屬性面板版 - 需要調整的資料設定為公開
    // 2. 私人 private - 禁止所有類別存取 - 隱藏讚屬性面板 - 預設值
    // V Unity 以屬性面板資料為主
    // V 恢復城市預設值請按...>Reset
    // 欄位屬性 : 輔助欄位資料
    // 欄位屬性語法 : [屬性名稱(屬性值)]
    // Headeer 標題
    // Tooltip 提示: 滑鼠停留在欄位名稱上會顯示彈出視窗
    // Range 範圍: 可使用在數值類型資料上，例如: int, float
    [Header("移動速度"), Tooltip("用來調整角色移動素度"), Range(1, 500)]
    public float speed = 5.5f;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 100;
    [Header("檢查地面資料")]
    [Tooltip("用來檢查角色是否在地面上")]
    public bool isGrounded;
    public Vector3 v3CheckGroundOffset;
    public float checkGroundRadius = 0.2f;

    //按鍵 列舉資料 enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode keyjump = KeyCode.Space;
    [Header("音效檔案")]
    public AudioClip soundJump;
    public AudioClip soundGround;
    [Header("動畫參數")]
    public string animatorParWalk = "走路開關";
    public string animatorParIsGrounded = "是否在地板上";
    public string animatorParAttack = "攻擊開關";
    public string animatorParJump = "跳躍觸發";
    public string animatorParHurt = "受傷觸發";
    public string animatorParDead = "死亡開關";

    //元件
    private AudioSource aud;//聲音元件
    private Rigidbody rig;//鋼體
    private Animator ani;//動畫元件
    [Header("面向速度"),Range(0,50)]
    public float speedLookAt = 2;

    /** 作業:怪物欄位
    [Header("怪物移動速度"),Range(0,10)]
    public float monstermovespeed = 3.5f;
    [Header("怪物攻擊力"),Range(0,500)]
    public int monsterattack = 100;
    [Header("怪物血量"),Range(0,5000)]
    public int monsterhp = 350;
    [Header("怪物追蹤範圍"),Range(0,50)]
    public float monstertrackrange = 30f;
    public Vector3 monstermove;
    [Header("掉落道具")]
    public GameObject dropGameObject;//這裡我寫錯~直接使用GameObject資料類型，其預設值就是否。
    [Header("掉落道具機率"),Range(0,1)]
    public float dropGameObjectrate = 1f;

    [Header("掉落道具音效")]
    public AudioClip dropGameObjectsound;
    [Header("受傷音效")]
    public AudioClip hurtsound;
    [Header("攻擊音效")]
    public AudioClip attacksound;

    private AudioSource aud1;
    private Rigidbody2D rig1;
    private Animator ani1;
    */




    #region Unity 資料類型
    /** 練習 Unity 資料類型
    //顏色 Color
    public Color color;
    public Color white = Color.white;                        //內建顏色
    public Color yellow = Color.yellow;                      //內建顏色
    public Color color1 = new Color(0.5f, 0.5f, 0);          //自訂顏色RGB
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);    //自訂顏色RGBA

    //座標 Vector2 -4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1,2,3);
    public Vector3 v3Forward = Vector3.forward;
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //按鍵 列舉資料 enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //遊戲資料類型:不能指定預設值
    public AudioClip sound;  //音效 mp3, ogg ,wav
    public VideoClip video;  //影片mp4,
    public Sprite sprite;    //圖片 png, jpeg - 不支援gif
    public Texture2D texture2D;//2D 圖片 png, jpeg
    public Material material; //材質球

    //元件 Component : 屬性面板上可折疊的
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera cam;

    //綠色蚯蚓
    // 1. 建議不要使用此名稱
    // 2. 使用過時的 API*/




    #endregion

    #endregion

    #region 屬性 Property
    /** 屬性練習
    //屬性不會顯示在面板上
    // 儲存資料，與欄位相同
    // 差異在於: 可以設定存取權限 Get Set
    // 屬性語法:
    // 修飾詞 資料類型 屬性名稱 {取;存} public int  XXX {get;set;}
    public int ReadandWrite { get; set; }
    //唯讀屬性:只能取得 get
    public int read { get; }
    //唯讀屬性: 透過get 設定預設值，關鍵字 return 為傳回值
    public int readValue
    {
        get
        {
            return 77;
        }
    }
    //唯寫屬性是禁止的
    //public int write { set; }
    //value 指的是指定的值
    private int _hp;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;//指得是等號右邊的值
        }
    }
    */

    //C#6.0存取子 可以使用 Lambda =>運算子
    //語法: get = > {程式區塊}-單行可省略大括號
    private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
    #endregion

    #region 方法 Method
    // 摺疊 ctrl + m o 
    // 展開 ctrl + m l
    //定義與實作較複雜程式的區塊，功能
    //方法的語法:修飾詞 傳回資料類型 方法名稱 (參數1,......參數n) {程式區塊}
    //常用傳回類型:無傳回 void - 此方法沒有傳回資料
    //自訂方法: 名稱顏色為淡黃色 - 沒有被呼叫
    //自訂方法: 名稱顏色為亮黃色 - 有被呼叫

    private int ReturnJump()
    {
        return 999;
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="speedMove">移動速度</param>
    private void Move(float speedMove)
    {
        //請取消Animator 屬性 Apply Root Motion : 勾選時使用動畫位移資訊
        //鋼體.加速度 = 三維向量 - 加速度用來控制鋼體三個軸向的運動速度
        //前方 = 輸入值*移動速度
        //使用前後左右軸項運動並且保持原本的地心引力
        rig.velocity = Vector3.forward * MoveInput("Vertical") * speedMove +
                       Vector3.right * MoveInput("Horizontal") * speedMove +
                       Vector3.up * rig.velocity.y;

    }
    /// <summary>
    /// 移動按鍵輸入
    /// </summary>
    /// <param name="axisName">要取得的軸向名稱</param>
    /// <returns>移動按鍵值</returns>
    private float MoveInput(string axisName)
    {
        return Input.GetAxis(axisName);
    }
    /// <summary>
    /// 檢查地板
    /// </summary>
    /// <returns>是否碰到地板</returns>
    private bool CheckGround()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position +
            transform.right * v3CheckGroundOffset.x +
            transform.up * v3CheckGroundOffset.y +
            transform.forward * v3CheckGroundOffset.z, checkGroundRadius, 1 << 3);

        isGrounded = hits.Length > 0;
        return hits.Length > 0;
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //並且&& 運算子
        //如果 在地面上 並且 按下空白鍵 就 跳躍
        if (CheckGround() && keyJump)
        {
            rig.AddForce(transform.up * jump);
            //aud.PlayOneShot(soundJump, Random.Range(0.7f, 1.5f));
        }
    }
    /// <summary>
    /// 更新動畫
    /// </summary>
    private void UpdateAnimation()
    {
        //當玩家往前或後移動時 true
        //沒有按時 將設定為false
        //垂直值 不等於 0 就代表 true
        //垂直值 等於 0 就代表 false
        //Input
        //if(選擇物件)
        //!=、== 比較運算子 (選擇條件)



        ani.SetBool(animatorParWalk, MoveInput("Vertical") != 0 || MoveInput("Horizontal") != 0);
        //設定是否在地板上 動畫參數
        ani.SetBool(animatorParIsGrounded, isGrounded);
        //如果 按下 跳躍鍵 就 設定跳躍觸發參數
        //判斷式 只有一行敘述(只有一個分號)可以省略大括號
        if (keyJump) ani.SetTrigger(animatorParJump);

    }
    #region 練習方法 Method
    /*private void Test()
    {
        print("我是自訂方法");
    }
    */
    #endregion

    /** 作業 NPC 方法

    /// <summary>
    /// 對話功能
    /// </summary>
    /// <param name="dialogue">NPC 要說的對話內容</param>
    private void Npctalk(string dialogue)//需要好好練習
    {

    }
    /// <summary>
    /// 開以商店
    /// </summary>
    /// <returns></returns>
    public bool Openshop()
    {
        return true;
    }
    /// <summary>
    /// 購買道具
    /// </summary>
    /// <param name="obejectprice">道具價格預設100</param>
    /// <returns></returns>
    public int Buyobject(int obejectprice = 100)
    {
        return 0;
    }
    /// <summary>
    /// 取得任務
    /// </summary>
    /// <param name="missionnumber">任務編號</param>
    public void Getmission(int missionnumber)
    {

    }
    /// <summary>
    /// 更新任務
    /// </summary>
    /// <param name="obtainmissionobject">任務道具數量</param>
    /// <returns></returns>
    private int MissionUpdate(int obtainmissionobject = 1)
    {
        return 0;
    }
    /// <summary>
    /// 完成任務
    /// </summary>
    /// <param name="missionnumber">任務編號</param>
    /// <returns></returns>
    private bool MissionComplete(int missionnumber)
    {
        return false;
    }
    */
    
    ///<summary>
    ///面相前方: 面向攝影機前方位置
    /// </summary>
    private void LookAtForward()
    {
        //垂直軸向 取絕對值 後大於0.1 就處理 面向
        if (MoveInput("Vertical") > 0.1f)
        {
            //取得前方角度 = 四元.面相角度(前方座標-本身座標)
            Quaternion angle = Quaternion.LookRotation(thirdPersonCamera.posForward - transform.position);
            //此物件的角度 = 四元.插值
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
        }
    }
    #endregion

    #region 事件 Event
    // 特定時間點會執行的方法，也就是城市的入口 Start 等於 Console Main,Main = Start
    //開始是在 : 遊戲開始時執行一次 - 處理初始化，取得資料等等
    public GameObject playerObject;
    private ThirdPersonCamera thirdPersonCamera;
    private void Start()
    {
        #region 輸出方法
        /** 輸出 方法
        print("哈囉，沃德~");

        Debug.Log("一般訊息");
        Debug.LogWarning("警告訊息");
        Debug.LogError("錯誤訊息");
        */
        #endregion

        /** 屬性練習
        //欄位與屬性 取得 Get、設定 Set
        print("欄位資料 - 移動速度: " + speed);
        print("屬性資料 - 讀寫屬性: " + ReadandWrite);
        speed = 20.5f;
        ReadandWrite = 90;
        print("修改後的資料");
        print("欄位資料 - 移動速度: " + speed);
        print("屬性資料 - 讀寫屬性: " + ReadandWrite);
        // 唯讀屬性
        // read = 7; //唯讀屬性不能設定 set
        print("唯讀屬性: " + read);
        print("唯讀屬性，有預設值: " + readValue);

        //屬性存取練習
        print("HP" + hp);
        hp = 100;//右邊的值
        print("HP" + hp);
        */
        //取得元件的方式
        //取得腳本的遊戲物件可以使用關鍵字 gameObject
        //1. 物件欄位名稱.取得元件(類型(元件類型)) 當作 元件類型
        aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        rig = gameObject.GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        //1.泛型 可以當作Rigidbody,AudioSource,Animator
        //2.此腳本遊戲物件.取得元件<泛型>();
        thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>();
        #region 練習呼叫方法
        rig = playerObject.GetComponent<Rigidbody>();
        //3.取得元件<泛型>();
        //類別可以使用繼承類別(父類別)的成員，公開或保護 欄位、屬性與方法
        //此為繼承playerObject
        ani = GetComponent<Animator>();


        //呼叫自訂方法語法: 方法名稱();
        //Test();
        #endregion
    }
    //更新事件 : 一秒約執行60次 - 60FPS - Frame Per Second
    //處理持續性運動，移動物件，監聽玩家輸入按鍵
    private void Update()
    {
        CheckGround();
        Jump();
        UpdateAnimation();
        LookAtForward();
    }
    //固定更新事件:0.02秒執行一次
    //處理物理行為，例如:Rigidbody API
    private void FixedUpdate()
    {
        Move(speed);
    }
    //繪製圖示事件
    //在Unity Editor 內繪製圖是輔助開發，發布後自動會隱藏
    private void OnDrawGizmos()
    {
        //1. 指定顏色
        //2. 繪製圖形
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

        //transform 與此腳本在同階層的Transform 元件
        Gizmos.DrawSphere(
            transform.position +
            transform.right * v3CheckGroundOffset.x +
            transform.up * v3CheckGroundOffset.y +
            transform.forward * v3CheckGroundOffset.z, checkGroundRadius);
    }
    #endregion


}
