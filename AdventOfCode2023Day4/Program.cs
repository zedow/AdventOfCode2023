using AdventOfCode2023Day4;
using Kernel;

string filePath = "../../../input.txt";
string[] inputContent = new MyFileReader().ReadFile(filePath);
var total = 0;
var totalScratchCardsPartTwo = 0;
Queue<Card> cardsList = new Queue<Card>();

foreach(string input in inputContent)
{
    var card = new Card(input);
    var cardWoth = card.GetCardWorth();
    cardsList.Enqueue(card);
    if(cardWoth > 0)
    {
        total += cardWoth;
    }
}

foreach(var card in cardsList)
{
    var cardWoth = card.GetCardWorth();
    if (cardWoth > 0)
    {
        //for(int i = 0; i < card)
    }
}

Console.WriteLine("Total cards worth is : " + total);