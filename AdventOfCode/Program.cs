// See https://aka.ms/new-console-template for more information
using AdventOfCode._2023.Day13;
using AdventOfCode.Kernel;
using Kernel;
using System.Diagnostics;
using System.Reflection;


var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(ChallengeAttribute)));


var challengeToRun = "Sand Slabs";

Type? type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsDefined(typeof(ChallengeAttribute)) 
    && t?.GetCustomAttribute<ChallengeAttribute>()?.GetName() == challengeToRun);

if (type == null)
    throw new Exception("Challenge does not exist");

var solver = (IChallenge)Activator.CreateInstance(type)!;
var filePath = File.ReadAllText("..\\..\\..\\" + type.GetCustomAttribute<ChallengeAttribute>()!.GetInputFilePath());

var stopWatch = new Stopwatch();

stopWatch.Start();

Console.WriteLine(solver.SolvePartOne(filePath));

Console.WriteLine(solver.SolvePartTwo(filePath));

stopWatch.Stop();
var ts = stopWatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);

Console.WriteLine("Challenge solved in " + elapsedTime);

