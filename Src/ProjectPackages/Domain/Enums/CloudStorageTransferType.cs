namespace Domain.Enums;
public enum CloudStorageTransferType : byte
{
    Local = 0,
    FTP = 2,
    SMB = 6,
    CloudSpecial = 8,
    OpenSource = 10
}