using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> _items = new List<Item>();
        public static readonly List<Monster> _monsters = new List<Monster>();
        public static readonly List<Quest> _quests = new List<Quest>();
        public static readonly List<Location> _locations = new List<Location>();
        
        
        
        public const int UNSELLABLE_ITEM_PRICE = -1;
        
        
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_SHOVEL = 2;
        public const int ITEM_ID_WOLF_SKIN = 3;
        public const int ITEM_ID_BEAR_SKIN = 4;
        public const int ITEM_ID_SNAKE_FANG = 5;
        public const int ITEM_ID_TRENTS_CLUB = 6;
        public const int ITEM_ID_SIMPLE_HEALING_POTION = 7;
        public const int ITEM_ID_HEALING_POTION = 8;
        public const int ITEM_ID_BIG_HEALING_POTION = 9;
        public const int ITEM_ID_GREAT_HEALING_POTION = 10;
        public const int ITEM_ID_TROLL_CUDGEL = 11;
        public const int ITEM_ID_TROLL_MEAT = 12;
        public const int ITEM_ID_HEADMAN_PERMISSION_PASS = 13;
        public const int ITEM_ID_BATTERED_PERMIT = 13;
        public const int ITEM_ID_BARK_OF_TRENT = 14;
        public const int ITEM_ID_QUINTESSENCE_OF_PURITY = 15;
        public const int ITEM_ID_GIANT_SNAKE_FANG = 16;
        public const int ITEM_ID_POISON_DAGGER = 17;
        public const int ITEM_ID_HYDRA_RAPIER = 18;
        public const int ITEM_ID_HYDRA_FANG = 19;
        public const int ITEM_ID_POTION_OF_ETERNAL_LIFE = 20;
        public const int ITEM_ID_CROCODILE_TAIL = 21;
        public const int ITEM_ID_SEWAGE_KEY = 22;
        public const int ITEM_ID_ROYAL_SEAL = 23;
        public const int ITEM_ID_ECTOPLASM = 24;
        public const int ITEM_ID_ROYAL_PERMIT = 25;
        
        
        
        public const int MONSTER_ID_SNAKE = 1;
        public const int MONSTER_ID_WOLF = 2;
        public const int MONSTER_ID_BEAR = 3;
        public const int MONSTER_ID_TRENT = 4;
        public const int MONSTER_ID_GIANT_SNAKE = 5;
        public const int MONSTER_ID_HYDRA = 6;
        public const int MONSTER_ID_CROCODILE = 7;
        public const int MONSTER_ID_ROUGE = 8;
        public const int MONSTER_ID_ROUGE_LEADER = 9;
        public const int MONSTER_ID_TROLL = 10;
        public const int MONSTER_ID_GHOST = 11;
        
        
        
        public const int QUEST_ID_BRING_A_SHOVEL = 1;
        public const int QUEST_ID_HELP_WITH_SNAKES = 2;
        public const int QUEST_ID_PURGE_THE_WOLVES = 3;
        public const int QUEST_ID_PURGE_THE_BEARS = 4;
        public const int QUEST_ID_PURGE_THE_DANGER_OF_THE_ANCIENT_FOREST = 5;
        public const int QUEST_ID_SEARCH_FOR_A_BEST_FRIEND = 6;
        public const int QUEST_ID_HELP_SHEPHERD_WITH_SNAKES = 7;
        public const int QUEST_ID_REMOVE_THE_CURSE_FROM_THE_KING = 8;
        
        
        
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_SHEPHERDS_HOUSE = 2;
        public const int LOCATION_ID_SKIFF = 3;
        public const int LOCATION_ID_FORESTERS_HUT = 4;
        public const int LOCATION_ID_VILLAGE = 5;
        public const int LOCATION_ID_FIELD = 6;
        public const int LOCATION_ID_FOREST = 7;
        public const int LOCATION_ID_ANCIENT_FOREST = 8;
        public const int LOCATION_ID_ROAD_TO_THE_CITY = 9;
        public const int LOCATION_ID_SWARM_OF_POISONOUS_SNAKES = 10;
        public const int LOCATION_ID_SCARY_CAVE = 11;
        public const int LOCATION_ID_HYDRAS_LAIR = 12;
        public const int LOCATION_ID_OUTSKIRTS = 13;
        public const int LOCATION_ID_PRISON = 14;
        public const int LOCATION_ID_SEWAGE = 15;
        public const int LOCATION_ID_TROLL_CAVE = 16;
        public const int LOCATION_ID_TOWN_SQUARE = 17;   
        public const int LOCATION_ID_GATE = 18;
        public const int LOCATION_ID_HORDE_OF_ZOMBIES = 19;
        public const int LOCATION_ID_GRAVEYARD_OF_BONES = 20;
        public const int LOCATION_ID_KINGS_PALACE = 21;
        public const int LOCATION_ID_FAMILY_CRYPT = 22;
        public const int LOCATION_ID_MOUND_OF_DEATH = 23;
        public const int LOCATION_ID_SCARY_NECROMANCER_CASTLE = 24;
        
        
        
        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            _items.Add(new Item(ITEM_ID_SNAKE_FANG, "Змеиный клык", "Змеиные клыки", 3));
            _items.Add(new Item(ITEM_ID_GIANT_SNAKE_FANG, "Большой змеиный клык", "Большие змеиные клыки", 15));
            _items.Add(new Item(ITEM_ID_HYDRA_FANG, "Клык гидры", "Клыки гидры", 250));
            _items.Add(new Item(ITEM_ID_WOLF_SKIN, "Волчья шкура", "Волчьи шкуры" , 5));
            _items.Add(new Item(ITEM_ID_BEAR_SKIN, "Медвежья шкура", "Медвежьи шкуры", 10));
            _items.Add(new Item(ITEM_ID_BARK_OF_TRENT, "Кора трента", "Кора трента", 50));
            _items.Add(new Item(ITEM_ID_CROCODILE_TAIL, "Хвост крокодила", "Хвост крокодила", 125));
            _items.Add(new Item(ITEM_ID_TROLL_MEAT, "Мясо тролля", "Мясо тролля", 1000));
            _items.Add(new Item(ITEM_ID_TROLL_MEAT, "Мясо тролля", "Мясо тролля", 1000));
            _items.Add(new Item(ITEM_ID_ROYAL_SEAL, "Печать королевского рода", "Печати королевского рода", 250));
            _items.Add(new Item(ITEM_ID_ECTOPLASM, "Эктоплазма", "Эктоплазма", 25));
            
            _items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Ржавый меч", "Ржавые мечи", 0, 5, 0));
            _items.Add(new Weapon(ITEM_ID_SHOVEL, "Лопата", "Лопаты", 3, 5, 10));
            _items.Add(new Weapon(ITEM_ID_TRENTS_CLUB, "Дубина", "Дубины", 10, 15, 250));
            _items.Add(new Weapon(ITEM_ID_POISON_DAGGER, "Ядовитый кинжал", "Ядовитые кинжалы", 5, 10, 100));
            _items.Add(new Weapon(ITEM_ID_HYDRA_RAPIER, "Рапира из гидры", "Рапиры из гидры", 25, 35, 1000));
            _items.Add(new Weapon(ITEM_ID_TROLL_CUDGEL, "Дубина тролля", "Дубины троллей", 40, 60, 2500));
            
            _items.Add(new HealingPotion(ITEM_ID_SIMPLE_HEALING_POTION, "Малое лечебное зелье", "Малые лечебные зелья", 10, 10));
            _items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Лечебное зелье", "Лечебные зелья", 50, 25));
            _items.Add(new HealingPotion(ITEM_ID_BIG_HEALING_POTION, "Большое лечебное зелье", "Большие лечебные зелья", 200, 100));
            _items.Add(new HealingPotion(ITEM_ID_GREAT_HEALING_POTION, "Великое лечебное зелье", "Великие лечебные зелья", 500, 200));
            _items.Add(new ExperiencePotion(ITEM_ID_POTION_OF_ETERNAL_LIFE, "Зелье вечной жизни", "Зелья вечной жизни", 5000, 500));
            
            _items.Add(new Item(ITEM_ID_QUINTESSENCE_OF_PURITY, "Квинтэссенция чистоты", "Квинтэссенции чистоты", UNSELLABLE_ITEM_PRICE));
            _items.Add(new Item(ITEM_ID_HEADMAN_PERMISSION_PASS, "Разрешение старосты на проход", "Разрешения старосты на проход", UNSELLABLE_ITEM_PRICE));
            _items.Add(new Item(ITEM_ID_BATTERED_PERMIT, "Потрёпанное разрешение", "Потрёпанные разрешения", UNSELLABLE_ITEM_PRICE));
            _items.Add(new Item(ITEM_ID_SEWAGE_KEY, "Грязный ключ", "Грязные ключи", 50));
            _items.Add(new Item(ITEM_ID_ROYAL_PERMIT, "Разрешение короля", "Разрешения корооля", UNSELLABLE_ITEM_PRICE));
        }

        private static void PopulateMonsters()
        {
            var snake = new Monster(MONSTER_ID_SNAKE, "Змея", 3, 2, 0, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, true));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 10, false));
            
            var wolf = new Monster(MONSTER_ID_WOLF, "Волк", 5, 3, 0, 5, 5);
            wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WOLF_SKIN), 75, true));
            wolf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 25, false));

            var bear = new Monster(MONSTER_ID_BEAR, "Медведь", 10, 5, 0, 15, 15);
            bear.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BEAR_SKIN), 75, true));
            bear.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEALING_POTION), 10, false));
            
            var trent = new Monster(MONSTER_ID_TRENT, "Трент", 25, 15, 25, 50, 50);
            trent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BARK_OF_TRENT), 100, true));
            trent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TRENTS_CLUB), 25, false));
            trent.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BIG_HEALING_POTION), 10, false));
            
            var giantSnake = new Monster(MONSTER_ID_GIANT_SNAKE, "Гигантская змея", 15, 10, 0, 25, 25);
            giantSnake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GIANT_SNAKE_FANG), 75, true));
            giantSnake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_POISON_DAGGER), 15, false));
            giantSnake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BATTERED_PERMIT), 5, false));
            
            var hydra = new Monster(MONSTER_ID_HYDRA, "Гидра", 50, 50, 0, 250, 250);
            hydra.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HYDRA_FANG), 75, true));
            hydra.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HYDRA_RAPIER), 15, false));
            
            var crocodile = new Monster(MONSTER_ID_CROCODILE, "Крокодил Гена", 40, 25, 25, 150, 150);
            crocodile.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CROCODILE_TAIL), 75, true));
            crocodile.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BIG_HEALING_POTION), 35, false));
            
            var rouge = new Monster(MONSTER_ID_ROUGE, "Разбойник", 20, 10, 15, 40, 40);
            rouge.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEALING_POTION), 50, false));
            
            var rougeLeader = new Monster(MONSTER_ID_ROUGE_LEADER, "Главарь разбойников", 30, 20, 50, 75, 75);
            rougeLeader.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SEWAGE_KEY), 75, true));
            rougeLeader.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEALING_POTION), 75, false));

            var troll = new Monster(MONSTER_ID_TROLL, "Тролль", 200, 250, 250, 1000, 1000);
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TROLL_MEAT), 75, true));
            troll.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TROLL_CUDGEL), 25, false));
            
            var ghost = new Monster(MONSTER_ID_GHOST, "Призрак", 30, 30, 0, 100, 100);
            ghost.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ECTOPLASM), 75, true));
            ghost.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROYAL_SEAL), 10, false));
            ghost.LootTable.Add(new LootItem(ItemByID(ITEM_ID_QUINTESSENCE_OF_PURITY), 1, false));
            
            _monsters.Add(snake);
            _monsters.Add(wolf);
            _monsters.Add(bear);
            _monsters.Add(trent);
            _monsters.Add(giantSnake);
            _monsters.Add(hydra);
            _monsters.Add(crocodile);
            _monsters.Add(rouge);
            _monsters.Add(rougeLeader);
            _monsters.Add(troll);
            _monsters.Add(ghost);
        }

        private static void PopulateQuests()
        {
            var bringAShovel = new Quest(QUEST_ID_BRING_A_SHOVEL, "Принести пастуху лопату из деревни.",
                " Привет Саша, не знаешь, случаем, куда я лопату с последней гулянки дел? Я вроде бы тебе её давал. Отдай мне её. Если потерял то иди и купи новую мне в деревне.", null, 
                20, 25);
            bringAShovel.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SHOVEL), 1));
            bringAShovel.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 1));
            
            var helpWithSnakes = new Quest(QUEST_ID_HELP_WITH_SNAKES, "Принести пастуху клыки змей.",
                " Саш, спасибо за лопату. Деревня всё никак не присылает стражников для помощи с полем. Мне уже надоело, что каждый раз приходя домой с поля я выдёргиваю по 10 змей из ног, я хоть и с иммунитетом к их яду, но это всё равно надоедает. \n Так что давай, уменьшишь их поголовье и дам тебе за это какую-нибудь причуду из запасов.", bringAShovel, 
                25, 50);
            helpWithSnakes.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 10));
            helpWithSnakes.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 3));
            
            var purgeTheWolves = new Quest(QUEST_ID_PURGE_THE_WOLVES, "Вежливо попросить у волков шкуры.",
                " Здравствуй путник, надеюсь ты не боишься опасностей. Немедленно отправляйся в предлесок и принеси мне шкуры 5 волков. Мне нужно разобраться в том, что их заразило.", null,
                25, 50);
            purgeTheWolves.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_WOLF_SKIN), 5));
            purgeTheWolves.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 3));
            
            var purgeTheBears = new Quest(QUEST_ID_PURGE_THE_BEARS, "Очистить порчу с медведей.",
                " Мне кажется я знаю что это, похоже это порча и она пронизывает всё что стоит на её пути. Срочно займись очисткой порчи с медвейдей. В доказательство принесёшь 5 их шшкур.", purgeTheWolves,
                50, 100);
            purgeTheBears.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_BEAR_SKIN), 5));
            purgeTheBears.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_HEALING_POTION), 3));
            
            var purgeTheDangerOfTheAncientForest = new Quest(QUEST_ID_PURGE_THE_DANGER_OF_THE_ANCIENT_FOREST, "Очистить порчу с древнего леса.",
                " Я понял причину заражения леса. Похоже какая-то магия засеяла порчу в одном из наших древних трентов. Ты должен помочь ему очиститься от скверны. Тебе стоит подготовиться получше, но я верю, что ты справишься.", purgeTheBears,
                100, 250);
            purgeTheDangerOfTheAncientForest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_BARK_OF_TRENT), 1));
            purgeTheDangerOfTheAncientForest.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_BIG_HEALING_POTION), 3));
            purgeTheDangerOfTheAncientForest.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_QUINTESSENCE_OF_PURITY), 1));
            
            var helpShepherdWithSnakes = new Quest(QUEST_ID_HELP_SHEPHERD_WITH_SNAKES, "Помочь пастуху со змеями.",
                " Что ни год, то напасть. Третий год подряд змеи нам докучают, работать в поле нормально не дают. Поди да разберись с причиной. Наверняка это из-за тех больших змей. Принесёшь несколько клыков?", bringAShovel,
                100, 250);
            helpShepherdWithSnakes.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_GIANT_SNAKE_FANG), 5));
            helpShepherdWithSnakes.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_HEALING_POTION), 3));
            helpShepherdWithSnakes.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_HEADMAN_PERMISSION_PASS), 1));
            
            var searchForABestFriend = new Quest(QUEST_ID_SEARCH_FOR_A_BEST_FRIEND, "Найти лучшего друга.",
                " Тссс! Подойди сюда. Не узнаёшь меня? Вырос, забыл уже, ну ладно, я тебя не виню. Найди на окраинах главаря разбойников и забери у него ключ от спуска в канализацию. Потом иди от тюрьмы на юг. Там ты найдёшь моего лучшего друга. Освободи его от оков порчи. Пожалуйста", null,
                100, 250);
            searchForABestFriend.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CROCODILE_TAIL), 1));
            searchForABestFriend.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_POTION_OF_ETERNAL_LIFE), 1));
            
            var removeTheCurseFromTheKing = new Quest(QUEST_ID_REMOVE_THE_CURSE_FROM_THE_KING, "Снять проклятие с короля.",
                " Ну здравствуй, благородный рыцарь. Я сейчас очень занят важным делом. *кашляет* Тебе надо пройти в наш семейный склеп, я сказал, чтобы тебя пустили туда, и принести мне печать нашего королевского рода. *закашливается*. А я уж отблагодарю тебя, чем смогу.", null,
                100, 2500);
            searchForABestFriend.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_ROYAL_SEAL), 1));
            searchForABestFriend.RewardItems.Add(new QuestRewardItem(ItemByID(ITEM_ID_ROYAL_PERMIT), 1));
            
            _quests.Add(bringAShovel);
            _quests.Add(helpWithSnakes);
            _quests.Add(purgeTheWolves);
            _quests.Add(purgeTheBears);
            _quests.Add(purgeTheDangerOfTheAncientForest);
            _quests.Add(helpShepherdWithSnakes);
            _quests.Add(searchForABestFriend);
            _quests.Add(removeTheCurseFromTheKing);
        }

        private static void PopulateLocations()
        {
            // Create each location
            var home = new Location(LOCATION_ID_HOME, "Дом", "Ваш дом. Вы сожалеете, что снова оказались здесь.");

            var shepherdsHouse = new Location(LOCATION_ID_SHEPHERDS_HOUSE, "Лачуга пастуха",
                "Вы видите пастуха. У него беспокойный вид.");
            shepherdsHouse.QuestsAvailableHere.Add(QuestByID(QUEST_ID_BRING_A_SHOVEL));
            shepherdsHouse.QuestsAvailableHere.Add(QuestByID(QUEST_ID_HELP_WITH_SNAKES));

            var skiff = new Location(LOCATION_ID_SKIFF, "Предлесок",
                "Пугающий вой пронизывает вас насквозь. Кровь застывает в жилах. Вы чувствуете, что вы попали в окружение волков.");
            skiff.AddMonster(MONSTER_ID_WOLF, 85);
            skiff.AddMonster(MONSTER_ID_BEAR, 15);

            var forestersHut = new Location(LOCATION_ID_FORESTERS_HUT, "Хата лесника",
                "Вы видите необычного лесника. У вас складывается ощущение, что он сыграет важную роль в вашем приключении.");
            forestersHut.QuestsAvailableHere.Add(QuestByID(QUEST_ID_PURGE_THE_WOLVES));
            forestersHut.QuestsAvailableHere.Add(QuestByID(QUEST_ID_PURGE_THE_BEARS));
            forestersHut.QuestsAvailableHere.Add(QuestByID(QUEST_ID_PURGE_THE_DANGER_OF_THE_ANCIENT_FOREST));

            var village = new Location(LOCATION_ID_VILLAGE, "Деревня",
                "Вы приходите в деревню. Лица жители максимально отстранены. Кажется вам есть чем тут заняться.");
            village.QuestsAvailableHere.Add(QuestByID(QUEST_ID_HELP_SHEPHERD_WITH_SNAKES));

            var field = new Location(LOCATION_ID_FIELD, "Поле",
                "Вы пришли на заросшее поле, похоже этот год тоже будет голодным...");

            var forest = new Location(LOCATION_ID_FOREST, "Лес",
                "По мере вашего приближения количество окружающих Вас ягод и пчелиных ульев увеличивалось. Вы уже поняли кого вы здесь встретите.");
            forest.AddMonster(MONSTER_ID_WOLF, 10);
            forest.AddMonster(MONSTER_ID_BEAR, 85);
            forest.AddMonster(MONSTER_ID_TRENT, 5);
            
            var ancientForest = new Location(LOCATION_ID_ANCIENT_FOREST, "Древний лес",
                "Вы входите в глубокий лес, деревья здесь совершенно необычайной формы. Похоже, что именно здесь и началось заражение леса. Пора остановить порчу.");
            ancientForest.AddMonster(MONSTER_ID_WOLF, 5);
            ancientForest.AddMonster(MONSTER_ID_BEAR, 10);
            ancientForest.AddMonster(MONSTER_ID_TRENT, 85);

            var roadToTheCity = new Location(LOCATION_ID_ROAD_TO_THE_CITY, "Дорога в город",
                "Сельские стражники согласны пускать селян в город только по письменному заверению старосты.");


            var swarmOfPoisonousSnakes = new Location(LOCATION_ID_SWARM_OF_POISONOUS_SNAKES,
                "Рой ядовитых змей", "Шипение множествав змей застилает ужасом ваш разум.");
            swarmOfPoisonousSnakes.AddMonster(MONSTER_ID_SNAKE, 95);
            swarmOfPoisonousSnakes.AddMonster(MONSTER_ID_GIANT_SNAKE, 5);
            
            var scaryCave = new Location(LOCATION_ID_SCARY_CAVE, "Страшная пещера",
                "Вы чувствуете, что что-то смотрит на Вас.\"Движение - смерть\" - слышите Вы в своей голове");
            scaryCave.AddMonster(MONSTER_ID_SNAKE, 30);
            scaryCave.AddMonster(MONSTER_ID_GIANT_SNAKE, 70);
            
            var hydrasLair = new Location(LOCATION_ID_HYDRAS_LAIR, "Логово гидры",
                "Отсюда можно выйти либо победителем, либо фаршем.");
            hydrasLair.AddMonster(MONSTER_ID_HYDRA, 90);
            hydrasLair.AddMonster(MONSTER_ID_GIANT_SNAKE, 10);
            
            var outskirts = new Location(LOCATION_ID_OUTSKIRTS, "Окраины города",
                "Бедное население бродит вдоль улочек. Незнакомцы поздываю к себе.", ItemByID(ITEM_ID_HEADMAN_PERMISSION_PASS));
            outskirts.AddMonster(MONSTER_ID_ROUGE, 75);
            outskirts.AddMonster(MONSTER_ID_ROUGE_LEADER, 25);

            var prison = new Location(LOCATION_ID_PRISON, "Тюрьма",
                "Вы проходите в тюрьму. Здесь стоит всего несколько стражников на бесконечные залы клеток с заключёнными. Похоже здесь действительно безопасно гулять.");
            prison.QuestsAvailableHere.Add(QuestByID(QUEST_ID_SEARCH_FOR_A_BEST_FRIEND));
            
            var sewage = new Location(LOCATION_ID_SEWAGE, "Канализационные стоки", "Миф Голливуда стоит перед вами.", ItemByID(ITEM_ID_SEWAGE_KEY));
            sewage.AddMonster(MONSTER_ID_CROCODILE, 100);

            var trollCave = new Location(LOCATION_ID_TROLL_CAVE, "Пещера троллей",
                "Куча разбросанных ботинок привела вас в пещеру трёх троллей. Их зовут ОГГ, ПОГГ И РОГГ.");
            trollCave.AddMonster(MONSTER_ID_TROLL, 100);

            var townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Городская площадь",
                "На площади достаточно людно. Сложно представить почему центр настолько разительно отличается от закоулок, в которых Вы недавно были.");
            
            var gate = new Location(LOCATION_ID_GATE, "Ворота",
                "Похоже здесь стоит почти вся стража города. Стражники отчётливо дают вам понять, что для того чтобы пройти дальше, вам нужно личное разрешение Короля Давида Сказачного.");

            var hordeOfZombies = new Location(LOCATION_ID_HORDE_OF_ZOMBIES, "Орда зомби",
                "Похоже, что всё былое население мира предстало здесь перед вами в виде оживших мертвецов, пройти куда-то дальше получится только смекалкой.");

            var graveyardOfBones = new Location(LOCATION_ID_GRAVEYARD_OF_BONES, "Кладбище костей",
                "Вам в детстве говорили, что живых драконов не бывает. Это оказалось правдой лишь отчасти. Находящийся здесь дракон жив, хотя и состоит лишь из костей.");

            var kingsPalace = new Location(LOCATION_ID_KINGS_PALACE, "Дворец короля",
                "Двроец Давида Сказачного. Он с гордостью смотрит на Вас, рыцаря света, пришедшего спасать его Королевство. Хорошо что он не знает, что ещё вчера вам приходилось копать ямы для постройки нового туалета в деревне.");
            kingsPalace.QuestsAvailableHere.Add(QuestByID(QUEST_ID_REMOVE_THE_CURSE_FROM_THE_KING));
            
            var familyCrypt = new Location(LOCATION_ID_FAMILY_CRYPT, "Семейный склеп",
                "Семейный склеп Давида Сказачного. Пора успокоить взбунтовавшихся призраков.");
            familyCrypt.AddMonster(MONSTER_ID_GHOST, 100);

            var moundOfDeath = new Location(LOCATION_ID_MOUND_OF_DEATH, "Курган смерти",
                "Пора остановить производство зомби. Проблему с существующими это хоть и не решит, но новым лучше всё-таки не появляться.", ItemByID(ITEM_ID_QUINTESSENCE_OF_PURITY));

            var scaryNecromancerCastle = new Location(LOCATION_ID_SCARY_NECROMANCER_CASTLE, "Замок страшного некроманта",
                "Все Ваши десткие и студенческие страхи воплотились перед Вами. \n ПОБЕДА ИЛИ СМЕРТЬ! \n ЛОК'ТАР ОГАР, ДРУГ!");
            

            // Vendors, working in locations
            var bigBob = new Vendor("Большой Боб");
            bigBob.AddItemToInventory(ItemByID(ITEM_ID_SHOVEL), 5);
            bigBob.AddItemToInventory(ItemByID(ITEM_ID_SIMPLE_HEALING_POTION), 50);
            bigBob.AddItemToInventory(ItemByID(ITEM_ID_HEALING_POTION), 10);
            village.VendorWorkingHere = bigBob;
            
            
            
            
            // Link the locations together
            home.LocationToSouth = shepherdsHouse;
            home.LocationToEast = village;
            
            shepherdsHouse.LocationToNorth = home;
            shepherdsHouse.LocationToEast = field;
            shepherdsHouse.LocationToSouth = skiff;
            
            skiff.LocationToNorth = shepherdsHouse;
            skiff.LocationToEast = forest;
            skiff.LocationToSouth = forestersHut;

            forestersHut.LocationToNorth = skiff;

            village.LocationToWest = home;
            village.LocationToEast = roadToTheCity;
            village.LocationToSouth = field;

            field.LocationToNorth = village;
            field.LocationToEast = swarmOfPoisonousSnakes;
            field.LocationToSouth = forest;
            field.LocationToWest = shepherdsHouse;

            forest.LocationToNorth = field;
            forest.LocationToSouth = ancientForest;
            forest.LocationToWest = skiff;
            
            ancientForest.LocationToNorth = forest;
            
            roadToTheCity.LocationToEast = outskirts;
            roadToTheCity.LocationToWest = village;

            swarmOfPoisonousSnakes.LocationToSouth = scaryCave;
            swarmOfPoisonousSnakes.LocationToWest = field;

            scaryCave.LocationToNorth = swarmOfPoisonousSnakes;
            scaryCave.LocationToSouth = hydrasLair;
            
            hydrasLair.LocationToNorth = scaryCave;

            outskirts.LocationToEast = townSquare;
            outskirts.LocationToSouth = prison;
            outskirts.LocationToEast = roadToTheCity;

            prison.LocationToNorth = outskirts;
            prison.LocationToSouth = sewage;

            sewage.LocationToNorth = prison;

            trollCave.LocationToEast = graveyardOfBones;
            
            townSquare.LocationToEast = kingsPalace;
            townSquare.LocationToSouth = gate;
            townSquare.LocationToWest = outskirts;

            gate.LocationToNorth = townSquare;
            gate.LocationToSouth = hordeOfZombies;

            hordeOfZombies.LocationToNorth = gate;
            hordeOfZombies.LocationToEast = moundOfDeath;
            hordeOfZombies.LocationToSouth = graveyardOfBones;

            graveyardOfBones.LocationToNorth = hordeOfZombies;
            graveyardOfBones.LocationToEast = scaryNecromancerCastle;
            graveyardOfBones.LocationToWest = trollCave;

            kingsPalace.LocationToSouth = familyCrypt;
            kingsPalace.LocationToWest = townSquare;

            familyCrypt.LocationToNorth = kingsPalace;

            moundOfDeath.LocationToWest = hordeOfZombies;

            scaryNecromancerCastle.LocationToWest = graveyardOfBones;
            
            // Add the locations to the static list
            _locations.Add(home);
            _locations.Add(shepherdsHouse);
            _locations.Add(skiff);
            _locations.Add(forestersHut);
            _locations.Add(village);
            _locations.Add(field);
            _locations.Add(forest);
            _locations.Add(ancientForest);
            _locations.Add(roadToTheCity);
            _locations.Add(swarmOfPoisonousSnakes);
            _locations.Add(scaryCave);
            _locations.Add(hydrasLair);
            _locations.Add(outskirts);
            _locations.Add(prison);
            _locations.Add(sewage);
            _locations.Add(trollCave);
            _locations.Add(townSquare);
            _locations.Add(gate);
            _locations.Add(hordeOfZombies);
            _locations.Add(graveyardOfBones);
            _locations.Add(kingsPalace);
            _locations.Add(familyCrypt);
            _locations.Add(moundOfDeath);
            _locations.Add(scaryNecromancerCastle);
        }

        public static Item ItemByID(int id)
        {
            foreach (var item in _items)
                if (item.ID == id)
                    return item;
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (var monster in _monsters)
                if (monster.ID == id)
                    return monster;
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (var quest in _quests)
                if (quest.ID == id)
                    return quest;
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (var location in _locations)
                if (location.ID == id)
                    return location;
            return null;
        }
    }
}