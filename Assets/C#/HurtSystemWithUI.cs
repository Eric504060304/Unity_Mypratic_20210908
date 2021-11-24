using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace Eric
{
    /// <summary>
    /// �~�Ө��˨t��
    /// �]�t���������˨t��
    /// �i�H�B�z�g����s
    /// </summary>
    public class HurtSystemWithUI : HurtSystem
    {
        [Header("�n��s�����")]
        public Image imgHp;

        private float hpEffectOriginal;
        //�Ƽg�����O���� override
        public override void Hurt(float damage)
        {
            //�Ӧ����������O�� �����O�������e
            //�d�U����R
            base.Hurt(damage);

            StartCoroutine(HpBarEffect());
        }
        private IEnumerator HpBarEffect()
        {
            while (hpEffectOriginal != hp)                      //�� ����X��q�������q
            {
                hpEffectOriginal--;                             //����
                imgHp.fillAmount = hpEffectOriginal / hpMax;    //��s��q
                yield return new WaitForSeconds(0.01f);         //����
            }
        }

    }
}

