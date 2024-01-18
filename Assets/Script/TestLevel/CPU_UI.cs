using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CPU_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset TextFile;  //可以丟在記事本打好的文字檔，到時候會用一個字串變數去接。
    public TextMeshProUGUI Text;//TextMeshPro的文字組件
    public float TextShowSpeed; //文字顯示的速度
    public GameObject nextPage; //如果有這個Page有多頁的話可以使用
    
    string words;       //存取電腦的純文字檔內容。
    int currentTextPos; //當前的文字位置，會在string.Substring這邊去使用
    
    float timer;        //計時用的
    bool isActive;      //判斷文字現在是不是正在顯示中，如果顯示完會改成false


    


    void Start()
    {
        timer=0;
        currentTextPos=0;
        words=TextFile.ToString();
        Text.text="";
        isActive=true;
    }

    // Update is called once per frame
    void Update() 
    {
        //這邊會用Substring 的方式來做出打字機的效果。
        if(isActive==true){
            timer+=Time.deltaTime;
            if(timer>=TextShowSpeed){
                timer=0;
                currentTextPos++;
                Text.text=words.Substring(0,currentTextPos);
                //如果當前文字>=words的長度，就是文字全部顯示完成，就會停止。
                if(currentTextPos>=words.Length){
                    currentTextPos=0;
                    isActive=false;
                    

                }

            }

        }




    }
    //如果這個page有1頁以上的話可以使用，可以在同個page切換不同的子頁面。
    public void NextPage(){
        nextPage.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
