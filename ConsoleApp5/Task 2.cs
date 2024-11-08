using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class FootballTeam<T> : IEnumerable<T> where T : TeamPlayer
    {
        private T[] team;
        private int count = 0;

        public FootballTeam(int c)
        {
            team = new T[c];
        }
        public FootballTeam()
        {
            team = new T[10];
        }

        public void AddPlayer(T player)
        {
            if (count < team.Length)
            {
                team[count] = player;
                count++;
            }
            else
            {
                Console.WriteLine("Cannot add another teamplayer");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return team[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TeamPlayer
    {
        public string Name {  get; set; }
        public int Age { get; set; }
    }


    public class Program2
    {
        public static void Main(string[] args)
        {
            FootballTeam< TeamPlayer> team = new FootballTeam<TeamPlayer>(5);
            team.AddPlayer(new TeamPlayer {Name = "Oleg", Age = 21 });
            team.AddPlayer(new TeamPlayer {Name = "Danya", Age = 22 });
            team.AddPlayer(new TeamPlayer {Name = "Alex", Age = 24 });

            foreach (var player in team)
            {
                Console.WriteLine($"Name: {player.Name}, Age: {player.Age}");
            }
        }
    }
}
