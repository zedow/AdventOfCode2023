// See https://aka.ms/new-console-template for more information
using Kernel;
using System.Reflection;


var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(ChallengeAttribute)));

var challengeToRun = "Pipe maze";

//var type = types.FirstOrDefault(t => t.GetCustomAttribute(typeof(ChallengeAttribute)));