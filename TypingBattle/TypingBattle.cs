namespace TypingBattle;

public class TypingBattle
{
    [STAThread]
    private static void Main(string[] args)
    {
        Console.WriteLine("TypingBattle");
        string? command = Console.ReadLine();
        if (command == "start")
        {
            Console.WriteLine("敵の数を入力してください");
            int enemyCount = int.TryParse(Console.ReadLine(), out int s) ? s : 1;
            IEnumerable<Enemy>? enemies = Enemy.Enemies(enemyCount);
            foreach (Enemy? enemy in enemies)
            {
                Console.WriteLine(enemy.Name);
                Console.WriteLine(enemy.HP);
                while (enemy.HP > 0)
                {
                    string? action = Console.ReadLine();
                    switch (action)
                    {
                        case "punch":
                            enemy.HP -= Actions.Damege[Actions.ActionEnum.punch];
                            break;
                        case "kick":
                            enemy.HP -= Actions.Damege[Actions.ActionEnum.kick];
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(enemy.HP);
                }
                Console.WriteLine("倒した！");
            }
            Console.WriteLine("全ての敵を倒した！");
        }
    }
}

public class Actions
{
    public enum ActionEnum
    {
        punch,
        kick,
        rolling,
        jump
    }

    public static Dictionary<ActionEnum, int> Damege = new Dictionary<ActionEnum, int>()
    {
        [ActionEnum.punch] = 10,
        [ActionEnum.kick] = 20,
        [ActionEnum.rolling] = 0,
        [ActionEnum.jump] = 0,
    };
}

public class Enemy
{
    public string Name { get; set; } = null!;
    public int HP { get; set; }

    public static IEnumerable<Enemy> Enemies(int count)
    {
        int hp = 10;

        for (int i = 0; i < count; i++)
        {
            yield return new Enemy
            {
                Name = MakeRandomName(),
                HP = hp += 10
            };
        }
    }

    public static string MakeRandomName()
    {
        string? characters = "abcdefg";
        char[]? charsarr = new char[8];
        Random? random = new Random();
        for (int i = 0; i < charsarr.Length; i++)
        {
            charsarr[i] = characters[random.Next(characters.Length)];
        }

        string? resultString = new string(charsarr);
        return resultString;
    }
}


