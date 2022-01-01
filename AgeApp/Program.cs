using System;
using System.Diagnostics;
using CommandLine.Text;
using PromptForUserNamePassword.Classes;

string message = "Welcome to dotnetsay, a .NET tool!";
var title = new HeadingInfo(programName: "My super Get user id and password", version: "1.1.1");
Debug.WriteLine(title);
//CommandLineHelp.ParseArguments("--help".Split());
CommandLineHelp.ParseArguments(args);


