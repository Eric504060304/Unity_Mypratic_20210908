using UnityEngine;        //�ޥ�Unity API(�ܮw-��ƻP�\��)
using UnityEngine.Video;  //�ޥ� �v�� API


//�׹��� ���O ���O�W�� : �~�����O
//MonoBehaviour �����O�A�n���b����W��w�n�~��
//�~�ӫ�|�ɦ������O������
//�b���O�H�Φ����W��K�[�T���׽u�|�K�[�K�n
//�`�Φ���:���Field�B�ݩ�(�ܼ�)Property�B��kMethod�B�ƥ�Event
/// <summary>
/// /Eric 2021.0906
/// �ĤT�H�ٱ��
/// ���ʡB���n
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
    #region ��� Field
    //�x�s�C����ơA�Ҧp:���ʳt�סB���D���׵���...
    //�`�Υ|�j����:��ơB�B�I�ơB�r��B���L��
    //���y�k:�׹��� ������� ���W�� (���w �w�]��)�i�ٲ� ����
    //�׹���:
    //1. ���} public  -���\��L���O�s�� - ��ܦb�ݩʭ��O - �ݭn�վ㪺��Ƴ]�w���s
    //2. �p�H private -�T���L���O�s�� - ���æb�ݩʭ��O - �w�]��
    //spped���W�� - �q�`�H�p�g�R�W
    // *Unity �H�ݩʭ��O��Ƭ��D
    // *Unity �ݩʭ��O���p�G���LReset���ɭԡA�N�i�H�٭��C#�ҳ]�w���w�]�ȥ��I��...>Reset
    //����ݩ�Attribute : ���U�����
    //**����ݩʻy�k : [�ݩʦW��(�ݩʭ�)]**
    //Header ���D
    //Tooltip ���� :�ƹ����d�b���W���٤W�|��ܼu�X����
    //Range �d�� : �i�ϥΦb�ƭ�������ƤW�A�Ҧp int, float
    #region Unity �������
    [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(1, 500)]
    public float speed = 10.5f;

    //�C�� Color
    public Color color;
    public Color white = Color.white;                              //�����C��
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0);                //�ۭq�C��RGB R G A(Apparent)
    public Color color2 = new Color(0, 0.5f, 0.5f, 0.5f);//RGBA    //�ۭq�C��RGBA
    // �y�� Vector 2-4
    public Vector2 v2;//�S���]�m�w�]�ȴN�O0
    public Vector2 v2Right = Vector2.right;//����X�b�k��
    public Vector2 v2up = Vector2.up;//���Y�b�W��
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    //���� �C�|��� enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    //�C��������� : ������w�w�]��
    public AudioClip sound; //���� mp3, ogg , wav
    public VideoClip video; //�v�� mp4
    public Sprite sprite; // �Ϥ� png,jpeg ���䴩 gif
    public Texture2D texture2D; //2D�Ϥ� �䴩 png jpeg
    public Material material; //����y

    private AudioSource aud;
    private Rigidbody rig;
    private Animator ani;

    public GameObject playerObject;
    #endregion
    #endregion

    #region �ݩ� Property
    /**�ݩʽm��
        //�x�s��ơA�P���ۦP
        //�t���b��A�i�H�]�w�s���v��Get Set
        //�ݩʻy�k:�׹��� ������� �ݩʦW��{��; �s;}

        public int readAndWrite { get; set; }
        //��Ū�ݩ�:�u����oget
        public int read { get; }
        //��Ū�ݩ�: �z�Lget�]�w�w�]�ȡA����rreturn���Ǧ^��
        //public int write{set;}
        //value �����O���w����
        public int readValue
        {
            get
            {
                return 77;
            }
        }
        private int _hp;
        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        private void Start()
        {
            //���P�ݩ� ���o Get �B�]�w Set
            print("�����-���ʳt��: " + speed);
            print("�ݩʸ�� -Ū�g�ݩ�" + runInEditMode);
            speed = 20.5f;
            readAndWrite = 90;
            print("�ק�᪺���");
            print("����� - ���ʳt��:" + speed);
            print("�ݩʸ�� - Ū�g�ݩ�:" + readAndWrite);
            print("��Ū�ݩ�" + read);
            print("��Ū�ݩʡA�]���w�]��" + readValue);

            //�ݩʦs���m��
            print("HP:" + hp);
            hp = 100;
            print("HP:" + hp);
        }**/
    #endregion

    #region ��k Method
    //�w�q�P��@�������{�����϶��A�\��
    //��k�y�k:�׹��� �Ǧ^������� ��k�W��(�Ѽ�1,...�Ѽ�n){�{���϶�}
    //�`�ζǦ^����:�L�Ǧ^void -����k�S���Ǧ^���
    //�榡��:Ctrl + K D
    //�ۭq��k:
    //�W���C�⬰�H���� - �S���Q�I�s
    //�W���C�⬰�`���� - ���Q�I�s
    private void Test()
    {
        print("�ڬO�ۭq��k~");
    }
    private int ReturnJump()
    {
        return 999;
    }

    /**���ϥΰѼ�
    private void Skill100()
    {
        print("�ˮ`��" + 100);
        print("�ޯ�S��");
    }
    private void Skill150()
    {
        print("�ˮ`��" + 150);
        print("�ޯ�S��");
    }**/
    //�Ѽƻy�k: ������� �ѼƦW�� ���w �w�]��
    //���w�]�Ȫ��Ѽƥi�H����J�ޭz�A��񦡰Ѽ�
    //*��񦡰Ѽƥu���b()�S��
    private void Skill(int damage, string effect = "�ǹЯS��", string sound = "�ǹǹ�")
    {
        print("�Ѽƪ��� - �ˮ`��:" + damage);
        print("�Ѽƪ��� - �ޯ�S��" + effect);
        print("�Ѽƪ��� - ����" + sound);
    }

    /*���~�ܽd:��񦡰ѼƨS���b()�k��
     * private void Skill(int damage, string effect ="�ǹЯS��",int damage(�o�Ӥ��O��񦡰Ѽ�))
    {
        print("�Ѽƪ���-�ˮ`��:" + damage);
        print("�Ѽƪ���- �ޯ�S��"+effect);
    }*/
    //BMI = �魫/����*����
    /// <summary>
    /// �p��BMI����k
    /// </summary>
    /// <param name="weight">�魫�A��쬰����</param>
    /// <param name="height">�����A��쬰����</param>
    /// <param name="name">�W�١A���q�̪��W��</param>
    /// <returns>BMI �����G</returns>
    private float BMI(float weight, float height, string name = "����")
    {
        print(name + "��BMI");
        return weight / (height * height);
    }
    /// <summary>
    /// ���ʳt��
    /// </summary>
    /// <param name="speed"></param>
    private void Movement(float speed)
    {
        print("���ʳt��" + speed);
    }
    private float MoveInput()
    {
        return 0;
    }
    private bool checkground()
    {
        return false;
    }
    private void JumpUp()
    {

    }
    private void UpdateAnimation()
    {

    }
    #endregion

    #region �ƥ� Event
    //�S�w�ɶ��ɶ��I�|���檺��k�A�{�����J�fStart ����Console Main
    //�}�l�ƥ�:�C���}�l�ɰ���@�� -�B�z��l�ơA���o��Ƶ���
    private void Start()
    {
        #region ��X ��k
        /**��X��k
         private void Start()
        {
            
            print("���o�A�U�w~");

            Debug.Log("�@��T��");
            Debug.LogWarning("ĵ�i�T��");
            Debug.LogError("���~�T��");
            #endregion
        }
        
        //��s�ƥ�:�@�������60���A60FPS - Frame Per Second
        //�B�z����ʹB�ʡA���ʪ���A��ť���a��J����
        private void Update()
        {
        }
        //�I�s�ۭq��k�y�k:��k�W��();
        Test();
        Test();
        //�I�s���Ǧ^�Ȫ���k
        //1.�ϰ��ܼƫ��w�Ǧ^�� - �ϰ��ܼƶȯ�b�����c(�j�A��)���s��
        int j = ReturnJump();
        print("���D��: " + j);
        //2.�N�Ǧ^��k���Ȩϥ�
        print("���D�ȡA��Ȩϥ�: " + (ReturnJump() + 1));**/
        #endregion

        //�Ѽƻy�k:������� �ѼƦW��

        /**���ϥΰѼ�
        Skill100();
        Skill150();**/
        //�ƭȥH�Ѽƪ��覡�I�s
        Skill(500);

        //�n���o�}�����C������i�H�ϥ�����rgameObject
        //�ݨD:�ˮ`��500�A�ޯ�S�ĥιw�]�ȡA���Ĵ���������
        //���h�ӿ�񦡰ѼƤQ�i�ϥΫ��W�Ѽƻy�k: �ѼƦW��: ��
        Skill(500, sound: "������");
        print(BMI(75, 1.7f, "Eric"));
        //���o���󪺤覡
        //1. �������W��.���o���(����(��������))��@ ��������;
        aud = playerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //2. ���}���C������.���o���<�x��>();
        rig = gameObject.GetComponent<Rigidbody>();
        //3. ���o����<�x��>()
        ani = GetComponent<Animator>();

    }


    #endregion

}