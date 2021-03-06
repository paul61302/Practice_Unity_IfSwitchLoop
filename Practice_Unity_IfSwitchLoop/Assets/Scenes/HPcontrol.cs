﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcontrol : MonoBehaviour
{
    private float _hp;

    public float Hp { get => _hp; set => _hp = value; }


    [Header("滑桿")]
    public Slider Slidervalue;
    [Header("滑桿結果")]
    public Text State;


    public Text HpMpRecover;
    public InputField Recover;
    public string useItem;

    public Text HpNumber;
    public float hpNum;

    [Header("地板")]
    public GameObject Cube;

    private void Awake()
    {
        CreatFloor(10);
    }

    private void CreatFloor(int length)
    {
        for (int j = 0; j < length; j++)
        {
            for (int i = 0; i < (j+1); i++)
            {

                Instantiate(Cube, new Vector3(-9f + (j * 2), -8.8f+ (i * 2), 9.6f), Quaternion.Euler(270, 0, 0));


            }
        }
        
    }

    private void Update()
    {
        #region 練習1
        _hp = Slidervalue.value;

        if (_hp >= 70)
        {
            State.text = "<color=#6ACB26>安全</color>";
        }
        else if (_hp >= 30)
        {
            State.text = "<color=#E7E729>警告</color>";
        }
        else
        {
            State.text = "<color=#FF0000>危險</color>";
        }
        #endregion

        #region 將滑桿以數字表示
        hpNum = Slidervalue.value;
        int intHpNum = System.Convert.ToInt32(hpNum);
        string strHpNum = System.Convert.ToString(intHpNum);
        HpNumber.text = strHpNum ;
        #endregion

        useItem = (Recover.text == "紅水") ? HpMpRecover.text = "<color=#FF0000>恢復血量</color>" : (Recover.text == "藍水") ? HpMpRecover.text = "<color=#0000FF>恢復魔力</color>" : HpMpRecover.text = "你吃了三小?";

    }
}
