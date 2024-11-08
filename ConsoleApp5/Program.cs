using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Oceanarium<T> : IEnumerable<T> where T : MarineCreature
    {
        private T[] creatures;
        private int count = 0;

        public Oceanarium(int c)
        {
            creatures = new T[c];
        }

        public void AddCreature(T creature)
        {
            if(count < creatures.Length)
            {
                creatures[count] = creature;
                count++;
            }
            else
            {
                Console.WriteLine("Cannot add another creature");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return creatures[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public abstract class MarineCreature
    {
        public string Name { get; set; }

    }

    public class Shark : MarineCreature {
        public Shark() {

            Name = "Shark";
        }
    }

    public class Jellyfish : MarineCreature
    {
        public Jellyfish()
        {

            Name = "Jellyfish";
        }
    }

    public class Dolphin : MarineCreature
    {
        public Dolphin()
        {

            Name = "Dolphin";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Oceanarium<MarineCreature> oceanarium = new Oceanarium<MarineCreature>(5);
            oceanarium.AddCreature(new Shark());
            oceanarium.AddCreature(new Dolphin());

            foreach (var creature in oceanarium)
            {
                Console.WriteLine($"Name: {creature.Name}");
            }
        }
    }
}
