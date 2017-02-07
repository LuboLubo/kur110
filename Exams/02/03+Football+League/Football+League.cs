namespace _03_Football_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> LeageDic = new Dictionary<string, int>();
            Dictionary<string, long> ScoreDic = new Dictionary<string, long>();
            string key = Console.ReadLine();
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "final" || input == "FINAL")
                {
                    break;
                }
                string[] inputSplit = input.Split();

                int index = inputSplit[0].IndexOf(key);
                int secondIndex = inputSplit[0].LastIndexOf(key);
                string FirstTeam = inputSplit[0].Substring(index + key.Length, secondIndex - (index + key.Length));

                int indexSecond = inputSplit[1].IndexOf(key);
                int secondIndexSecond = inputSplit[1].LastIndexOf(key);
                string lastTeam = inputSplit[1].Substring(indexSecond + key.Length, secondIndexSecond - (indexSecond + key.Length));

                FirstTeam = String.Concat(FirstTeam.Reverse()).ToUpper();
                lastTeam = String.Concat(lastTeam.Reverse()).ToUpper();

                string[] splitInputSplit2 = inputSplit[2].Split(':');
         
                string strFirstNum = splitInputSplit2[0];
                string strSecondNum = splitInputSplit2[1];

                int firstNum = int.Parse(strFirstNum);
                int secondNum = int.Parse(strSecondNum);

                if (firstNum > secondNum)
                {
                    InsertResultFirstTeam(LeageDic, FirstTeam, lastTeam);
                }
                else if (secondNum > firstNum)
                {
                    InsertResultSecondTeam(LeageDic, FirstTeam, lastTeam);

                }
                else if (firstNum == secondNum)
                {
                    InsertResultFirstAndSecondTeam(LeageDic, FirstTeam, lastTeam);
                }

                InsertResultTeamScores(ScoreDic, FirstTeam, lastTeam, firstNum, secondNum);

                input = Console.ReadLine();
            }
            Console.WriteLine("League standings:");
            int count = 1;
            foreach (var item in LeageDic.OrderBy(k => k.Key).OrderByDescending(v => v.Value))
            {
                Console.WriteLine($"{count}. {item.Key} {item.Value}");
                count++;
            }
            Console.WriteLine("Top 3 scored goals:");

            foreach (var item in ScoreDic.OrderBy(k => k.Key).OrderByDescending(v => v.Value).Take(3))
            {
                Console.WriteLine($"- {item.Key} -> {item.Value}");
            }
        }

        private static void InsertResultTeamScores(Dictionary<string, long> ScoreDic, string FirstTeam, string lastTeam, int firstNum, int secondNum)
        {
            if (!ScoreDic.ContainsKey(FirstTeam))
            {
                ScoreDic.Add(FirstTeam, 0);
                ScoreDic[FirstTeam] = firstNum;
            }
            else
            {
                ScoreDic[FirstTeam] += firstNum;
            }
            if (!ScoreDic.ContainsKey(lastTeam))
            {
                ScoreDic.Add(lastTeam, 0);
                ScoreDic[lastTeam] = secondNum;
            }
            else
            {
                ScoreDic[lastTeam] += secondNum;
            }
        }

        private static void InsertResultFirstAndSecondTeam(Dictionary<string, int> LeageDic, string FirstTeam, string lastTeam)
        {
            if (!LeageDic.ContainsKey(lastTeam))
            {
                LeageDic.Add(lastTeam, 0);
                LeageDic[lastTeam] = 1;
            }
            else
            {
                LeageDic[lastTeam] += 1;
            }
            if (!LeageDic.ContainsKey(FirstTeam))
            {
                LeageDic.Add(FirstTeam, 0);
                LeageDic[FirstTeam] = 1;
            }
            else
            {
                LeageDic[FirstTeam] += 1;
            }
        }

        private static void InsertResultSecondTeam(Dictionary<string, int> LeageDic, string FirstTeam, string lastTeam)
        {
            if (!LeageDic.ContainsKey(lastTeam))
            {
                LeageDic.Add(lastTeam, 0);
                LeageDic[lastTeam] = 3;
            }
            else
            {
                LeageDic[lastTeam] += 3;
            }
            if (!LeageDic.ContainsKey(FirstTeam))
            {
                LeageDic.Add(FirstTeam, 0);
                LeageDic[FirstTeam] = 0;
            }
            else
            {
                LeageDic[FirstTeam] += 0;
            }
        }

        private static void InsertResultFirstTeam(Dictionary<string, int> LeageDic, string FirstTeam, string lastTeam)
        {
            if (!LeageDic.ContainsKey(FirstTeam))
            {
                LeageDic.Add(FirstTeam, 0);
                LeageDic[FirstTeam] = 3;
            }
            else
            {
                LeageDic[FirstTeam] += 3;
            }
            if (!LeageDic.ContainsKey(lastTeam))
            {
                LeageDic.Add(lastTeam, 0);
                LeageDic[lastTeam] = 0;
            }
            else
            {
                LeageDic[lastTeam] += 0;
            }
        }
    }
}
