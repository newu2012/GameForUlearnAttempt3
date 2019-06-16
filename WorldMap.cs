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
            
            // TODO Rework Map Images Initializing 
            /*var pic = new PictureBox[4,6];
            for (var i = 0; i < 4; i++)
            for (var j = 0; j < 6; j++)
            {
                pic[i,j] = new PictureBox();
                pictureBox1.Location = new Point(1 + i*75, 1 + j*75);
                pictureBox1.Name = "pic" + "[" + i + "," + j + "]";
                pictureBox1.Size = new Size(75, 75);
                pictureBox1.TabStop = false;
                Controls.Add(pic[i,j]);
            }
            */
            SetImage(pic_0_0, player.LocationsVisited.Contains(1) ? "Home" : "FogLocation");
            SetImage(pic_1_0, player.LocationsVisited.Contains(2) ? "ShepherdsHouse" : "FogLocation");
            SetImage(pic_2_0, player.LocationsVisited.Contains(3) ? "Skiff" : "FogLocation");
            SetImage(pic_3_0, player.LocationsVisited.Contains(4) ? "ForestersHut" : "FogLocation");
            SetImage(pic_0_1, player.LocationsVisited.Contains(5) ? "Village" : "FogLocation");
            SetImage(pic_1_1, player.LocationsVisited.Contains(6) ? "Field" : "FogLocation");
            SetImage(pic_2_1, player.LocationsVisited.Contains(7) ? "Forest" : "FogLocation");
            SetImage(pic_3_1, player.LocationsVisited.Contains(8) ? "AncientForest" : "FogLocation");
            SetImage(pic_0_2, player.LocationsVisited.Contains(9) ? "Road" : "FogLocation");
            SetImage(pic_1_2, player.LocationsVisited.Contains(10) ? "Snakes" : "FogLocation");
            SetImage(pic_2_2, player.LocationsVisited.Contains(11) ? "GiantSnake" : "FogLocation");
            SetImage(pic_3_2, player.LocationsVisited.Contains(12) ? "Hydra" : "FogLocation");
            SetImage(pic_0_3, player.LocationsVisited.Contains(13) ? "Outskirts" : "FogLocation");
            SetImage(pic_1_3, player.LocationsVisited.Contains(14) ? "Prison" : "FogLocation");
            SetImage(pic_2_3, player.LocationsVisited.Contains(15) ? "Sewage" : "FogLocation");
            SetImage(pic_3_3, player.LocationsVisited.Contains(16) ? "TrollCave" : "FogLocation");
            SetImage(pic_0_4, player.LocationsVisited.Contains(17) ? "TownSquare" : "FogLocation");
            SetImage(pic_1_4, player.LocationsVisited.Contains(18) ? "Gate" : "FogLocation");
            SetImage(pic_2_4, player.LocationsVisited.Contains(19) ? "Zombie" : "FogLocation");
            SetImage(pic_3_4, player.LocationsVisited.Contains(20) ? "GraveyardOfBones" : "FogLocation");
            SetImage(pic_0_5, player.LocationsVisited.Contains(21) ? "KingsPalace" : "FogLocation");
            SetImage(pic_1_5, player.LocationsVisited.Contains(22) ? "FamilyCrypt" : "FogLocation");
            SetImage(pic_2_5, player.LocationsVisited.Contains(23) ? "MoundOfDeath" : "FogLocation");
            SetImage(pic_3_5, player.LocationsVisited.Contains(24) ? "NecromancerTower" : "FogLocation");
            /*
             SetImage(pic_0_2, player.LocationsVisited.Contains(5) ? "HerbalistsGarden" : "FogLocation");
            SetImage(pic_1_2, player.LocationsVisited.Contains(4) ? "HerbalistsHut" : "FogLocation");
            SetImage(pic_2_0, player.LocationsVisited.Contains(7) ? "FarmFields" : "FogLocation");
            SetImage(pic_2_1, player.LocationsVisited.Contains(6) ? "Farmhouse" : "FogLocation");
            SetImage(pic_2_2, player.LocationsVisited.Contains(2) ? "TownSquare" : "FogLocation");
            SetImage(pic_2_3, player.LocationsVisited.Contains(3) ? "TownGate" : "FogLocation");
            SetImage(pic_2_4, player.LocationsVisited.Contains(8) ? "Bridge" : "FogLocation");
            SetImage(pic_2_5, player.LocationsVisited.Contains(9) ? "SpiderForest" : "FogLocation");
            SetImage(pic_3_2, player.LocationsVisited.Contains(1) ? "Home" : "FogLocation");
            */
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
    }
}