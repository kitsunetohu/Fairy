using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    GameObject gui; //guiのオブジェクト
    GuiTextMessage script; //GuiTextMessageスクリプトが入る変数

    // Use this for initialization
    void Start()
    {
        gui = GameObject.Find("GUI"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = gui.GetComponent<GuiTextMessage>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        //電気つけたときとか。
        if (Input.GetKey(KeyCode.Space))
        {
            script.setTextWithTime("少女「デンキ ツイタ」", 3);
        }
    }
}
