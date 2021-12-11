using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace Eric
{
    /// <summary>
    /// �C���޲z��
    /// �����B�z
    /// 1. ���ȧ���
    /// 2. ���a���`
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region ���
        [Header("�s�ժ���")]
        public CanvasGroup groupFinal;
        [Header("�����e�����D")]
        public Text textTitle;

        private string titleWin = "You Win!";
        private string titleLose = "You Failed";
        #endregion



        #region ��k�G���}
        /// <summary>
        /// �}�l�H�J�̫ᤶ��
        /// </summary>
        /// <param name="win">�O�_���</param>
        public void StatFadeFinalUI(bool win)
        {

        }
        #endregion

        #region ��k�G�p�H
        private IEnumerator FadeFinalUI(string title)
        {
            textTitle.text = title;
            for(int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.02f);
            }
        }
        #endregion
    }
}
