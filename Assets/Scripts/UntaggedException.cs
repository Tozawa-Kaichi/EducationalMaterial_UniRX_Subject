using System;

// �Ǝ��̗�O�N���X���`
public class UntaggedException : Exception
{
    // �R���X�g���N�^
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

    // �J�X�^���̃v���p�e�B�⃁�\�b�h��ǉ����邱�Ƃ��ł��܂�
    public string CustomProperty { get; set; }
}
