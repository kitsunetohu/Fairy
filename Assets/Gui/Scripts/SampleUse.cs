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
        gui = GameObject.Find("GUI"); // GUIオブジェクトの検索
        script = gui.GetComponent<GuiTextMessage>(); // GuiTextMessageスクリプトをget
    }

    // Update is called once per frame
    void Update()
    {
        //電気つけたときとか。
        if (Input.GetKey(KeyCode.Space))
        {
            // 3秒間テキスト表示
            script.setTextWithTime("少女「デンキ ツイタ」", 3);
        }
    }
}
