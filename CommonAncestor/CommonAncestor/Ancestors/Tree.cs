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

        Point selectedPerson = new Point(-1, -1);

        public Tree(int generationSize) {
            initialPopulationSize = generationSize;
            generations.Add(new Person[generationSize]);
            for (int i = 0; i < generationSize; i++) {
                generations[0][i] = new Person(initialPopulationSize);
                generations[0][i].SetDescendant(i, true);
            }
        }

        public void Draw(Graphics g, int distanceBetweenPersons, int startY) {
            int curY = startY - 10;
            int curX = 10;
            int sphereRadius = 10;
            for (int gen = 0; gen < generations.Count; gen++) {
                for (int i = 0; i < generations[gen].Length; i++) {
                    g.FillEllipse(Brushes.White, new Rectangle(curX - sphereRadius, curY - sphereRadius, sphereRadius * 2, sphereRadius * 2));

                    if (gen == generations.Count - 1) {
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
                curY -= distanceBetweenPersons;
                curX = 10;
            }

            if (selectedPerson.X != -1 || selectedPerson.Y != -1) {
                curY = startY - 10;
                curX = 10;
                for(int i = 0; i < initialPopulationSize; i++) {
                    if (generations[selectedPerson.Y][selectedPerson.X].DescentsTo(i))
                        g.FillEllipse(Brushes.Green, new Rectangle(curX - sphereRadius, curY - sphereRadius, sphereRadius * 2, sphereRadius * 2));

                    curX += distanceBetweenPersons;
                }
            }
        }

        public void AddGeneration() => AddGeneration(initialPopulationSize);

        public void AddGeneration(int newPopulationSize) {
            Person[] newGen = new Person[newPopulationSize];

            for (int i = 0; i < newPopulationSize; i++)
                newGen[i] = new Person(initialPopulationSize);

            for (int i = 0; i < generations.Last().Length; i++) {
                generations.Last()[i].father = rand.Next(0, newPopulationSize);
                newGen[generations.Last()[i].father].CheckDescendants(generations.Last()[i], initialPopulationSize);

                generations.Last()[i].mother = rand.Next(0, newPopulationSize);
                newGen[generations.Last()[i].mother].CheckDescendants(generations.Last()[i], initialPopulationSize);
            }

            generations.Add(newGen);
        }

        public void SelectPerson(Point location, int distanceBetweenPersons, int startY) {
            selectedPerson = new Point((location.X + (distanceBetweenPersons / 4)) / distanceBetweenPersons, (startY - location.Y + (distanceBetweenPersons / 4)) / distanceBetweenPersons);
        }
    }
}
