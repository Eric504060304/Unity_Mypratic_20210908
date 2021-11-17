using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EricDialogue
{
    /// <summary>
    /// ��ܨt�Ϊ����
    /// NPC�n��ܪ��T�Ӷ��q���e
    /// �����ȫe�B���ȶi�椤�B��������
    /// </summary>
    //ScriptableObject �~�Ӧ����O�|�ܦ��}���e����
    //�i�N���}����Ʒ�����O�s�b�M��Project��
    //CreateAssetMenu���O�ݩ�: �������O�إ߱M�פ����
    //menuName���W�١A�i��/���h
    //fileName�ɮצW��
    [CreateAssetMenu(menuName = "Eric/��ܸ��", fileName = "NPC��ܸ��")]
    public class DataDialogue : ScriptableObject
    {
        [Header("��ܪ̭]��")]
        public string nameDialogue;
        //�}�C: �O�s�ۦP������������c
        //TextArea �r���ݩʡA�i�]�w���
        [Header("���ȫe��ܤ��e"), TextArea(2, 7)]
        public string[] beforeMission1;
        [Header("���ȶi�椤��ܤ��e"), TextArea(2, 7)]
        public string[] Missioning;
        [Header("���ȧ�����ܤ��e"), TextArea(2, 7)]
        public string[] afterMission1;
        [Header("���ȻݨD�ƶq"), Range(0, 100)]
        public int countNeed;
        //�ϥΦC�|:
        //�y�k:�׹��� �C�|�W�� �۩w�q���W��;
        [Header("NPC ���Ȫ��A")]
        public State stateNPCMission = State.BeforeMission;//�i�H�]�w�w�]


    }

}
