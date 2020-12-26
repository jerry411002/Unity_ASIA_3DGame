
using UnityEngine;
using UnityEngine.UI;
using System.Collections;   //引用 系統.集合API(包含協同程序)

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData Data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval;

    ///<summary>
    ///玩家是否進入感應區
    ///</summary>

    public bool playerInarea;

    //定義列舉enum(下拉式選單，只能選一個)
    public enum NPCState
    {
        FirstDialog,Missioning,Finish
    }
    //列舉欄位
    //修飾詞 列舉名稱 自定欄位名稱 指定預設值
    public NPCState state = NPCState.FirstDialog;

  /*
 private void Start()
    {
        //啟動協程
        StartCoroutine(Test());
    }
    
    private IEnumerator Test()
    {
        print("嗨");
        yield return new WaitForSeconds(1.5f);
        print("嗨!，我是一點五秒後");
        yield return new WaitForSeconds(2f);
        print("嗨!，我是兩秒後");
    }
  */
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "阿明")
        {
            playerInarea = true;
           StartCoroutine(dialoug());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "阿明")
        { 
            playerInarea = false;
            Stopdialog();
        }
    }
    /// <summary>
    /// 停止對話
    /// </summary>
    private void Stopdialog()
    {
        dialog.SetActive(false);  //關閉對話框
        StopAllCoroutines();      //停止所有協程
    }
    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator dialoug()
    {
          /**
        //print(Data.dialougA);
        //rint(Data.dialougA[3]);   //娶得字串部份資料:語法[編號]

        //ctrl+c+k 加註解
        //for 迴圈：重複處理相同程式
        //for (int i = 0; i < 10; i++)
        //{
        //    print("我是迴圈：" + i);

        //}
       **/
        //顯示對話框
        dialog.SetActive(true);
        //清空 文字
        textContent.text = "";
        textName.text = name;
        //要說的對話
        string dialogString = Data.dialougB;
    
        switch (state)
        {
            case NPCState.FirstDialog:
               dialogString = Data.dialougA;
                break;  //break：處理完就出去
            case NPCState.Missioning:
          dialogString = Data.dialougB;
                break;
            case NPCState.Finish:
               dialogString = Data.dialougC;
                break;
        }
       
        for (int i = 0; i <dialogString.Length;i++)
        {
            //print(data.dialogA[i]);
            //文字 串聯
            textContent.text+= dialogString[i]  +"";
            yield return new WaitForSeconds(interval);
        }
    }    
}
