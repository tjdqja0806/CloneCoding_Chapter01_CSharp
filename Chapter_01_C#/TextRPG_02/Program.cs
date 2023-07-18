using System;

namespace TextRPG_02
{
    class Program
    {
        enum PlayerType
        {
            None = 0,
            Knight = 1,
            Archor = 2,
            Mage = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Wolf = 2,
            Dragon = 3
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static Monster CreateMonster()
        {
            Random rand = new Random();
            int randValue = rand.Next(1, 4);
            MonsterType monsterType = MonsterType.None;
            Monster monster = new Monster();
            switch (randValue)
            {
                case 1:
                    Console.WriteLine("슬라임이 스폰되었습니다.");
                    monsterType = MonsterType.Slime;
                    monster.hp = 20;
                    monster.attack = 5;
                    break;
                case 2:
                    Console.WriteLine("늑대가 스폰되었습니다.");
                    monsterType = MonsterType.Wolf;
                    monster.hp = 30;
                    monster.attack = 7;
                    break;
                case 3:
                    Console.WriteLine("드래곤이 스폰되었습니다.");
                    monsterType = MonsterType.Dragon;
                    monster.hp = 50;
                    monster.attack = 10;
                    break;
            }
            return monster;
        }

        static Player CreatePlayer(PlayerType choice)
        {
            Player player = new Player();
            switch (choice)
            {
                case PlayerType.Knight:
                    player.hp = 75;
                    player.attack = 7;
                    break;
                case PlayerType.Archor:
                    player.hp = 40;
                    player.attack = 10;
                    break;
                case PlayerType.Mage:
                    player.hp = 25;
                    player.attack = 12;
                    break;
            }
            return player;
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리");
                    Console.WriteLine($"player의 남은 체력 : {player.hp}");
                    break;
                }
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("플레이어가 사망하였습니다.");
                    Environment.Exit(0);
                }
            }
        }

        static PlayerType EnterGame()
        {
            Console.WriteLine("직업 선택!");

            Console.WriteLine("[1] 검사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            PlayerType playerType = PlayerType.None;

            switch (input)
            {
                case "1":
                    playerType = PlayerType.Knight;
                    break;
                case "2":
                    playerType = PlayerType.Archor;
                    break;
                case "3":
                    playerType = PlayerType.Mage;
                    break;
                default:
                    playerType = PlayerType.None;
                    break;
            }

            return playerType;
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Monster monster = CreateMonster();

                //전투 행동 선택
                Console.WriteLine("[1] 전투를 진행한다.");
                Console.WriteLine("[2] 도망간다.");

                string input = Console.ReadLine();
                if(input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else
                {
                    Random random = new Random();
                    int randValue = random.Next(0, 101);
                    if(randValue >= 50)
                    {
                        Console.WriteLine("도망에 성공하였습니다.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("도망에 실패하였습니다.");
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        static void EnterMenu(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("다음 할 일 고르기!");
                Console.WriteLine("[1] 필드사냥");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PlayerType playerType = EnterGame();
                
                if (playerType != PlayerType.None)
                {
                    //플레이어 생성 hp, attack, 방어력 등
                    Player player = CreatePlayer(playerType);

                    EnterMenu(ref player);
                }

            }
        }
    }
}