
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData Data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;


    ///<summary>
    ///玩家是否進入感應區
    ///</summary>

    public bool playerInarea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "阿明")
        {
            playerInarea = true;
            dialoug();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "阿明")
        { playerInarea = false; }
    }

    private void dialoug()
    {
        //print(Data.dialougA);
        //rint(Data.dialougA[3]);   //娶得字串部份資料:語法[編號]

        //ctrl+c+k 加註解
        //for 迴圈：重複處理相同程式
        //for (int i = 0; i < 10; i++)
        //{
        //    print("我是迴圈：" + i);

        //}
        for (int i = 0; i <Data.dialougA.Length;i++)
        {
            print(Data.dialougA[i]);

        }
    }    
}
