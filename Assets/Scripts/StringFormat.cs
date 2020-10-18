using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class FileNameFormat
{
    private Regex format;

    public string prefix { get; private set; } = "dt_";
    public string postfix { get; private set; } = string.Empty;
    public string extensionName;

    

    public FileNameFormat(string _prefix, string _postfix, string _extenstionName="data")
    {
        prefix = _prefix;
        postfix = _postfix;
        extensionName = _extenstionName;
        format = new Regex(string.Format(@"^{0}(\w+?){1}.{2}", prefix, postfix, extensionName));
    }

    public bool IsFormatted(string str)
    {
        return format.IsMatch(str);
    }


    public string formateName(string strToFormate)
    {
        return prefix + strToFormate + postfix+'.'+extensionName;
    }

    private static FileNameFormat _Default;

    public static FileNameFormat Default
    {
        get
        {
            if (_Default == null) _Default = new FileNameFormat("dt_", string.Empty);
            return _Default;
        }
    }


}
