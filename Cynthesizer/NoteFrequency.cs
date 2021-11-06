using System;
using System.Collections.Generic;
using System.Text;

namespace Cynthesizer
{
    static class NoteFrequency
    {
        //calculate the Hz of a music note, using the formula given by https://pages.mtu.edu/~suits/NoteFreqCalcs.html
        public static double NoteToHz(char note = 'A', int scale = 4, char accidental = ' ')
        {
            //base: A4 is 440HZ
            double A4 = 440;
            int halfSteps = HalfStepsFromA4(note, scale, accidental);
            double a = Math.Pow(2, halfSteps / 12f);
            double result = A4 * a;
            Console.WriteLine("" + note + scale + accidental + " - frequency: " + result);
            return A4 * a;
        }
        //number of half steps from A4
        private static int HalfStepsFromA4(char note = 'A', int scale = 4, char accidental = ' ')
        {

            Dictionary<char, int> offsetFromA = new Dictionary<char, int>()
            {
                { 'C', -9 },
                { 'D', -7 },
                {'E', -5 },
                {'F', -4 },
                {'G', -2 }
            };


            char[] scaleOrder = new char[] { 'C', 'D', 'E', 'F', 'G', 'A', 'B' };
            int scaleIndex = Array.IndexOf(scaleOrder, note);
            int scaleDif = scale - 4;
            return 0;
           // int result = scaleDif * 12 + offsetFromA;
           /**
            int mult = Math.Sign(noteDif);
            if (note >= 'B')
            {
                result += mult;
            }
            if(note >= 'D')
            {
                result += mult;
            }
            if(note >= 'E')
            {
                result += mult;
            }
            if(note == 'G')
            {
                result += mult;
            }
            if(accidental == '#')
            {
                result += 1;
            }
            else if(accidental == 'b')
            {
                result -= 1;
            }
            return result;
           */
        }
        public static void testHalfSteps()
        {
            int steps = HalfStepsFromA4('A', 4);
            steps = HalfStepsFromA4('B', 4);
            steps = HalfStepsFromA4('C', 4);
            steps = HalfStepsFromA4('D', 4);
            steps = HalfStepsFromA4('E', 4);
            steps = HalfStepsFromA4('F', 4);
            steps = HalfStepsFromA4('G', 4);
        }
    }
}
