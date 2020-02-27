using System;
using PlantGrower.Models;

namespace PlantGrower
{
  class Program
  {
    static void Main()
    {
      Plant newPlant = new Plant(5, 5, 5);
      newPlant.UserChoice();
    }
  }
}
