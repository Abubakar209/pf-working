using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZInput;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public class playerFn
        {
            public int px = 25;
            public int py = 15;
            public List<int> PBX = new List<int>(new int[1000]);
            public List<int> PBY = new List<int>(new int[1000]);
            public List<bool> isBulletActive = new List<bool>(new bool[1000]);
            public int bulletCount = 0;
            /* public int[] PBX = new int[1000];
             public int[] PBY = new int[1000];
             public bool[] isBulletActive = new bool[1000];*/
            public int playerHealth = 30;
        }

        public class enemy1Fn
        {
            public int Ex = 70;
            public int Ey = 5;
            public int bulletCountE1 = 0;
            public List<int> E1BX = new List<int>(new int[1000]);
            public List<int> E1BY = new List<int>(new int[1000]);
            public List<bool> isBulletActiveE1 = new List<bool>(new bool[1000]);
            /* public int[] E1BX = new int[1000];
             public int[] E1BY = new int[1000];
             public bool[] isBulletActiveE1 = new bool[1000];*/
            public string direction = "up";
            public int enemyHealth = 10;
        }


        static void Main(string[] args)
        {
           
            playerFn playerCordinates = new playerFn();
            enemy1Fn enemy1Cordinates = new enemy1Fn();

            int score = 0;





            char[,] Player2d = new char[3, 7] {
    {'(', 'o', 'o', ')', ' ', ' ', ' '},
    {'|', '_', '_', '|', '-', '-', '>'},
    {'1', ' ', ' ', '1', ' ', ' ', ' '}
};

            char[,] enemy1 = new char[3, 4]{

                { ' ', '-', '-', '-'},
                { '<', '(', '_', ')'},
                { ' ', 'O', 'O', 'O'},

};







            char[,] maze5d = new char[30, 90] {
 { '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%','%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
 { '%', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '%' },
{ '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%','%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%', '%' },
            };





            Printmaze(maze5d);
            while (playerCordinates.playerHealth != 0 && enemy1Cordinates.enemyHealth != 0)
            {
                PrintPlayer(Player2d, playerCordinates);

                Thread.Sleep(90);
                Score(ref score);
                playerhealth(playerCordinates);
                Enemy1health(enemy1Cordinates);
                moveleft(maze5d, Player2d, playerCordinates);
                moveright(maze5d, Player2d, playerCordinates);
                moveup(maze5d, Player2d, playerCordinates);
                movedown(maze5d, Player2d, playerCordinates);
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    GenerateBullet(playerCordinates);

                }

                MoveBullet(maze5d, playerCordinates, enemy1Cordinates, ref score);
                MoveEnemy1(maze5d, enemy1Cordinates, enemy1);
                GenerateEnemyBullet(enemy1Cordinates);
                MoveBulletEnemy1(maze5d, enemy1Cordinates, playerCordinates);



            }
        }

        static void MoveEnemy1(char[,] maze5d, enemy1Fn enemy1Cordinates, char[,] enemy1)
        {
            if (enemy1Cordinates.direction == "up")
            {
                if (maze5d[enemy1Cordinates.Ey - 1, enemy1Cordinates.Ex] == ' ')
                {
                    eraseenemy1(enemy1Cordinates, 3, 4);
                    enemy1Cordinates.Ey--;
                    PrintEnemy1(enemy1, enemy1Cordinates);
                }
                else if (maze5d[enemy1Cordinates.Ey - 1, enemy1Cordinates.Ex] == '%')
                {
                    enemy1Cordinates.direction = "down";
                }

            }
            if (enemy1Cordinates.direction == "down")
            {
                if (maze5d[enemy1Cordinates.Ey + 3, enemy1Cordinates.Ex] == ' ')
                {
                    eraseenemy1(enemy1Cordinates, 3, 4);
                    enemy1Cordinates.Ey++;
                    PrintEnemy1(enemy1, enemy1Cordinates);
                }
                else if (maze5d[enemy1Cordinates.Ey + 3, enemy1Cordinates.Ex] == '%')
                {
                    enemy1Cordinates.direction = "up";
                }
            }
        }
        static void Score(ref int score)
        {
            Console.SetCursorPosition(100, 4);
            Console.Write("Score:  " + score + "    ");
        }

        static void playerhealth(playerFn playerCordinates)
        {
            Console.SetCursorPosition(100, 6);
            Console.Write("Player_Health:  " + playerCordinates.playerHealth + "    ");
        }
        static void Enemy1health(enemy1Fn enemy1Cordinates)
        {
            Console.SetCursorPosition(100, 8);
            Console.Write("Player_Health:  " + enemy1Cordinates.enemyHealth + "    ");
        }


     

        static void MoveBulletEnemy1(char[,] maze5d, enemy1Fn enemy1Cordinates, playerFn playerCordinates)
        {
            for (int i = 0; i < enemy1Cordinates.bulletCountE1; i++)
            {
                if (enemy1Cordinates.isBulletActiveE1[i] == true)
                {
                    if (maze5d[enemy1Cordinates.E1BY[i], enemy1Cordinates.E1BX[i] - 1] == ' ')
                    {
                       
                        Console.SetCursorPosition(enemy1Cordinates.E1BX[i], enemy1Cordinates.E1BY[i]);
                        Console.Write(" ");
                        enemy1Cordinates.E1BX[i] = enemy1Cordinates.E1BX[i] - 1;
                        enemy1Cordinates.E1BY[i] = enemy1Cordinates.E1BY[i];
                        Console.SetCursorPosition(enemy1Cordinates.E1BX[i], enemy1Cordinates.E1BY[i]);
                        Console.Write(".");
                        //printEnemy1bullet(enemy1Cordinates.E1BX[i], enemy1Cordinates.E1BY[i]);
                        if (enemy1Cordinates.E1BX[i] >= playerCordinates.px && enemy1Cordinates.E1BX[i] <= playerCordinates.px + 4 && enemy1Cordinates.E1BY[i] >= playerCordinates.py && enemy1Cordinates.E1BY[i] <= playerCordinates.py + 3)
                        {
                            Console.SetCursorPosition(enemy1Cordinates.E1BX[i], enemy1Cordinates.E1BY[i]);
                            Console.Write(" ");
                            playerCordinates.playerHealth--;

                            enemy1Cordinates.isBulletActiveE1[i] = false;
                        }

                        //printPlayerbullet(PBX[i], PBY[i]);
                    }

                    else
                    {
                        Console.SetCursorPosition(enemy1Cordinates.E1BX[i], enemy1Cordinates.E1BY[i]);
                        Console.Write(" ");
                        enemy1Cordinates.isBulletActiveE1[i] = false;


                    }
                }

            }
        }

        static void MoveBullet(char[,] maze5d, playerFn playerCordinates, enemy1Fn enemy1Cordinates, ref int score)
        {
            for (int i = 0; i < playerCordinates.bulletCount; i++)
            {
                if (playerCordinates.isBulletActive[i] == true)
                {
                    if (maze5d[playerCordinates.PBY[i], playerCordinates.PBX[i] + 1] == ' ')
                    {
                        //erasePlayerbullet( PBX[i], PBY[i]);
                        Console.SetCursorPosition(playerCordinates.PBX[i], playerCordinates.PBY[i]);
                        Console.WriteLine(" ");
                        playerCordinates.PBX[i] = playerCordinates.PBX[i] + 1;
                        playerCordinates.PBY[i] = playerCordinates.PBY[i] ;
                        Console.SetCursorPosition(playerCordinates.PBX[i], playerCordinates.PBY[i]);
                        Console.Write("*");
                       // printPlayerbullet(playerCordinates.PBX[i], playerCordinates.PBY[i]);
                        if (playerCordinates.PBX[i] >= enemy1Cordinates.Ex && playerCordinates.PBX[i] <= enemy1Cordinates.Ex + 4 && playerCordinates.PBY[i] >= enemy1Cordinates.Ey && playerCordinates.PBY[i] <= enemy1Cordinates.Ey + 3)
                        {
                            Console.SetCursorPosition(playerCordinates.PBX[i], playerCordinates.PBY[i]);
                            Console.WriteLine(" ");
                            score++;
                            enemy1Cordinates.enemyHealth = enemy1Cordinates.enemyHealth - 1;
                            playerCordinates.isBulletActive[i] = false;
                        }

                        //printPlayerbullet(PBX[i], PBY[i]);
                    }

                    else
                    {
                        Console.SetCursorPosition(playerCordinates.PBX[i], playerCordinates.PBY[i]);
                        Console.WriteLine(" ");
                        playerCordinates.isBulletActive[i] = false;


                    }
                }

            }
        }


        static void printPlayerbullet(int x, int y)
        {
            Gotoxy(ref x, ref y);
            Console.Write("*");
        }

        static void printEnemy1bullet(int x, int y)
        {
            Gotoxy(ref x, ref y);
            Console.Write(".");
        }

        static void Gotoxy(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y);
        }
        static void erasePlayerbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

        static void eraseEnemy1bullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }



        static void moveleft(char[,] maze5d, char[,] Player2d, playerFn playerCordinates)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                int blankSpacesInRow = 0;

                // Loop through each row in the column directly to the left of the player's current position
                for (int row = playerCordinates.py; row < playerCordinates.py + 3; row++)
                {
                    if (maze5d[row, playerCordinates.px - 1] == ' ')
                    {
                        blankSpacesInRow++;
                    }
                    else
                    {
                        // If we encounter a non-blank space, break out of the loop
                        break;
                    }
                }

                // If we found a continuous row of blank spaces, move the player left
                if (blankSpacesInRow == 3)
                {
                    erase(playerCordinates, 3, 7);
                    playerCordinates.px--;
                    PrintPlayer(Player2d, playerCordinates);
                }
            }
        }


















        static void moveright(char[,] maze5d, char[,] Player2d, playerFn playerCordinates)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                int blankSpacesInRow = 0;

                // Loop through each row in the column directly to the right of the player's current position
                for (int row = playerCordinates.py; row < playerCordinates.py + 3; row++)
                {
                    if (maze5d[row + 1, playerCordinates.px + 7] == ' ')
                    {
                        blankSpacesInRow++;
                    }
                    else
                    {
                        // If we encounter a non-blank space, break out of the loop
                        break;
                    }
                }

                // If we found a continuous row of blank spaces, move the player right
                if (blankSpacesInRow == 3)
                {
                    erase(playerCordinates, 3, 7);
                    playerCordinates.px++;
                    PrintPlayer(Player2d, playerCordinates);
                }
            }
        }







        static void moveup(char[,] maze5d, char[,] Player2d, playerFn playerCordinates)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                int blankSpacesInRow = 0;

                // Loop through each column in the row directly above the player's current position
                for (int col = playerCordinates.px; col < playerCordinates.px + 7; col++)
                {
                    if (maze5d[playerCordinates.py - 1, col] == ' ')
                    {
                        blankSpacesInRow++;
                    }
                    else
                    {
                        // If we encounter a non-blank space, break out of the loop
                        break;
                    }
                }

                // If we found a continuous row of blank spaces, move the player up
                if (blankSpacesInRow == 7)
                {
                    erase(playerCordinates, 3, 7);
                    playerCordinates.py--;
                    PrintPlayer(Player2d, playerCordinates);
                }
            }
        }










        static void movedown(char[,] maze5d, char[,] Player2d, playerFn playerCordinates)
        {
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                int blankSpacesInRow = 0;

                // Loop through each column in the row directly below the player's current position
                for (int col = playerCordinates.px; col < playerCordinates.px + 7; col++)
                {
                    if (maze5d[playerCordinates.py + 3, col] == ' ')
                    {
                        blankSpacesInRow++;
                    }
                    else
                    {
                        // If we encounter a non-blank space, break out of the loop
                        break;
                    }
                }

                // If we found a continuous row of blank spaces, move the player down
                if (blankSpacesInRow == 7)
                {
                    erase(playerCordinates, 3, 7);
                    playerCordinates.py++;
                    PrintPlayer(Player2d, playerCordinates);
                }
            }
        }








        static void erase(playerFn playerCordinates, int playerRows, int playerCols)
        {
            for (int row = 0; row < playerRows; row++)
            {
                Console.SetCursorPosition(playerCordinates.px, playerCordinates.py + row);
                for (int col = 0; col < playerCols; col++)
                {
                    Console.Write(" ");
                }
            }


        }

        static void eraseenemy1(enemy1Fn enemy1Cordinates, int playerRows, int playerCols)
        {
            for (int row = 0; row < playerRows; row++)
            {
                Console.SetCursorPosition(enemy1Cordinates.Ex, enemy1Cordinates.Ey + row);
                for (int col = 0; col < playerCols; col++)
                {
                    Console.Write(" ");
                }
            }


        }












        static void PrintPlayer(char[,] Player2d, playerFn playerCordinates)
        {




            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(playerCordinates.px, playerCordinates.py + row);
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(Player2d[row, col]);
                }
                if (row != 2)
                {

                Console.WriteLine();

                }
            }

        }



        static void PrintEnemy1(char[,] enemy1, enemy1Fn enemy1Cordinates)
        {




            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(enemy1Cordinates.Ex, enemy1Cordinates.Ey + row);
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(enemy1[row, col]);
                }
                if (row != 2)
                {

                    Console.WriteLine();

                }
            }

        }




        static void Printmaze(char[,] maze5d)
        {




            for (int row = 0; row < 30; row++)
            {

                for (int col = 0; col < 90; col++)
                {
                    Console.Write(maze5d[row, col]);
                }
                Console.WriteLine();
            }

        }







     
        static void GenerateBullet(playerFn playerCordinates)
        {
            int bulletCount = playerCordinates.bulletCount;
            playerCordinates.PBX[bulletCount] = playerCordinates.px + 7;
            playerCordinates.PBY[bulletCount] = playerCordinates.py + 1;
            playerCordinates.isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(playerCordinates.PBX[bulletCount], playerCordinates.PBY[bulletCount]);
            Console.Write("*");
            playerCordinates.bulletCount++;
        }




    

        static void GenerateEnemyBullet(enemy1Fn enemy1Cordinates)
        {
            int bulletCount = enemy1Cordinates.bulletCountE1;
            enemy1Cordinates.E1BX[bulletCount] = enemy1Cordinates.Ex - 1;
            enemy1Cordinates.E1BY[bulletCount] = enemy1Cordinates.Ey + 1;
            enemy1Cordinates.isBulletActiveE1[bulletCount] = true;
            Console.SetCursorPosition(enemy1Cordinates.E1BX[bulletCount], enemy1Cordinates.E1BY[bulletCount]);
            Console.Write(".");
            enemy1Cordinates.bulletCountE1++;
        }









        
    }
}
