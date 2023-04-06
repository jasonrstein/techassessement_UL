using System;
using System.Collections.Generic;
using System.Linq;

namespace ChipSecuritySystem
{
    public  class Program
    {
        

        public static ColorChip[] colorChips = new ColorChip[] {
               new ColorChip(Color.Purple, Color.Green),
               new ColorChip(Color.Blue, Color.Red),
               new ColorChip(Color.Red, Color.Yellow),
               new ColorChip(Color.Yellow, Color.Purple),
               new ColorChip(Color.Purple, Color.Red),
             };

        static void Main(string[] args)
        {
            int r = colorChips.Length;
            var data = new ColorChip[r-2];
            int counter = 0;
            int start = 0;
            int end = 0;

            foreach (var chip in colorChips)
            {
                Console.WriteLine(chip);
            }

            for (int i = 0; i < r; i++)
            {
                if (colorChips[i].StartColor == Color.Blue)
                {
                    start = i;
                }
                else if (colorChips[i].EndColor == Color.Green)
                {
                    end = i;
                }
                else
                {
                    data[counter] = colorChips[i];
                    counter++;
                }
            }

            var unUsed = new List<ColorChip>();
            var used = new List<ColorChip>();
            bool foundSequence = false;
            int iterationCount = 0;
            used.Add(colorChips[start]);

            foreach (var chip in data)
            {   
                if (used.Count == 0 && colorChips[start].EndColor == chip.StartColor)
                {
                    used.Add(chip);
                }
                unUsed.Add(chip);
            }

            while (!foundSequence || iterationCount < 20) 
            {
                for (int i = 0; i < unUsed.Count; i++)
                {
                    if (used.Last().EndColor == unUsed[i].StartColor)
                    {
                        used.Add(unUsed[i]);
                    }
                    unUsed.RemoveAt(i);
                }
                if (colorChips[end].StartColor == used.Last().EndColor)
                {
                    used.Add(colorChips[end]);
                    foundSequence = true;
                }
                iterationCount++;
            }

            for (int i = 0; i < used.Count; i++)
            {
                Console.WriteLine();
                Console.Write(used[i]);
            }
            Console.ReadLine();
            
        }
    }
}
