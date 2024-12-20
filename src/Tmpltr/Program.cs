﻿// See https://aka.ms/new-console-template for more information

using Tmpltr;

try
{
    var cancellationTokenSource = new CancellationTokenSource();
    
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true;
        
        cancellationTokenSource.Cancel();
    };
    
    var arguments = CommandLineParser.Parse(args);
    
    if (arguments == null) return 0;
    
    await Templater.Execute(arguments, cancellationTokenSource.Token);
    return 0;
}
catch (Exception e)
{
    Console.Error.WriteLine(e.Message);
    return -1;
}
