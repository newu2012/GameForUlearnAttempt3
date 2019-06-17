using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Engine;

namespace GameForUlearnAttempt3
{
    public partial class WorldMap : Form
    {
        readonly Assembly _thisAssembly = Assembly.GetExecutingAssembly();

        public WorldMap(Player player)
        {
            InitializeComponent();
            SetAllImages(player);
        }

        private void SetImage(PictureBox pictureBox, string imageName)
        {
            using (var resourceStream = 
                _thisAssembly.GetManifestResourceStream(
                    _thisAssembly.GetName().Name + ".MapImages." + imageName + ".png"))
            {
                if (resourceStream != null)
                    pictureBox.Image = new Bitmap(resourceStream);
            }
        }

        public void SetAllImages(Player player)
        {
            SetImage(pic_0_0,
                player.CurrentLocation.Name == "Дом" ? "Player" :
                player.LocationsVisited.Contains(1) ? "Home" : "FogLocation");
            SetImage(pic_1_0,
                player.CurrentLocation.Name == "Лачуга пастуха" ? "Player" :
                player.LocationsVisited.Contains(2) ? "ShepherdsHouse" : "FogLocation");
            SetImage(pic_2_0,
                player.CurrentLocation.Name == "Предлесок" ? "Player" :
                player.LocationsVisited.Contains(3) ? "Skiff" : "FogLocation");
            SetImage(pic_3_0,
                player.CurrentLocation.Name == "Хата лесника" ? "Player" :
                player.LocationsVisited.Contains(4) ? "ForestersHut" : "FogLocation");
            SetImage(pic_0_1,
                player.CurrentLocation.Name == "Деревня" ? "Player" :
                player.LocationsVisited.Contains(5) ? "Village" : "FogLocation");
            SetImage(pic_1_1,
                player.CurrentLocation.Name == "Поле" ? "Player" :
                player.LocationsVisited.Contains(6) ? "Field" : "FogLocation");
            SetImage(pic_2_1,
                player.CurrentLocation.Name == "Лес" ? "Player" :
                player.LocationsVisited.Contains(7) ? "Forest" : "FogLocation");
            SetImage(pic_3_1,
                player.CurrentLocation.Name == "Древний лес" ? "Player" :
                player.LocationsVisited.Contains(8) ? "AncientForest" : "FogLocation");
            SetImage(pic_0_2,
                player.CurrentLocation.Name == "Дорога в город" ? "Player" :
                player.LocationsVisited.Contains(9) ? "Road" : "FogLocation");
            SetImage(pic_1_2,
                player.CurrentLocation.Name == "Рой ядовитых змей" ? "Player" :
                player.LocationsVisited.Contains(10) ? "Snakes" : "FogLocation");
            SetImage(pic_2_2,
                player.CurrentLocation.Name == "Страшная пещера" ? "Player" :
                player.LocationsVisited.Contains(11) ? "GiantSnake" : "FogLocation");
            SetImage(pic_3_2,
                player.CurrentLocation.Name == "Логово гидры" ? "Player" :
                player.LocationsVisited.Contains(12) ? "Hydra" : "FogLocation");
            SetImage(pic_0_3,
                player.CurrentLocation.Name == "Окраины города" ? "Player" :
                player.LocationsVisited.Contains(13) ? "Outskirts" : "FogLocation");
            SetImage(pic_1_3,
                player.CurrentLocation.Name == "Тюрьма" ? "Player" :
                player.LocationsVisited.Contains(14) ? "Prison" : "FogLocation");
            SetImage(pic_2_3,
                player.CurrentLocation.Name == "Канализационные стоки" ? "Player" :
                player.LocationsVisited.Contains(15) ? "Sewage" : "FogLocation");
            SetImage(pic_3_3,
                player.CurrentLocation.Name == "Пещера троллей" ? "Player" :
                player.LocationsVisited.Contains(16) ? "TrollCave" : "FogLocation");
            SetImage(pic_0_4,
                player.CurrentLocation.Name == "Городская площадь" ? "Player" :
                player.LocationsVisited.Contains(17) ? "TownSquare" : "FogLocation");
            SetImage(pic_1_4,
                player.CurrentLocation.Name == "Ворота" ? "Player" :
                player.LocationsVisited.Contains(18) ? "Gate" : "FogLocation");
            SetImage(pic_2_4,
                player.CurrentLocation.Name == "Орда зомби" ? "Player" :
                player.LocationsVisited.Contains(19) ? "Zombie" : "FogLocation");
            SetImage(pic_3_4,
                player.CurrentLocation.Name == "Кладбище костей" ? "Player" :
                player.LocationsVisited.Contains(20) ? "GraveyardOfBones" : "FogLocation");
            SetImage(pic_0_5,
                player.CurrentLocation.Name == "Дворец короля" ? "Player" :
                player.LocationsVisited.Contains(21) ? "KingsPalace" : "FogLocation");
            SetImage(pic_1_5,
                player.CurrentLocation.Name == "Семейный склеп" ? "Player" :
                player.LocationsVisited.Contains(22) ? "FamilyCrypt" : "FogLocation");
            SetImage(pic_2_5,
                player.CurrentLocation.Name == "Курган смерти" ? "Player" :
                player.LocationsVisited.Contains(23) ? "MoundOfDeath" : "FogLocation");
            SetImage(pic_3_5,
                player.CurrentLocation.Name == "Замок страшного некроманта" ? "Player" :
                player.LocationsVisited.Contains(24) ? "NecromancerTower" : "FogLocation");
        }
    }
}