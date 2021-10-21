using System.Collections;
using UnityEngine.UI;
using UnityEngine;
namespace EricDialogue
{
    /// <summary>
    /// ��ܨt��
    /// ��ܹ�ܮءB��ܤ��e���r�ĪG
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [Header("��ܨt�λݭn����������")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("��ܶ���"), Range(0, 10)]
        public float dialogueInterval = 0.3f;

        public void Dialogue(DataDialogue data)
        {
            StartCoroutine(SwitchDialogueGroup());                  //�Ұʨ�P�{��
            StartCoroutine(ShowDialogueContent(data));
        }
        private IEnumerator SwitchDialogueGroup()
        {
            for(int i = 0; i < 10; i++)                             //�j����w���榸�w
            {
                groupDialogue.alpha += 0.1f;                        //�s�դ��� �z���� ���W
                yield return new WaitForSeconds(0.01f);             //���ݮɶ�
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
