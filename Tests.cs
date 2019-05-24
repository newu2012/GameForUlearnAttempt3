
using Engine;
using NUnit.Framework;

namespace GameForUlearnAttempt3.Tests
{
    [TestFixture]
    public class PLayerTests
    {
        private Player player;
        
        [SetUp]
        public void Setup()
        {
            player = Player.CreateDefaultPlayer();
        }
        
        [Test]
        public void ShouldHeal_WhenUsePotion()
        {
            
            // Arrange
            var healingPotion = CreatePotion(10);
            
            // Act
            player.UsePotion(healingPotion);
            
            // Assert
            Assert.AreEqual(10, player.CurrentHitPoints);
        }

        private HealingPotion CreatePotion(int amountToHeal)
        {
            return new HealingPotion(1, "", "", amountToHeal, 0);
        }
        
    }
}