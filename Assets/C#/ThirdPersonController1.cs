using System.Collections;
using System.Collections.Generic;
using UnityEngine;// �ޥ� Unity API (�ܮw - ��ƻP�\��)
using UnityEngine.Video;


// �׹��� ���O ���O�W�� : �~�����O
//MonBehaviour Unity �����O�A�n���b����W��w�n�~��
//�~�ӫ�|�ɦ������O������
//�b���O�H�Φ����W��K�[�T���׽u�|�K�[�K�n
//�`�Φ���:��� Field�B�ݩ�Property(�ܼ�)�B��kMethod�B�ƥ�Event
/// <summary>
/// Eric 2021.09.29
/// �ĤT�H�ٱ��
/// ���ʡB���D
/// </summary>
public class ThirdPersonController1 : MonoBehaviour
{
    #region ���Field
    //�x�s�C����ơA�Ҧp:���ʳt�סB���D���׵���...
    //�`�Υ|�j����: ��ơB�B�I�ơB�r��B���L��
    //���y�k: �׹���(�ppublic) ������� ���W�� (���w �w�]��) ����
    //�׹���:
    // 1. ���} public  - ���\�Ҧ����O�s�� - ��ܦb�ݩʭ��O�� - �ݭn�վ㪺��Ƴ]�w�����}
    // 2. �p�H private - �T��Ҧ����O�s�� - �����g�ݩʭ��O - �w�]��
    // V Unity �H�ݩʭ��O��Ƭ��D
    // V ��_�����w�]�ȽЫ�...>Reset
    // ����ݩ� : ���U�����
    // ����ݩʻy�k : [�ݩʦW��(�ݩʭ�)]
    // Headeer ���D
    // Tooltip ����: �ƹ����d�b���W�٤W�|��ܼu�X����
    // Range �d��: �i�ϥΦb�ƭ�������ƤW�A�Ҧp: int, float
    [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʯ���"), Range(1, 500)]
    public float speed = 5.5f;
    [Header("���D����"), Range(0, 1000)]
    public int jump = 100;
    [Header("�ˬd�a�����")]
    [Tooltip("�Ψ��ˬd����O�_�b�a���W")]
    public bool isGrounded;
    public Vector3 v3CheckGroundOffset;
    public float checkGroundRadius = 0.2f;

    //���� �C�|��� enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode keyjump = KeyCode.Space;
    [Header("�����ɮ�")]
    public AudioClip soundJump;
    public AudioClip soundGround;
    [Header("�ʵe�Ѽ�")]
    public string animatorParWalk = "�����}��";
    public string animatorParIsGrounded = "�O�_�b�a�O�W";
    public string animatorParAttack = "�����}��";
    public string animatorParJump = "���DĲ�o";
    public string animatorParHurt = "����Ĳ�o";
    public string animatorParDead = "���`�}��";

    //����
    private AudioSource aud;//�n������
    private Rigidbody rig;//����
    private Animator ani;//�ʵe����

    /** �@�~:�Ǫ����
    [Header("�Ǫ����ʳt��"),Range(0,10)]
    public float monstermovespeed = 3.5f;
    [Header("�Ǫ������O"),Range(0,500)]
    public int monsterattack = 100;
    [Header("�Ǫ���q"),Range(0,5000)]
    public int monsterhp = 350;
    [Header("�Ǫ��l�ܽd��"),Range(0,50)]
    public float monstertrackrange = 30f;
    public Vector3 monstermove;
    [Header("�����D��")]
    public GameObject dropGameObject;//�o�̧ڼg��~�����ϥ�GameObject��������A��w�]�ȴN�O�_�C
    [Header("�����D����v"),Range(0,1)]
    public float dropGameObjectrate = 1f;

    [Header("�����D�㭵��")]
    public AudioClip dropGameObjectsound;
    [Header("���˭���")]
    public AudioClip hurtsound;
    [Header("��������")]
    public AudioClip attacksound;

    private AudioSource aud1;
    private Rigidbody2D rig1;
    private Animator ani1;
    */




    #region Unity �������
    /** �m�� Unity �������
    //�C�� Color
    public Color color;
    public Color white = Color.white;                        //�����C��
    public Color yellow = Color.yellow;                      //�����C��
    public Color color1 = new Color(0.5f, 0.5f, 0);          //�ۭq�C��RGB
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);    //�ۭq�C��RGBA

    //�y�� Vector2 -4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1,2,3);
    public Vector3 v3Forward = Vector3.forward;
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //���� �C�|��� enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //�C���������:������w�w�]��
    public AudioClip sound;  //���� mp3, ogg ,wav
    public VideoClip video;  //�v��mp4,
    public Sprite sprite;    //�Ϥ� png, jpeg - ���䴩gif
    public Texture2D texture2D;//2D �Ϥ� png, jpeg
    public Material material; //����y

    //���� Component : �ݩʭ��O�W�i���|��
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera cam;

    //���L�C
    // 1. ��ĳ���n�ϥΦ��W��
    // 2. �ϥιL�ɪ� API*/




    #endregion

    #endregion

    #region �ݩ� Property
    /** �ݩʽm��
    //�ݩʤ��|��ܦb���O�W
    // �x�s��ơA�P���ۦP
    // �t���b��: �i�H�]�w�s���v�� Get Set
    // �ݩʻy�k:
    // �׹��� ������� �ݩʦW�� {��;�s} public int  XXX {get;set;}
    public int ReadandWrite { get; set; }
    //��Ū�ݩ�:�u����o get
    public int read { get; }
    //��Ū�ݩ�: �z�Lget �]�w�w�]�ȡA����r return ���Ǧ^��
    public int readValue
    {
        get
        {
            return 77;
        }
    }
    //�߼g�ݩʬO�T�
    //public int write { set; }
    //value �����O���w����
    private int _hp;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;//���o�O�����k�䪺��
        }
    }
    */

    //C#6.0�s���l �i�H�ϥ� Lambda =>�B��l
    //�y�k: get = > {�{���϶�}-���i�ٲ��j�A��
    private bool keyJump { get => Input.GetKeyDown(KeyCode.Space); }
    #endregion

    #region ��k Method
    // �P�| ctrl + m o 
    // �i�} ctrl + m l
    //�w�q�P��@�������{�����϶��A�\��
    //��k���y�k:�׹��� �Ǧ^������� ��k�W�� (�Ѽ�1,......�Ѽ�n) {�{���϶�}
    //�`�ζǦ^����:�L�Ǧ^ void - ����k�S���Ǧ^���
    //�ۭq��k: �W���C�⬰�H���� - �S���Q�I�s
    //�ۭq��k: �W���C�⬰�G���� - ���Q�I�s

    private int ReturnJump()
    {
        return 999;
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="speedMove">���ʳt��</param>
    private void Move(float speedMove)
    {
        //�Ш���Animator �ݩ� Apply Root Motion : �Ŀ�ɨϥΰʵe�첾��T
        //����.�[�t�� = �T���V�q - �[�t�ץΨӱ������T�Ӷb�V���B�ʳt��
        //�e�� = ��J��*���ʳt��
        //�ϥΫe�ᥪ�k�b���B�ʨåB�O���쥻���a�ߤޤO
        rig.velocity = Vector3.forward * MoveInput("Vertical") * speedMove +
                       Vector3.right * MoveInput("Horizontal") * speedMove +
                       Vector3.up * rig.velocity.y;

    }
    /// <summary>
    /// ���ʫ����J
    /// </summary>
    /// <param name="axisName">�n���o���b�V�W��</param>
    /// <returns>���ʫ����</returns>
    private float MoveInput(string axisName)
    {
        return Input.GetAxis(axisName);
    }
    /// <summary>
    /// �ˬd�a�O
    /// </summary>
    /// <returns>�O�_�I��a�O</returns>
    private bool CheckGround()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position +
            transform.right * v3CheckGroundOffset.x +
            transform.up * v3CheckGroundOffset.y +
            transform.forward * v3CheckGroundOffset.z, checkGroundRadius, 1 << 3);

        isGrounded = hits.Length > 0;
        return hits.Length > 0;
    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        //�åB&& �B��l
        //�p�G �b�a���W �åB ���U�ť��� �N ���D
        if (CheckGround() && keyJump)
        {
            rig.AddForce(transform.up * jump);
            //aud.PlayOneShot(soundJump, Random.Range(0.7f, 1.5f));
        }
    }
    /// <summary>
    /// ��s�ʵe
    /// </summary>
    private void UpdateAnimation()
    {
        //���a���e�ΫᲾ�ʮ� true
        //�S������ �N�]�w��false
        //������ ������ 0 �N�N�� true
        //������ ���� 0 �N�N�� false
        //Input
        //if(��ܪ���)
        //!=�B== ����B��l (��ܱ���)



        ani.SetBool(animatorParWalk, MoveInput("Vertical") != 0 || MoveInput("Horizontal") != 0);
        //�]�w�O�_�b�a�O�W �ʵe�Ѽ�
        ani.SetBool(animatorParIsGrounded, isGrounded);
        //�p�G ���U ���D�� �N �]�w���DĲ�o�Ѽ�
        //�P�_�� �u���@��ԭz(�u���@�Ӥ���)�i�H�ٲ��j�A��
        if (keyJump) ani.SetTrigger(animatorParJump);

    }
    #region �m�ߤ�k Method
    /*private void Test()
    {
        print("�ڬO�ۭq��k");
    }
    */
    #endregion

    /** �@�~ NPC ��k

    /// <summary>
    /// ��ܥ\��
    /// </summary>
    /// <param name="dialogue">NPC �n������ܤ��e</param>
    private void Npctalk(string dialogue)//�ݭn�n�n�m��
    {

    }
    /// <summary>
    /// �}�H�ө�
    /// </summary>
    /// <returns></returns>
    public bool Openshop()
    {
        return true;
    }
    /// <summary>
    /// �ʶR�D��
    /// </summary>
    /// <param name="obejectprice">�D�����w�]100</param>
    /// <returns></returns>
    public int Buyobject(int obejectprice = 100)
    {
        return 0;
    }
    /// <summary>
    /// ���o����
    /// </summary>
    /// <param name="missionnumber">���Ƚs��</param>
    public void Getmission(int missionnumber)
    {

    }
    /// <summary>
    /// ��s����
    /// </summary>
    /// <param name="obtainmissionobject">���ȹD��ƶq</param>
    /// <returns></returns>
    private int MissionUpdate(int obtainmissionobject = 1)
    {
        return 0;
    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="missionnumber">���Ƚs��</param>
    /// <returns></returns>
    private bool MissionComplete(int missionnumber)
    {
        return false;
    }
    */




    #endregion
    public GameObject playerObject;
    #region �ƥ� Event
    // �S�w�ɶ��I�|���檺��k�A�]�N�O�������J�f Start ���� Console Main,Main = Start
    //�}�l�O�b : �C���}�l�ɰ���@�� - �B�z��l�ơA���o��Ƶ���
    private void Start()
    {
        #region ��X��k
        /** ��X ��k
        print("���o�A�U�w~");

        Debug.Log("�@��T��");
        Debug.LogWarning("ĵ�i�T��");
        Debug.LogError("���~�T��");
        */
        #endregion

        /** �ݩʽm��
        //���P�ݩ� ���o Get�B�]�w Set
        print("����� - ���ʳt��: " + speed);
        print("�ݩʸ�� - Ū�g�ݩ�: " + ReadandWrite);
        speed = 20.5f;
        ReadandWrite = 90;
        print("�ק�᪺���");
        print("����� - ���ʳt��: " + speed);
        print("�ݩʸ�� - Ū�g�ݩ�: " + ReadandWrite);
        // ��Ū�ݩ�
        // read = 7; //��Ū�ݩʤ���]�w set
        print("��Ū�ݩ�: " + read);
        print("��Ū�ݩʡA���w�]��: " + readValue);

        //�ݩʦs���m��
        print("HP" + hp);
        hp = 100;//�k�䪺��
        print("HP" + hp);
        */
        //���o���󪺤覡
        //���o�}�����C������i�H�ϥ�����r gameObject
        //1. �������W��.���o����(����(��������)) ��@ ��������
        aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //1.�x�� �i�H��@Rigidbody,AudioSource,Animator
        //2.���}���C������.���o����<�x��>();
        #region �m�ߩI�s��k
        rig = playerObject.GetComponent<Rigidbody>();
        //3.���o����<�x��>();
        //���O�i�H�ϥ��~�����O(�����O)�������A���}�ΫO�@ ���B�ݩʻP��k
        //�����~��playerObject
        ani = GetComponent<Animator>();


        //�I�s�ۭq��k�y�k: ��k�W��();
        //Test();
        #endregion
    }
    //��s�ƥ� : �@�������60�� - 60FPS - Frame Per Second
    //�B�z����ʹB�ʡA���ʪ���A��ť���a��J����
    private void Update()
    {
        CheckGround();
        Jump();
        UpdateAnimation();
    }
    //�T�w��s�ƥ�:0.02�����@��
    //�B�z���z�欰�A�Ҧp:Rigidbody API
    private void FixedUpdate()
    {
        Move(speed);
    }
    //ø�s�ϥܨƥ�
    //�bUnity Editor ��ø�s�ϬO���U�}�o�A�o����۰ʷ|����
    private void OnDrawGizmos()
    {
        //1. ���w�C��
        //2. ø�s�ϧ�
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

        //transform �P���}���b�P���h��Transform ����
        Gizmos.DrawSphere(
            transform.position +
            transform.right * v3CheckGroundOffset.x +
            transform.up * v3CheckGroundOffset.y +
            transform.forward * v3CheckGroundOffset.z, checkGroundRadius);
    }
    #endregion


}
