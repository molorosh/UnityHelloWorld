using System;

public class HelloMessageMgr
{
    private static string _helloMessage;

    public static string HelloMessage
    {
        get
        {
            if (_helloMessage == null)
            {
                // need to fetch it from the command-line
                string[] args = Environment.GetCommandLineArgs();
                for(int i = 0; i < args.Length; i++)
                {
                    if(args[i] == "-msg" && i < (args.Length - 1))
                    {
                        _helloMessage = args[i + 1];
                        break;
                    }
                }
                if(_helloMessage == null) { _helloMessage = "Hello, Unity!"; }
            }
            return _helloMessage;
        }
    }

}
