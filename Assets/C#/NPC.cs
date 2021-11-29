using UnityEngine;
using UnityEngine.Events;

namespace EricDialogue
{
    /// <summary>
    /// NPC 系統
    /// 偵測目標是否進入對話範圍
    /// 並且開啟對話系統
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region 欄位與屬性

        [Header("對話資料")]
        public DataDialogue dataDialogue;
        [Header("相關資訊"), Range(0, 10)]
        public float checkPlayerRadius = 3f;
        [Range(0, 10)]
        public float speedLook = 3;
        public GameObject goTip;
        private Transform target;
        private bool startDialgueKey { get => Input.GetKeyDown(KeyCode.E); }
        #endregion
        [Header("對話系統")]
        public DialogueSystem dialogueSystem;
        [Header("完成任務事件")]
        public UnityEvent onFinish;
        /// <summary>
        /// 目前任務數量
        /// </summary>
        private int countCurrent;
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, checkPlayerRadius);

        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            dataDialogue.stateNPCMission = State.BeforeMission;
        }

        private void Update()
        {
            CheckPlayer();
            LookAtPlayer();
            StartDialogue();
        }

        /// <summary>
        /// 檢查玩家是否進入
        /// </summary>
        /// <returns>玩家進入 傳回true 否則 false</returns>
        private bool CheckPlayer()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, checkPlayerRadius, 1 << 6);
            if (hits.Length > 0) target = hits[0].transform;
            return hits.Length > 0;
        }
        /// <summary>
        /// 面相玩家
        /// </summary>
        private void LookAtPlayer()
        {
            if (CheckPlayer())
            {
                Quaternion angle = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime);
            }

        }

        /// <summary>
        /// 玩家進入範圍內 並且 按下指定案件 請對話框執行 開始對話
        /// 玩家退出範圍外 停止對話
        /// 任務前、任務中、任務後
        /// </summary>
        private void StartDialogue()
        {
            if (CheckPlayer() && startDialgueKey)
            {
                dialogueSystem.Dialogue(dataDialogue);
                if (dataDialogue.stateNPCMission == State.BeforeMission)
                    dataDialogue.stateNPCMission = State.Missionning;
            }
            else if (!CheckPlayer()) dialogueSystem.StopDialogue();
        }

        public void UpdateMissionCount()
        {
            countCurrent++;
            if (countCurrent == dataDialogue.countNeed)
            {
                dataDialogue.stateNPCMission = State.AfterMission;
                onFinish.Invoke();
            }
                
            
        }
    }
}

