﻿// See https://aka.ms/new-console-template for more information
using AdventOfCode.Kernel;
using Kernel;
using System.Reflection;


var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(ChallengeAttribute)));

var challengeToRun = "Hot springs";

Type? type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsDefined(typeof(ChallengeAttribute)) 
    && t?.GetCustomAttribute<ChallengeAttribute>()?.GetName() == challengeToRun);

if (type == null)
    throw new Exception("Challenge does not exist");

var solver = (IChallenge)Activator.CreateInstance(type)!;
var filePath = File.ReadAllText("..\\..\\..\\" + type.GetCustomAttribute<ChallengeAttribute>()!.GetInputFilePath());

Console.WriteLine(solver.SolvePartOne(filePath));

Console.WriteLine(solver.SolvePartTwo(filePath));
