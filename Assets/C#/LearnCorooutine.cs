using System.Collections;
using UnityEngine;
namespace Eric.Practice
{
    public class LearnCorooutine : MonoBehaviour
    {
        //�w�q���P�{�Ǥ�k
        //IEnumerator ����P�{�ǶǦ^���A�i�Ǧ^�ɶ�
        //yield ���B
        //new WaitForSeconds(���I��)-���ݮɶ�
        private IEnumerator TestCoroutine()
        {
            print("��P�{�Ƕ}�l����");
            yield return new WaitForSeconds(2);
            print("��P�{�ǵ��ݨ�����榹��");
        }
        public Transform sphere;
        private IEnumerator SphereScale()
        {
            for(int i = 0; i < 10; i++)
            {
                sphere.localScale += Vector3.one;
                yield return new WaitForSeconds(1);
                
            }
            
     }
        private void Start()
        {
            //�Ұʰ��P�{��
            StartCoroutine(TestCoroutine());
        }
    }
}

