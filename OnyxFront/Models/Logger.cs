using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class Logger
{
    private readonly StreamWriter _writer;
    public Logger(string path)
    {
        _writer = new StreamWriter(File.Open(path, FileMode.Append))
        {
            AutoFlush = true
        };

        Log("Logger initialized");
    }
    public virtual void Log(string str)
    {
      
        _writer.WriteLine(LogFormater(str));
    }

    public virtual string LogFormater (string str)
    {
        var LogLine = string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", DateTime.Now, str);
        return LogLine;
    }
}