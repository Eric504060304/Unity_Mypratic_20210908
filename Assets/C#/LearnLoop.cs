using UnityEngine;


namespace Eric.Practice
{
    /// <summary>
    /// �{�Ѱj��
    /// while�Bdo while�Bfor�Bforeach
    /// </summary>
    public class LearnLoop: MonoBehaviour
    {
        private void Start()
        {
            //�j��Loop
            //���ư���{�����e
            //�ݨD:��X�Ʀr1-5
            print(1);
            print(2);
            print(3);
            print(4);
            print(5);

            //while�j��
            //�y�k: if (���L��){�{�����e}   -���L����true����@��
            //�y�k: while(���L��){�{�����e} -���L����true�������
            int a = 1;

            while (a<6)
            {
                print("�j��while" + a);
                a++;
            }
            for(int  i = 0; i < 6; i++)
            {
                print("�j�� for" + i);
            }
        }
    }
}
