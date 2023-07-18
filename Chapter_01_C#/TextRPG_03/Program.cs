using System;

namespace TextRPG_03
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
            public int atk;
        }

        static PlayerType ChooseType()
        {
            PlayerType playerType = PlayerType.None;

            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 검사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string choice = Console.ReadLine();

            switch (choice)
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
            }

            return playerType;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PlayerType playerType = ChooseType();

                if (playerType == PlayerType.None)
                    continue;

            }
        }
    }
}