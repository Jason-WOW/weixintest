using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;

/// <summary>
/// CheckSignature 的摘要说明
/// </summary>
public class CheckSignature
{
    public const string Token = "weixin";
    public CheckSignature()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
         
    }
    public static bool Check(string signature, string timestamp, string nonce, string token)
    {
        return signature == GetSignature(timestamp,nonce,token);
    }
    public static string GetSignature(string timestamp, string noce, string token = Token)
    {
        token = token ?? Token;
        string[] arr = new[] { token,timestamp,noce}.OrderBy(z=>z).ToArray();
        string arrstring = string.Join("",arr);
        var tempsign = FormsAuthentication.HashPasswordForStoringInConfigFile(arrstring, "SHA1").ToLower();
        return tempsign;
    }
}