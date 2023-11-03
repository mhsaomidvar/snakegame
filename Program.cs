using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;


namespace game{
class Snake{




    public static void Main()
    {
        int snakeLen = 6 , col = 38, row=15;
        char ch;
        List<string> snake = new List<string>();
        List<Point> snakeLoc = new List<Point>();
        List<Point> randomLoc = new List<Point>();
        Random food = new Random();
        int foodcount = 2;


        for(int i = 0; i < snakeLen; i++)
        {
            if(i == 0)
            snake.Add("0");
            else
            snake.Add("■");
        }

        for(int i = 0; i < snakeLen; i++)
        {
            snakeLoc.Add(new Point(col,row));
            ++col;
        }

        foreach(Point point in snakeLoc)
        {
            int i = 0;
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(snake[i++]);
        }

        

        for(int i = 0; i < foodcount; i++){
            int randomX = food.Next(0, Console.WindowWidth);
            int randomY = food.Next(0, Console.WindowHeight);
            randomLoc.Add(new Point(randomX, randomY));
            Console.SetCursorPosition(randomX, randomY);
            Console.Write("$"); 
            }
        Console.SetCursorPosition(snakeLoc[0].X, snakeLoc[0].Y);
        Console.CursorVisible = false;
        Point head = snakeLoc.First();
            

        
      for(;;)
    {

                
        ch = Console.ReadKey(true).KeyChar;
        switch(ch)
        {
            case 'a':
            if(head.X == 0)
            goto EXIT;
            
            else
            --head.X;
            break;

            case 'd':
            if(head.X == Console.WindowWidth-1)
            goto EXIT;
            else
            ++head.X;
            break;

            case 'w':
            if(head.Y == 0)
            goto EXIT;
            else
            --head.Y;
            break;

            case 's':
            if(head.Y == Console.WindowHeight-1)
            goto EXIT;
            else
            ++head.Y;
            break;

            case 'q':
            goto EXIT;
            
        }

        for(int i = 1; i<snakeLen; i++)
        {
            if(head.X == snakeLoc[i].X && head.Y == snakeLoc[i].Y)
            {
                Console.SetCursorPosition(snakeLoc[0].X, snakeLoc[0].Y);
                goto EXIT;
            }
            else
                continue;
        }
        foreach(Point point in snakeLoc)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(" ");
        }

        snakeLoc.Insert(0, new Point(head.X, head.Y));

        for(int i = 0; i <foodcount;)
        {
            if(head.X == randomLoc[i].X && head.Y == randomLoc[i].Y){
                ++snakeLen;
                snake.Insert(snake.Count-1,"■");
                Console.SetCursorPosition(head.X, head.Y);
                Console.Write(" ");

                int randomX = food.Next(0, Console.WindowWidth);
                int randomY = food.Next(0, Console.WindowHeight);

                while (snakeLoc.Any(point => point.X == randomX && point.Y == randomY))
                {
                    randomX = food.Next(0, Console.WindowWidth);
                    randomY = food.Next(0, Console.WindowHeight);
                }

        randomLoc[i] = new Point(randomX, randomY);
        Console.SetCursorPosition(randomX, randomY);
        Console.Write("$");

                
                goto CONTIN;
            }
            else
                ++i;

        }
        snakeLoc.RemoveRange(snake.Count-1, 1);

        CONTIN:
        foreach(Point point in snakeLoc)
        {
            if(point.X == snakeLoc[0].X && point.Y == snakeLoc[0].Y){
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write("0");
            }
            else{
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write("■");
            }
        }

        Console.SetCursorPosition(43,15);
        Console.Write(" ");
    } 


    EXIT:
    Console.CursorVisible = true;
    Console.SetCursorPosition(snakeLoc[0].X, snakeLoc[0].Y);
    System.Console.WriteLine("Game Over! You socred: {0}" ,snakeLen-5);

    }
}
}