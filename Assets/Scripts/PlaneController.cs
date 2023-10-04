using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
//サブジェクト側   Nullチェック入れるとなおよい
public class PlaneController : MonoBehaviour
{
    //Subjectを作成
    private Subject<Color> colorSubject = new Subject<Color>();
    public IObservable<Color> ColorObservable=> colorSubject;// Subjectを公開するプロパティ
    //{
    //    get { return colorSubject; }
    //}
    private void OnCollisionEnter(Collision collision)//触れた時に
    {
        if (collision.gameObject.CompareTag("Untagged"))//タグがアンタグの時
        {
            colorSubject.OnError(new UntaggedException("タグが全くついていません"));
        }
        Color col = collision.gameObject.
            GetComponent<MeshRenderer>().
            material.color;
        colorSubject.OnNext(col);//オンネクストでストリームをサブスク側に通知
        if (collision.gameObject.CompareTag("Cube"))
        {
            colorSubject.OnCompleted();//ストリームの完了を通知する これ以降はオンネクストされても通知が飛ばない
        }
    }
}
