using System;

namespace PlantGrower.Models
{
  public class Plant
  {
    public int Height { get; set; }
    public int Thirst { get; set; }
    public int Hunger { get; set; }
    public int Sun { get; set; }
    public bool GameOver { get; set; }

    public Plant(int thirst, int hunger, int sun)
    {
      Height = 0;
      Thirst = thirst;
      Hunger = hunger;
      Sun = sun;
      GameOver = false;
    }

    // Methods

    public void UserChoice()
    {
      while (GameOver == false)
       {
        Console.WriteLine("Enter W to water your plant. Enter F to feed your plant.");
        string userInput = Console.ReadLine();
        string responseLower = userInput;
        if (responseLower == "w")
        {
          WaterPlant();
        }
        else if (responseLower == "f")
        {
          FeedPlant();
        }
        TimePass();
        WriteOutput();
        StatusCheck();
      }
    }
    public void WaterPlant()
    {
      Thirst += 2;
    }
    public void FeedPlant()
    {
      Hunger -= 1;
    }
    public void TimePass()
    {
      Sun += 1;
      if (Sun % 2 == 0)
      {
        Height += 1;
      }
      Thirst -= 1;
      RandomEvent();
    }
    public void RandomEvent()
    {
      var rand = new Random();
      int randomNumber = rand.Next(1, 6);
      if (randomNumber == 1)
      {
        Console.WriteLine("A storm rolls through!");
        Height -= 1;
        Thirst +=1;
      }
      if (randomNumber == 2)
      {
        Console.WriteLine("Extra sunny out today.");
        Sun += 1;
      }
      if (randomNumber == 3)
      {
        Console.WriteLine("Bug attack!");
        Height -= 1;
        Hunger -= 2;
      }
      if (randomNumber == 4)
      {
        Console.WriteLine("A peaceful day...");
      }
      if (randomNumber == 5)
      {
        Console.WriteLine("Look! A Bee!!");
      }
    }
    public void WriteOutput()
    {
      Console.WriteLine("Thirst: " + Thirst);
      Console.WriteLine("Hunger: " + Hunger);
      Console.WriteLine("Sun: " + Sun);
      Console.WriteLine("Height: " + Height);
    }
    public void StatusCheck()
    {
      if ((Hunger == 20) || (Thirst == 0) || (Height == 0))
      {
        GameOver = true;
        Console.WriteLine("Your plant died! Enter 'Y' if you want to play again.");
        NewGame();
      }
      else if (Height == 5)
      {
        GameOver = true;
        Console.WriteLine("Your plant has flourished! Enter 'Y' if you want to play again.");
        NewGame();
      }
    }
    public void NewGame()
    {
      string yesNo = Console.ReadLine();
      string yesNoLower = yesNo.ToLower();
      if( yesNoLower == "y")
      {
        GameOver = false;
        Height = 0;
        Hunger = 5;
        Thirst = 5;
        Sun = 5;
        UserChoice();
      }
      else
      {
        Console.WriteLine("Goodbye!");
      }
    }
  }
}