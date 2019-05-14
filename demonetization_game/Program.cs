using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demonetization_game
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] ytNames1 = File.ReadAllLines(@"ytNames.txt");

            List<string> nameList = new List<string>(File.ReadAllLines(@"ytNames.txt"));
            List<person> randomNames = new List<person>();
            List<int> eggs = new List<int>();

            Random r = new Random();

            int randomIndex = 0;
            int counter = 1;
            person chosen;
            person lastChosen = null;
            Boolean won = false;

            while (eggs.Count < 100)
            {
                randomIndex = r.Next(1, 101);
                if (!eggs.Contains(randomIndex))
                {

                    eggs.Add(randomIndex);
                }
            }

            /*foreach (int i in eggs)
            {
                Console.WriteLine(i);
            }*/

            while (nameList.Count > 0)
            {
                person person = new person();
                randomIndex = r.Next(0, nameList.Count);

                person.Name = nameList[randomIndex];
                person.position = counter;
                person.egg = eggs[randomIndex];

                randomNames.Add(person);

                nameList.RemoveAt(randomIndex);
                eggs.RemoveAt(randomIndex);

                counter++;
            }

            foreach (person p in randomNames)
            {
                Console.WriteLine(p.Name + " " + p.position + " choosing");

                lastChosen = p;

                for (int x = 1; x <= 50; x++)
                {
                    Console.Write(x + " choice: ");

                    chosen = chooseByPosition(lastChosen.position, randomNames);

                    lastChosen = chosen;

                    Console.WriteLine("Name:" + chosen.Name + " Position:" + chosen.position + " Egg:" + chosen.egg);

                    if (chosen.Name == p.Name)
                    {
                        Console.WriteLine("YOU GOT YOUR NAME");
                        won = true;
                        Console.ReadKey();
                        break;
                    }
                }

                if (!won)
                {
                    Console.WriteLine("You lost it for everyone");
                    break;
                }
                won = false;
            }


            /*foreach (var i in randomNames)
            {
                Console.WriteLine(i.Name + " " + i.position + " " + i.egg);
            }*/



            Console.ReadKey();
        }

        static person chooseByPosition(int choosersPos, List<person> randomNames)
        {
            return randomNames.Find(x => x.egg.Equals(choosersPos));
        }

        static void goodChoices()
        {

        }
    }
}
