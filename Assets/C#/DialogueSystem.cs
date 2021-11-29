using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
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
        [Header("��ܮץ�")]
        public KeyCode dialogueKey = KeyCode.Space;
        [Header("���r�ƥ�")]
        public UnityEvent onType;
        /// <summary>
        /// �}�l���
        /// </summary>
        /// <param name="data"></param>
        public void Dialogue(DataDialogue data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());                  //�Ұʨ�P�{��
            StartCoroutine(ShowDialogueContent(data));
        }

        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }
        /// <summary>
        /// ������ܮظs��
        /// </summary>
        /// <returns></returns>
        private IEnumerator SwitchDialogueGroup(bool fadeIn =true)
        {
            //�T���B��l
            //�y�k�G���L��? true ���G�Gfalse ���G�F
            //�z�L���L�ȨM�w�n�W�[�o�ȡAtrue�W�[0.1�Afalse�W�[-0.1;
            float increase = fadeIn ? 0.1f : -0.1f;
            for(int i = 0; i < 10; i++)                             //�j����w���榸�w
            {
                groupDialogue.alpha += 0.1f;                        //�s�դ��� �z���� ���W
                yield return new WaitForSeconds(0.01f);             //���ݮɶ�
            }
        }
        /// <summary>
        /// ��ܹ�ܤ��e
        /// </summary>
        /// <param name="data">��ܸ��</param>
        /// <returns></returns>
        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textName.text = "";                     //�M�� ��ܪ�
            textName.text = data.nameDialogue;      //��s ��ܪ�

            string[] dialogueContents = { };    //�x�s��ܤ��e

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
            //�M�M�C�@�q���
            for (int j = 0; j < dialogueContents.Length; j++)
            {
                
                textContent.text = "";  //�M�� ��ܤ��e
                goTriangle.SetActive(true); //���� ���ܹϥ�
                //�M�M��ܨC�@�Ӧr
                for (int i = 0; i < dialogueContents[j].Length; i++)
                {
                    onType.Invoke();
                    textContent.text += data.beforeMission1[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }
                goTriangle.SetActive(true);

                //���򵥫� ��J ��ܫ��� null ���ݤ@�Ӽv�檺�ɶ�
                while (!Input.GetKeyDown(dialogueKey)) yield return null;
            }
            

            StartCoroutine(SwitchDialogueGroup(false));     //�H�X
        }

    }
}

