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
        [Range(0, 7)]
        public float rangeAttack = 5;
        [Range(7, 20)]
        public float rangeTrack = 15;
        [Header("�����H�����")]
        public Vector2 v2RandomWait = new Vector2(1F, 5F);
        [Header("��������ǰe�ˮ`�ɶ�"), Range(0, 5)]
        public float delaySendDamage = 0.5f;
        [Header("���۪��a�t��"), Range(0, 50)]
        public float speedLookAt = 10;
        [Header("�����ϰ�첾�P�ؤo")]
        public Vector3 v3AttackOffset;
        public Vector3 v3AttackSize = Vector3.one;
        [Header("�����H�����")]
        public Vector2 v2RandomWalk = new Vector2(3, 7);
        [Header("��������ɶ�"), Range(0, 5)]
        public float timeAttack = 2.5f;
        #endregion

        #region ���G�p�H
        [SerializeField]
        private StateEnemy state; //�ǦC�e���G��ܨp�H���
        private Transform traPlayer;
        private string namePlayer = "�L��";
        private Animator ani;
        private NavMeshAgent nma;
        private string paramterIdleWalk = "�����}��";
        private string parameterAttack = "����Ĳ�o";
        private Vector3 v3RandomWalkFinal;
        private bool isIdle;
        private bool isTrack;
        private string parameterAttck = "����Ĳ�o";
        private bool isAttack;
        #endregion


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

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = speed;
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
        /// ���ݡG�H����ƫ�i�J�������A
        /// </summary>
        private void Idle()
        {
            if(!targetIsDead && playerInTrackRange) state = StateEnemy.Track;
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
            if (!targetIsDead && playerInTrackRange) state = StateEnemy.Track;
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

        private bool targetIsDead;
        private void Attack()
        {
            nma.isStopped = true;                                   //������ ����
            ani.SetBool(paramterIdleWalk, false);                   //�����
            nma.SetDestination(traPlayer.position);
            LookAtPlayer();

            if (nma.remainingDistance > rangeAttack) state = StateEnemy.Track;
            if (isAttack) return;                                   //�p�G ���b������ �N���X (�קK���Ƨ���)
            isAttack = true;                                        //���b������
            ani.SetTrigger(parameterAttck);

            StartCoroutine(DelaySendDamageToTarget());              //�Ұʩ���ǰe�ˮ`���ؼШ�{
        }
        /// <summary>
        /// ����ǰe�ˮ`���ؼ�
        /// </summary>
        /// <returns></returns>
        private IEnumerator DelaySendDamageToTarget()
        {
            yield return new WaitForSeconds(delaySendDamage);              //����
            //���z �����I��(�����I�A�@�b�ؤo�A���סA�ϼh)
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                v3AttackSize / 2, Quaternion.identity, 1 << 6);
            //�p�G �I������ƶq�j�� �s�A�ǰe�����O���I�����󪺨��˨t��
            if (hits.Length > 0) targetIsDead = hits[0].GetComponent<HurtSystem>().Hurt(attack);


            float waitToNextAttack = timeAttack - delaySendDamage;          //�p��Ѿl�N�o�ɶ�

            yield return new WaitForSeconds(waitToNextAttack);              //����

            isAttack = false;                                               //��_  �������A
        }
        private void TargetDead()
        {
            state = StateEnemy.Walk;
        }
        #endregion

        private void LookAtPlayer()
        {

            Quaternion angle = Quaternion.LookRotation(traPlayer.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            ani.SetBool(paramterIdleWalk, transform.rotation != angle);
        }
    }

}
