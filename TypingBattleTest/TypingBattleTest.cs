using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypingBattle;

namespace TypingBattleTest
{
    [TestClass]
    public class TypingBattleTest
    {
        [TestMethod]
        public void EnemyHpTest()
        {
            int enemyCount = 10;
            System.Collections.Generic.IEnumerable<Enemy>? enemies = Enemy.Enemies(enemyCount);
            int expected = 10;
            foreach (Enemy? enemy in enemies)
            {
                int actual = enemy.HP;
                expected += 10;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}