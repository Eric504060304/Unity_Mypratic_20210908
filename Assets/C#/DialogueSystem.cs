using System.Collections;
using UnityEngine.UI;
using UnityEngine;
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

        public void Dialogue(DataDialogue data)
        {
            StartCoroutine(SwitchDialogueGroup());                  //啟動協同程序
            StartCoroutine(ShowDialogueContent(data));
        }
        private IEnumerator SwitchDialogueGroup()
        {
            for(int i = 0; i < 10; i++)                             //迴圈指定執行次庫
            {
                groupDialogue.alpha += 0.1f;                        //群組元件 透明度 遞增
                yield return new WaitForSeconds(0.01f);             //等待時間
            }
        }
        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textName.text = "";
            textContent.text = "";

            for(int i = 0; i < data.beforeMission1[0].Length; i++)
            {
                textContent.text += data.beforeMission1[i];
                yield return new WaitForSeconds(dialogueInterval);
            }
        }
    }
}

