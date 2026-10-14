using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
{
    public enum IsExistResult
    {
        NotID,
        IsExist,
        Successful
    }
    public enum IsNotExistResult
    {
        NotID,
        IsNotExist,
        Successful
    }
    public enum HasTagResult
    {
        NotID,
        IsNotExist,
        HasTag,
        Successful
    }
    public enum HasNotTagResult
    {
        NotID,
        IsNotExist,
        HasNotTag,
        Successful
    }
    public enum IsNotCorrectVersionResult
    {
        NotID,
        IsNotExist,
        NoCorrectVersion,
        Successful
    }
    public enum IsBanResult
    {
        NotID,
        IsNotExist,
        IsBan,
        Successful
    }
}
