
using UnityEngine;

//建立資源選單("檔案名稱","選單名稱")
[CreateAssetMenu(fileName ="NPC資訊",menuName ="IceTalker/NPC資料")]
public class NPCData : ScriptableObject
    //scriptable;腳本化物件
    //將腳本資料變成物件保存在專案內
{
    [Header("第一段對話"),TextArea(1,5)]
    public string dialougA; 
    [Header("第二段對話"), TextArea(1, 5)]
    public string dialougB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string dialougC;

    [Header("任務項目需求數量")]
    public int count; 
    [Header("已取得項目需求數量")]
    public int countCurrent;
        

}
