namespace EricDialogue
{
    //列舉: enum(enumeration)下拉式選單，可自行定義選項
    //語法: 修飾詞 列舉 列舉名稱 {列舉內容1,2,3.....,列舉內容n}

    /// <summary>
    /// NPC任務狀態列舉
    /// 接任務前、任務進行中、完成任務
    /// </summary>
    public enum State
    {
        BeforeMission, Missionning, AfterMission
    }
}
