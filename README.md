# @Serilog.Sinks.LogEmAll
### The Original LogEmAll Logger
## About
LogEmAll or LEA writes Serilog events to a List&lt;String&gt; or a Windows Forms Application RichTextBox control from anywhere in your application.  
## Dependencies
The following NuGet Packages are required to build a Debug and/or Release version of this library:
- Serilog
## Getting started
To use the LogEmAll sink,  
  
First install the <a href="https://www.nuget.org/packages/Serilog/">Serilog</a> NuGet package to your solution projects.  
  
Second, install the <a href="https://github.com/TwistedTommy/Serilog.Sinks.LogEmAll">Serilog.Sinks.LogEmAll</a> NuGet Package to your solution projects.  
  
Third, add the relevent `using` statements to the top of your code where you want to use the logger, like the following:
```
using Serilog;
using Serilog.Sinks.LogEmAll;
```
Fourth, enable a sink in your program, using `WriteTo.RichTextBoxLog()` or `WriteTo.ListStringLog()` like the following:
```
Log.Logger = new LoggerConfiguration()
.WriteToRichTextBox()
.WriteToListString()
.CreateLogger();
```
Optionally, you may format your logger, using `ITextFormatter` like the following:
```
Log.Logger = new LoggerConfiguration()
.WriteToRichTextBox(new MessageTemplateTextFormatter("[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"))
.WriteToListString(new MessageTemplateTextFormatter("[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{Exception}"))
.CreateLogger();
```
Fifth, create an instance of a sink in your code by dragging a `RichTextBoxLog` onto your GUI Design View or by adding a `ListStringLog` in your class like the following:
```
static private ListStringLog _logList = new ListStringLog();
static public ListStringLog LogList
{
  get { return _logList; }
  set { _logList = value; }
}
```
Sixth, use the `Log` anywhere in your code like the following:
```
Log.Debug("This is debug information!");
Log.Information("Hello, world!");
Log.Warning("This is a warning!");
Log.Error("An ERROR has occurred!");
```
Log events will be printed to your `RichTextBoxLog` or saved to your `ListStringLog`.
## Contributing
Let's work better together. We are looking to collaborate with like-minded people who want to contribute in any capacity. Collaboration is open to everyone and we need your help if you are a:  
- Collector
- Database Administrator
- Datter
- Developer
- Dumper
- Graphic Artist
- Linguist/Translator
- Player
- Tester
## Contact
GitHub: [https://github.com/TwistedTommy/Serilog.Sinks.LogEmAll](https://github.com/TwistedTommy/Serilog.Sinks.LogEmAll "GitHub")  
## Disclaimer
This software may only be used and/or distributed in accordance with the license with which it is distributed.
###### Copyright (c) 2016-2022 LogEmAll - All Rights Reserved v2022-04-15-00
