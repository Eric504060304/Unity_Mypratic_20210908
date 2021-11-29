using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
namespace EricDialogue
{
    /// <summary>
    /// 對話系統
    /// 顯示對話框、對話內容打字效果
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [Header("對話系統需要的介面物件")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("對話間格"), Range(0, 10)]
        public float dialogueInterval = 0.3f;
        [Header("對話案件")]
        public KeyCode dialogueKey = KeyCode.Space;
        [Header("打字事件")]
        public UnityEvent onType;
        /// <summary>
        /// 開始對話
        /// </summary>
        /// <param name="data"></param>
        public void Dialogue(DataDialogue data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());                  //啟動協同程序
            StartCoroutine(ShowDialogueContent(data));
        }

        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }
        /// <summary>
        /// 切換對話框群組
        /// </summary>
        /// <returns></returns>
        private IEnumerator SwitchDialogueGroup(bool fadeIn =true)
        {
            //三元運算子
            //語法：布林值? true 結果：false 結果；
            //透過布林值決定要增加得值，true增加0.1，false增加-0.1;
            float increase = fadeIn ? 0.1f : -0.1f;
            for(int i = 0; i < 10; i++)                             //迴圈指定執行次庫
            {
                groupDialogue.alpha += 0.1f;                        //群組元件 透明度 遞增
                yield return new WaitForSeconds(0.01f);             //等待時間
            }
        }
        /// <summary>
        /// 顯示對話內容
        /// </summary>
        /// <param name="data">對話資料</param>
        /// <returns></returns>
        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textName.text = "";                     //清除 對話者
            textName.text = data.nameDialogue;      //更新 對話者

            string[] dialogueContents = { };    //儲存對話內容

            switch (data.stateNPCMission)
            {
                case State.BeforeMission:
                    dialogueContents = data.beforeMission1;
                    break;
                case State.Missionning:
                    dialogueContents = data.Missioning;
                    break;
                case State.AfterMission:
                    dialogueContents = data.afterMission1;
                    break;
                default:
                    break;
            }
            //遍尋每一段對話
            for (int j = 0; j < dialogueContents.Length; j++)
            {
                
                textContent.text = "";  //清除 對話內容
                goTriangle.SetActive(true); //隱藏 提示圖示
                //遍尋對話每一個字
                for (int i = 0; i < dialogueContents[j].Length; i++)
                {
                    onType.Invoke();
                    textContent.text += data.beforeMission1[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }
                goTriangle.SetActive(true);

                //持續等待 輸入 對話按鍵 null 等待一個影格的時間
                while (!Input.GetKeyDown(dialogueKey)) yield return null;
            }
            

            StartCoroutine(SwitchDialogueGroup(false));     //淡出
        }

    }
}

