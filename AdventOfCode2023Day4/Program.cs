using AdventOfCode2023Day4;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var total = 0;
var totalScratchCardsPartTwo = 0;
var cardWatch = new CardsWatcher(inputContent);
cardWatch.SetCardsCopies();

foreach (Card card in cardWatch.GetCards())
{
    var cardWoth = card.GetCardWorth();
    if(cardWoth > 0)
    {
        total += cardWoth;
    }
    totalScratchCardsPartTwo += 1 + card.Copies;
}

Console.WriteLine("Total cards worth is : " + total);
Console.WriteLine("Total cards count (with copies): " + totalScratchCardsPartTwo);