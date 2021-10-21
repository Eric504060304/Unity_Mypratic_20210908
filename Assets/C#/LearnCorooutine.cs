using System.Collections;
using UnityEngine;
namespace Eric.Practice
{
    public class LearnCorooutine : MonoBehaviour
    {
        //定義偕同程序方法
        //IEnumerator 為協同程序傳回直，可傳回時間
        //yield 讓步
        //new WaitForSeconds(福點數)-等待時間
        private IEnumerator TestCoroutine()
        {
            print("協同程序開始執行");
            yield return new WaitForSeconds(2);
            print("協同程序等待兩秒後執行此行");
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
            //啟動偕同程序
            StartCoroutine(TestCoroutine());
        }
    }
}

