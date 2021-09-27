using UnityEngine;        //引用Unity API(倉庫-資料與功能)
using UnityEngine.Video;  //引用 影片 API


//修飾詞 類別 類別名稱 : 繼承類別
//MonoBehaviour 基底類別，要掛在物件上衣定要繼承
//繼承後會享有該類別的成員
//在類別以及成員上方添加三條斜線會添加摘要
//常用成員:欄位Field、屬性(變數)Property、方法Method、事件Event
/// <summary>
/// /Eric 2021.0906
/// 第三人稱控制器
/// 移動、跳要
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
    #region 欄位 Field
    //儲存遊戲資料，例如:移動速度、跳躍高度等等...
    //常用四大類型:整數、浮點數、字串、布林值
    //欄位語法:修飾詞 資料類型 欄位名稱 (指定 預設值)可省略 結尾
    //修飾詞:
    //1. 公開 public  -允許其他類別存取 - 顯示在屬性面板 - 需要調整的資料設定圍攻哀
    //2. 私人 private -禁止其他類別存取 - 隱藏在屬性面板 - 預設值
    //spped欄位名稱 - 通常以小寫命名
    // *Unity 以屬性面板資料為主
    // *Unity 屬性面板中如果讓他Reset的時候，就可以還原到C#所設定的預設值先點選...>Reset
    //欄位屬性Attribute : 輔助欄位資料
    //**欄位屬性語法 : [屬性名稱(屬性值)]**
    //Header 標題
    //Tooltip 提示 :滑鼠停留在欄位名ˊ稱上會顯示彈出視窗
    //Range 範圍 : 可使用在數值類型資料上，例如 int, float
    #region Unity 資料類型
    [Header("移動速度"), Tooltip("用來調整角色移動速度"), Range(1, 500)]
    public float speed = 10.5f;

    //顏色 Color
    public Color color;
    public Color white = Color.white;                              //內建顏色
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0);                //自訂顏色RGB R G A(Apparent)
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);//RGBA    //自訂顏色RGBA
    // 座標 Vector 2-4
    public Vector2 v2;//沒有設置預設值就是0
    public Vector2 v2Right = Vector2.right;//紅色X軸右邊
    public Vector2 v2up = Vector2.up;//綠色Y軸上面
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //按鍵 列舉資料 enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //遊戲資料類型 : 不能指定預設值
    public AudioClip sound; //音效 mp3, ogg , wav
    public VideoClip video; //影片 mp4
    public Sprite sprite; // 圖片 png,jpeg 不支援 gif
    public Texture2D texture2D; //2D圖片 支援 png jpeg
    public Material material; //材質球

    private AudioSource aud;
    private Rigidbody rig;
    private Animator ani;

    public GameObject playerObject;
    #endregion
    #endregion

    #region 屬性 Property
    /**屬性練習
        //儲存資料，與欄位相同
        //差異在於，可以設定存取權限Get Set
        //屬性語法:修飾詞 資料類型 屬性名稱{取; 存;}

        public int readAndWrite { get; set; }
        //唯讀屬性:只能取得get
        public int read { get; }
        //唯讀屬性: 透過get設定預設值，關鍵字return為傳回值
        //public int write{set;}
        //value 指的是指定的值
        public int readValue
        {
            get
            {
                return 77;
            }
        }
        private int _hp;
        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        private void Start()
        {
            //欄位與屬性 取得 Get 、設定 Set
            print("欄位資料-移動速度: " + speed);
            print("屬性資料 -讀寫屬性" + runInEditMode);
            speed = 20.5f;
            readAndWrite = 90;
            print("修改後的資料");
            print("欄位資料 - 移動速度:" + speed);
            print("屬性資料 - 讀寫屬性:" + readAndWrite);
            print("唯讀屬性" + read);
            print("唯讀屬性，設有預設值" + readValue);

            //屬性存取練習
            print("HP:" + hp);
            hp = 100;
            print("HP:" + hp);
        }**/
    #endregion

    #region 方法 Method
    //定義與實作較複雜程式的區塊，功能
    //方法語法:修飾詞 傳回資料類型 方法名稱(參數1,...參數n){程式區塊}
    //常用傳回類型:無傳回void -此方法沒有傳回資料
    //格式化:Ctrl + K D
    //自訂方法:
    //名稱顏色為淡黃色 - 沒有被呼叫
    //名稱顏色為深黃色 - 有被呼叫
    private void Test()
    {
        print("我是自訂方法~");
    }
    private int ReturnJump()
    {
        return 999;
    }

    /**不使用參數
    private void Skill100()
    {
        print("傷害值" + 100);
        print("技能特效");
    }
    private void Skill150()
    {
        print("傷害值" + 150);
        print("技能特效");
    }**/
    //參數語法: 資料類型 參數名稱 指定 預設值
    //有預設值的參數可以不輸入引述，選填式參數
    //*選填式參數只能放在()又變
    private void Skill(int damage, string effect = "灰塵特效", string sound = "嘎嘎嘎")
    {
        print("參數版本 - 傷害值:" + damage);
        print("參數版本 - 技能特效" + effect);
        print("參數版本 - 音效" + sound);
    }

    /*錯誤示範:選填式參數沒有在()右邊
     * private void Skill(int damage, string effect ="灰塵特效",int damage(這個不是選填式參數))
    {
        print("參數版本-傷害值:" + damage);
        print("參數版本- 技能特效"+effect);
    }*/
    //BMI = 體重/身高*身高
    /// <summary>
    /// 計算BMI的方法
    /// </summary>
    /// <param name="weight">體重，單位為公尺</param>
    /// <param name="height">身高，單位為公尺</param>
    /// <param name="name">名稱，測量者的名稱</param>
    /// <returns>BMI 的結果</returns>
    private float BMI(float weight, float height, string name = "測試")
    {
        print(name + "的BMI");
        return weight / (height * height);
    }
    /// <summary>
    /// 移動速度
    /// </summary>
    /// <param name="speed"></param>
    private void Movement(float speed)
    {
        print("移動速度" + speed);
    }
    private float MoveInput()
    {
        return 0;
    }
    private bool checkground()
    {
        return false;
    }
    private void JumpUp()
    {

    }
    private void UpdateAnimation()
    {

    }
    #endregion

    #region 事件 Event
    //特定時間時間點會執行的方法，程式的入口Start 等於Console Main
    //開始事件:遊戲開始時執行一次 -處理初始化，取得資料等等
    private void Start()
    {
        #region 輸出 方法
        /**輸出方法
         private void Start()
        {
            
            print("哈囉，沃德~");

            Debug.Log("一般訊息");
            Debug.LogWarning("警告訊息");
            Debug.LogError("錯誤訊息");
            #endregion
        }
        
        //更新事件:一秒約執行60次，60FPS - Frame Per Second
        //處理持續性運動，移動物件，監聽玩家輸入按鍵
        private void Update()
        {
        }
        //呼叫自訂方法語法:方法名稱();
        Test();
        Test();
        //呼叫有傳回值的方法
        //1.區域變數指定傳回值 - 區域變數僅能在此結構(大括號)內存取
        int j = ReturnJump();
        print("跳躍值: " + j);
        //2.將傳回方法當成值使用
        print("跳躍值，當值使用: " + (ReturnJump() + 1));**/
        #endregion

        //參數語法:資料類型 參數名稱

        /**不使用參數
        Skill100();
        Skill150();**/
        //數值以參數的方式呼叫
        Skill(500);

        //要取得腳本的遊戲物件可以使用關鍵字gameObject
        //需求:傷害值500，技能特效用預設值，音效換成咻咻咻
        //有多個選填式參數十可使用指名參數語法: 參數名稱: 值
        Skill(500, sound: "咻咻咻");
        print(BMI(75, 1.7f, "Eric"));
        //取得元件的方式
        //1. 物件欄位名稱.取得原件(類型(元件類型))當作 元件類型;
        aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //2. 此腳本遊戲物件.取得原件<泛型>();
        rig = gameObject.GetComponent<Rigidbody>();
        //3. 取得元件<泛型>()
        ani = GetComponent<Animator>();

    }


    #endregion

}