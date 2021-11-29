using UnityEngine;
using UnityEngine.Events;

namespace EricDialogue
{
    /// <summary>
    /// NPC �t��
    /// �����ؼЬO�_�i�J��ܽd��
    /// �åB�}�ҹ�ܨt��
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region ���P�ݩ�

        [Header("��ܸ��")]
        public DataDialogue dataDialogue;
        [Header("������T"), Range(0, 10)]
        public float checkPlayerRadius = 3f;
        [Range(0, 10)]
        public float speedLook = 3;
        public GameObject goTip;
        private Transform target;
        private bool startDialgueKey { get => Input.GetKeyDown(KeyCode.E); }
        #endregion
        [Header("��ܨt��")]
        public DialogueSystem dialogueSystem;
        [Header("�������Ȩƥ�")]
        public UnityEvent onFinish;
        /// <summary>
        /// �ثe���ȼƶq
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
        /// �ˬd���a�O�_�i�J
        /// </summary>
        /// <returns>���a�i�J �Ǧ^true �_�h false</returns>
        private bool CheckPlayer()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, checkPlayerRadius, 1 << 6);
            if (hits.Length > 0) target = hits[0].transform;
            return hits.Length > 0;
        }
        /// <summary>
        /// ���۪��a
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
        /// ���a�i�J�d�� �åB ���U���w�ץ� �й�ܮذ��� �}�l���
        /// ���a�h�X�d��~ ������
        /// ���ȫe�B���Ȥ��B���ȫ�
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

