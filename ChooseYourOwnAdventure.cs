using System;

namespace ChooseYourOwnAdventure
{
  class Program
  {
      static void Main(string[] args)
    {
      //variables
      int[,] map = new int[4, 4];
      ConsoleKeyInfo whatDo;

      //create map
      map[0, 0] = 1;
      map[0,1] = 2;
      map[0,2] = 0;
      map[0,3] = 6;
      map[1,0] = 0;
      map[1,1] = 3;
      map[1,2] = 0;
      map[1,3] = 2;
      map[2,0] = 3;
      map[2,1] = 2;
      map[2,2] = 2;
      map[2,3] = 2;
      map[3,0] = 4;
      map[3,1] = 0;
      map[3,2] = 0;
      map[3,3] = 5;

      //player starts here
      string xCord = "0";
      string yCord = "0";
      int XCord = 0;
      int YCord = 0;
      string uRHere = xCord + yCord;
      /* THE MYSTERIOUS NOISE */

      // Start by asking for the user's name:
      Console.Write("What is your name?: ");
      string name = Console.ReadLine();
      Console.WriteLine($"\n\nHello, {name}! Welcome to our story.\n\n");
      Console.WriteLine("To move use 'wasd' controls\ninvestigate by pressing L and pickup items using P.\n\n");
      Console.WriteLine("What would you like to do?");

      //mechanics
      while(!uRHere.Contains("03"))
      {
        Console.WriteLine($"You are here: [{YCord}, {XCord}]");
        whatDo = Console.ReadKey();
        if(CheckMove(whatDo.Key, XCord, YCord))
        {
          if(whatDo.Key == ConsoleKey.W && !(YCord <= 0))
          {
            if(Blocked(XCord, YCord))
            Console.WriteLine("That way is blocked...");
            else
            YCord--;
          }else{}
          if(whatDo.Key == ConsoleKey.S && !(YCord >= 3))
          {
            if(Blocked(XCord, YCord)){
            Console.WriteLine("That way is blocked...");
            }else{
            YCord++;
            }
          }else{}
          if(whatDo.Key == ConsoleKey.A && !(XCord <= 0))
          {
            if(Blocked(XCord, YCord)){
            Console.WriteLine("That way is blocked...");
            }else{
            XCord -= 1;
            }
          }else{}
          if(whatDo.Key == ConsoleKey.D && !(XCord >= 3))
          {
            if(Blocked(XCord, YCord)){
            Console.WriteLine("That way is blocked...");
            }else{
            XCord += 1;
            }
          }else{}
          uRHere = YCord.ToString() + XCord.ToString();
        }else
        {
        Console.WriteLine(Action(whatDo.Key, map[YCord,XCord]));
        }
        

      }


     //end of main
    }
    static bool CheckMove(ConsoleKey x, int xx, int y)
    {
      if(x == ConsoleKey.W)
      {
        y--;
        if(!Blocked(xx, y))
        {
          return true;
        }else{
      return false;
      }
      }
      else if(x == ConsoleKey.A)
      {
        xx--;
        if(!Blocked(xx, y))
        {
          return true;
        }else{
      return false;
      }
      }
      else if(x == ConsoleKey.S)
      {
        y++;
        if(!Blocked(xx, y))
        {
          return true;
        }else{
      return false;
      }
      }
      else if(x == ConsoleKey.D)
      {
        xx++;
        if(!Blocked(xx, y))
        {
          return true;
        }else{
      return false;
      }
      }
      else{
      return false;
      }
      
    }
    static bool Blocked(int x, int y)
    {
      string xS = x.ToString();
      string yS = y.ToString();
      string loc = yS+xS;
      switch(loc)
      {
        case "10":
          return true;
          break;
        case "02":
          return true;
          break;
        case "12":
          return true;
          break;
        case "31":
          return true;
          break;
        case "32":
          return true;
          break;
          default:
          return false;
      }
    }

    static string Action(ConsoleKey x, int d)
    {
      string act = "";
      //Movement
      if(x == ConsoleKey.W)
      act = "You move north...";
      if(x == ConsoleKey.A)
      act = "You move west...";
      if(x == ConsoleKey.S)
      act = "You move south...";
      if(x == ConsoleKey.D)
      act = "You move east...";

      //Investigate
      if(x == ConsoleKey.L)
      {
        switch(d)
        {
          case 1:
            act = "My room, nothing special...";
            break;
          case 2:
            act = "A creepy hallway...";
            break;
          case 3:
            act = "A creepy hall..wait, something shiny on the floor.";
            break;
          case 4:
            act = "*Opens Door* Whose room is this? Nothing special here";
            break;
          case 5:
            act = "*Opens Door* Hey! Theres something here!";
            break;
          case 6:
            act = "You cheated to get here didn't you?";
            break;
          default:
            break;
        }
      return act;
      }

      //Pickup
      if(x == ConsoleKey.P)
      {
        switch(d)
        {
          case 3:
          act = "You found a key on the floor!";
          break;
          case 5:
          act = "You found a key in some icky black goo!";
          break;
          default:
          act = "Nothing to pickup here..";
          break;
        }
      }

      return act;

    }


    //end of class
  }

  //end of namespace
}
