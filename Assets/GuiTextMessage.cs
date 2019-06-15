using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GuiTextMessage : MonoBehaviour
{
    GameObject gameobject;
    [SerializeField]
    Text textObject;


    string message = null;
    Boolean isThereExpire = false;       // falseであれば無限に表示する
    DateTime expireTime;         // 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, world!");
        Debug.Log(textObject);
        textObject = GameObject.Find("TextMessage").GetComponent<Text>();
        Debug.Log(textObject);

        //textObject = textObject.getComponent("Text");
        //      textObject = GameObject.Find("unitychan"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        // 「有効期限の時間」が有効か。
        if (isThereExpire) {

            // 有効時間のチェック
            if (expireTime < DateTime.Now)
            {
                textObject.text = "";
            }
            else {
                textObject.text = this.message;
            }
        }
    }


    /**
     * メッセージ表示するメソッド。既に表示されているメッセージがある場合は上書き。
     * 0秒を指定した場合は、無限に表示する。
     * string message : 表示するメッセージ内容
     * int displayTime : 表示する秒数
     */
    public void setTextWithTime(string message, int displayTime)
    {

        if (displayTime == 0)
        {
            isThereExpire = false;
        }
        else {
            isThereExpire = true;
        }

        this.message = message;
        expireTime = DateTime.Now.AddSeconds(displayTime);

    }

    public void setTextEnum(int messageNumber)
    {


    }

}
