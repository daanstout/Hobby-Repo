using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAncestor.Ancestors {
    public class Tree {
        private static Random rand = new Random();

        int initialPopulationSize;
        List<Person[]> generations = new List<Person[]>();

        public Tree(int generationSize) {
            initialPopulationSize = generationSize;
            generations.Add(new Person[generationSize]);
            for (int i = 0; i < generationSize; i++)
                generations[0][i] = new Person();
        }

        public void Draw(Graphics g, int distanceBetweenPersons) {
            int curY = 10;
            int curX = 10;
            int sphereRadius = 10;
            for(int gen = 0; gen < generations.Count; gen++){
                for (int i = 0; i < generations[gen].Length; i++) {
                    g.FillEllipse(Brushes.White, new Rectangle(curX - sphereRadius, curY - sphereRadius, sphereRadius * 2, sphereRadius * 2));

                    if (gen == 0) {
                        curX += distanceBetweenPersons;
                        continue;
                    }

                    int father = generations[gen][i].father;
                    int mother = generations[gen][i].mother;

                    if (father == -1 || mother == -1) {
                        curX += distanceBetweenPersons;
                        continue;
                    }

                    Point start, end;

                    start = new Point(curX, curY);
                    end = new Point(father * distanceBetweenPersons + 10, start.Y - distanceBetweenPersons);

                    g.DrawLine(new Pen(Brushes.Green), start, end);

                    end = new Point(mother * distanceBetweenPersons + 10, end.Y);

                    g.DrawLine(new Pen(Brushes.Green), start, end);

                    curX += distanceBetweenPersons;
                }
                curY += distanceBetweenPersons;
                curX = 10;
            }
        }

        public void AddGeneration() => AddGeneration(initialPopulationSize);

        public void AddGeneration(int newPopulationSize) {
            Person[] newGen = new Person[newPopulationSize];

            for(int i = 0; i < newPopulationSize; i++) {
                newGen[i].father = rand.Next(0, generations.Last().Length);
                newGen[i].mother = rand.Next(0, generations.Last().Length);
            }

            generations.Add(newGen);
        }
    }
}
