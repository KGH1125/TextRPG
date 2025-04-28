namespace textRPG_1
{

    internal class GameManager
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        private GameManager() { }

        public User user = new User();
        public Inventory inventory = new Inventory();

        static void Main()
        {   Shop shop = new Shop();
            GameManager gm = GameManager.Instance;
            gm.Gotitle();

            while (true)
            {
                switch (GetValidInput(1, 2, 3))//1.캐릭터정보 2.인벤토리 3.상점
                {
                    case 1:
                        gm.user.ShowUserInfo();
                        if (GetValidInput(0) == 0) { gm.Gotitle(); }
                        break;

                    case 2:
                        while (true)
                        {
                            gm.inventory.ShowInventory();
                            int inventoryChoice = GameManager.GetValidInput(1, 2);//1.장착관리 2.나가기

                            if (inventoryChoice == 1)
                            {
                                gm.inventory.UpdateInventory();
                            }
                            else if (inventoryChoice == 2)
                            {
                                break;
                            }
                        }
                        gm.Gotitle();
                        break;

                    case 3:
                        shop.ShowShopList();
                        break;
                }
            }
        }
        //타이틀화면 로드
        public void Gotitle()
        {
            Console.Clear();
            Console.WriteLine(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n" +
                "\n" +
                "1. 상태 보기\n" +
                "2. 인벤토리\n" +
                "3. 상점");
        }
        //정답을 받고 유효하지 않은 입력 걸러내기
        public static int GetValidInput(params int[] validOptions)
        {
            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedOption))
                {
                    if (validOptions.Contains(selectedOption))
                    {
                        return selectedOption;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
            }
        }
    }
}
