﻿using System;
using System.Diagnostics;
using CommandLine.Text;
using myage.Classes;


var title = new HeadingInfo(programName: "Get your age", version: "1.0.1");
Debug.WriteLine(title);
CommandLineHelp.ParseArguments(args);


