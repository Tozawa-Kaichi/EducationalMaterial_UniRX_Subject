using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
//サブスクする側  Nullチェック入れるとなおよい
public class LightController : MonoBehaviour
{
    [SerializeField] PlaneController planectl;
    Light _directionLight = default;
    private void Start()
    {
        _directionLight = GetComponent<Light>();
        planectl.ColorObservable.Subscribe(ChangeLight,onError:error =>ShowErrorMessage() ,()=>ShowCompletedLog()).AddTo(this);//サブスクライブ：購読する
        //Subscribe()の引数でOnnext、OnError、OnCompleteにそれぞれ対応した処理を賭ける
    }

    //void Subscribe(Subject<Color> colorsubject)//サブスクメソッド
    //{
    //    colorsubject.Subscribe(color =>{_directionLight.color = color;});
    //}
    private void Update()
    {
        
    }
    void ChangeLight(Color color)
    {
        _directionLight .color =color;
    }
    void ShowCompletedLog()
    {
        Debug.Log("コンプリートしました");
    }
    void ShowErrorMessage()
    {
        Debug.LogError("⚠タグが全くついていません⚠");
    }
}
