using UnityEngine;


namespace Eric.Practice
{
    /// <summary>
    /// 認識迴圈
    /// while、do while、for、foreach
    /// </summary>
    public class LearnLoop: MonoBehaviour
    {
        private void Start()
        {
            //迴圈Loop
            //重複執行程式內容
            //需求:輸出數字1-5
            print(1);
            print(2);
            print(3);
            print(4);
            print(5);

            //while迴圈
            //語法: if (布林直){程式內容}   -布林直為true執行一次
            //語法: while(布林直){程式內容} -布林直為true持續執行
            int a = 1;

            while (a<6)
            {
                print("迴圈while" + a);
                a++;
            }
            for(int  i = 0; i < 6; i++)
            {
                print("迴圈 for" + i);
            }
        }
    }
}
