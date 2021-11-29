
using UnityEngine;
namespace Eric
{
    /// <summary>
    /// 音效系統
    /// 提供窗口給要撥放音效的物件
    /// </summary>
    //套用元件時會要求元件：會自動添加指定的元件
    //[要求元件(類型(元件1),類型(元件2),...)]
    [RequireComponent(typeof(AudioSource))]
    public class AudioSystem : MonoBehaviour
    {
        #region 欄位
        private AudioSource aud;
        #endregion

        #region 事件
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }
        #endregion
        
        #region 方法：公開
        public void PlaySome(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }

        public void PlaySoundRandomVolume(AudioClip sound)
        {
            float volume = Random.Range(0.7f, 1.2f);
            aud.PlayOneShot(sound, volume);
        }
        #endregion

    }

}

