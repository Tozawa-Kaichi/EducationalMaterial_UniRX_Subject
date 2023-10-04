using System;

// 独自の例外クラスを定義
public class UntaggedException : Exception
{
    // コンストラクタ
    public UntaggedException()
    {
    }

    public UntaggedException(string message) : base(message)
    {
    }

    public UntaggedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    // カスタムのプロパティやメソッドを追加することもできます
    public string CustomProperty { get; set; }
}
