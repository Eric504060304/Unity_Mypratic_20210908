using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Eric.Enemy
{
    /// <summary>
    /// �ĤH�欰
    /// �ĤH���A�G���ݡB�����B�l�ܡB�����B���ˡB���`
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region ���G���}
        [Header("���ʳt��"), Range(0, 20)]
        public float speed = 2.5f;
        [Header("���ʳt��"), Range(0, 200)]
        public float attack = 35;
        [Header("�d��G�l�ܻP����")]
        public float rangeAttack = 5;
        public float rangeTrack = 15;
        [Header("�����H�����")]
        public Vector2 v2RandomWait = new Vector2(1F, 5F);
        #endregion

        #region ���G�p�H
        [SerializeField]
        private StateEnemy state; //�ǦC�e���G��ܨp�H���

        private Animator ani;
        private NavMeshAgent nma;
        private string paramterIdleWalk = "�����}��";
        #endregion

        [Header("�����ϰ�첾�P�ؤo")]
        public Vector3 v3AttackOffset;
        public Vector3 v3AttackSize = Vector3.one;


        #region ø�s�ϧ�
        private void OnDrawGizmos()
        {
            #region �����B�l�ܡB�H���樫
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeAttack);

            Gizmos.color = new Color(0.2f, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeTrack);
            if (state == StateEnemy.Walk)
            {
                Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
                Gizmos.DrawSphere(v3RandomWalk, 0.3f);
            }
            #endregion

            #region �����I���P�w�ϰ�
            Gizmos.color = new Color(0.8f, 0.2f, 0.7f, 0.3f);       //v3AttackSize�e��έn3���V�q�ҥH�|��xyz�b�����D�A�M�Ӧ��ƥ��ŧiv3AttackSize�ӥN��3�ӯB�I�ơA�]�����ݭn�A�B�~�g�A�e��δT�I��
            //ø�s��ΡG�ݭn��ۨ������ɽШϥ�matrix ���w�y�Ш��׻P�ؤo
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                transform.rotation, transform.localScale);

            Gizmos.DrawCube(Vector3.zero, v3AttackSize);
            #endregion
        }
        #endregion

        #region �ƥ�
        private Transform traPlayer;
        private string namePlayer = "�L��";



        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            traPlayer = GameObject.Find(namePlayer).transform;

            nma.SetDestination(transform.position);             //������ �@�}�l�N���Ұ�
        }
        /// <summary>
        /// �H���樫�y��
        /// </summary>
        private Vector3 v3RandomWalk
        {
            get => Random.insideUnitSphere * rangeTrack + transform.position;
        }
        private void Update()
        {

            StateManager();
        }


        #endregion

        #region ��k�G�p�H


        /// <summary>
        /// ���A�޲z
        /// </summary>
        private void StateManager()
        {
            //�ֱ���A��Jswitch����UTab�A�A������J�n�o���A�A����UEnter�N�|�q�C�|��Ƥ��פJcase��
            switch (state)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Walk:
                    Walk();
                    break;
                case StateEnemy.Track:
                    Track();
                    break;
                case StateEnemy.Attack:
                    Attack();
                    break;
                case StateEnemy.Hurt:
                    break;
                case StateEnemy.Dead:
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// �O�_���ݪ��A
        /// </summary>
        private bool isIdle;


        /// <summary>
        /// ���ݡG�H����ƫ�i�J�������A
        /// </summary>
        private void Idle()
        {
            if (playerInTrackRange) state = StateEnemy.Track;
            #region �i�J����
            if (isIdle) return;
            isIdle = true;
            StartCoroutine(IdleEffect());
            #endregion

            ani.SetBool(paramterIdleWalk, false);
            StartCoroutine(IdleEffect());
        }
        /// <summary>
        /// ���ݮĪG
        /// </summary>
        /// <returns></returns>
        private IEnumerator IdleEffect()
        {
            float randomwait = Random.Range(v2RandomWait.x, v2RandomWait.y);
            yield return new WaitForSeconds(randomwait);


            state = StateEnemy.Walk;            //�i�J�������A
            #region �X�h����
            isIdle = false;
            #endregion
        }

        private Vector3 v3RandomWalkFinal;

        [Header("�����H�����")]
        public Vector2 v2RandomWalk = new Vector2(3, 7);
        /// <summary>
        /// �O�_�������A
        /// </summary>
        private bool isWalk;

        /// <summary>
        /// �����G�H����ƫ�i�J���ݪ��A
        /// </summary>
        private void Walk()
        {
            #region �������ϰ�
            nma.SetDestination(v3RandomWalkFinal);                                              //�N�z��.�]�w�ت��a(�y��)
            ani.SetBool(paramterIdleWalk, nma.remainingDistance > 0.1f);                        //�����ʵe - ���ت��a�Z���j��0.1�ɨ���
            #endregion
            #region �i�J����
            if (isWalk) return;
            isWalk = true;
            #endregion

            NavMeshHit hit;                                                                     //��������I����T - �x�s����I����T
            NavMesh.SamplePosition(v3RandomWalk, out hit, rangeTrack, NavMesh.AllAreas);        //��������.���o�y��(�H���y�СA�I����T�A�b�|�A�ϰ�) - ���椺�i�樫���y��
            v3RandomWalkFinal = hit.position;                                                   //�̲׮y�� = �I����T �� �y��


            StartCoroutine(WalkEffect());

        }

        /// <summary>
        /// �����ĪG
        /// </summary>
        /// <returns></returns>
        private IEnumerator WalkEffect()
        {
            float randomWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);
            yield return new WaitForSeconds(randomWalk);

            state = StateEnemy.Idle;

            #region ���}����
            isWalk = false;
            #endregion
        }

        /// <summary>
        /// ���a�O�_�b�l�ܽd�򤺡Atrue�O�Afalse�_
        /// </summary>
        private bool playerInTrackRange { get => Physics.OverlapSphere(transform.position, rangeTrack, 1 << 6).Length > 0; }

        private bool isTrack;

        [Header("�����ɶ�"),Range(0,5)]
        public float timeAttack = 2.5f;

        private string parameterAttck = "����Ĳ�o";
        private bool isAttack;
        /// <summary>
        /// �l�ܪ��a
        /// </summary>
        private void Track()
        {
            #region �i�J����
            if (!isTrack)
            {
                StopAllCoroutines();
            }
            isTrack = true;
            ani.SetTrigger(parameterAttck);
            #endregion

            nma.isStopped = false;                                  //������ �Ұ�
            nma.SetDestination(traPlayer.position);
            ani.SetBool(paramterIdleWalk, true);

            //�Z���p�󵥩���� �N�i �������A
            if (nma.remainingDistance <= rangeAttack) state = StateEnemy.Attack;
        }



        /// <summary>
        /// �������a
        /// </summary>
        private void Attack()
        {
            #region �i�J����
            if (!isTrack)
            {
                StopAllCoroutines();
            }
            isTrack = true;
            #endregion
            nma.isStopped = true;                                   //������ ����
            ani.SetBool(paramterIdleWalk, false);                   //�����
            nma.SetDestination(traPlayer.position);
            if (nma.remainingDistance > rangeAttack) state = StateEnemy.Track;

            //���z �����I��(�����I�A�@�b�ؤo�A���סA�ϼh)
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                v3AttackSize / 2, Quaternion.identity, 1 << 6);

            if (hits.Length > 0) print("�����쪺����G" + hits[0].name);


        }
        #endregion
    }

}
