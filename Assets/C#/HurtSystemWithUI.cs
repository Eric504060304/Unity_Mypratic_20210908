using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace Eric
{
    /// <summary>
    /// 繼承受傷系統
    /// 包含介面的受傷系統
    /// 可以處理寫條更新
    /// </summary>
    public class HurtSystemWithUI : HurtSystem
    {
        [Header("要更新的血條")]
        public Image imgHp;

        private float hpEffectOriginal;
        //複寫父類別成員 override
        public override void Hurt(float damage)
        {
            //該成員的父類別基底 父類別內的內容
            //千萬不能刪
            base.Hurt(damage);

            StartCoroutine(HpBarEffect());
        }
        private IEnumerator HpBarEffect()
        {
            while (hpEffectOriginal != hp)                      //當 扣血鉗血量不等於血量
            {
                hpEffectOriginal--;                             //遞減
                imgHp.fillAmount = hpEffectOriginal / hpMax;    //更新血量
                yield return new WaitForSeconds(0.01f);         //等待
            }
        }

    }
}

