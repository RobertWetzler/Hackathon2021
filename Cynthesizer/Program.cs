﻿using NAudio.Wave;
using Cynthesizer;
using System;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave.SampleProviders;

namespace Cynthesizer
{
    class Program
    {
        static double GetKeyFreq()
        {
            char key = Console.ReadKey().KeyChar;
            int val = (int)key;
            double char_1 = 49;
            double char_9 = 57;
            double C4 = 261.63;
            double C5 = 587.33;
            double C6 = 1567.98;
            double C7 = 2093;
            //poor attempt at mapping Keys 1-9 to music notes (doesn't really work except for 1 and 9)
            return (C4 + ((val - char_1) / (char_9 - char_1) * (C5-C4)));
        }
        static void Main(string[] args)
        {
            MidiTest.listDevices();
            MidiTest.handleMidiMessages();
            NoteFrequency.testHalfSteps();
            Console.WriteLine("Hello World!");
            NoteFrequency.NoteToHz('A', 4, ' ');
            NoteFrequency.NoteToHz('B', 4, ' ');
            NoteFrequency.NoteToHz('C', 4, ' ');
            SignalGenerator c4Wave = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = NoteFrequency.NoteToHz('C', 4, ' '),
                Type = SignalGeneratorType.Sin
            };
            SignalGenerator e4Wave = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = NoteFrequency.NoteToHz('E', 4, ' '),
                Type = SignalGeneratorType.Sin
            };
            SignalGenerator g4Wave = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = NoteFrequency.NoteToHz('G', 4, ' '),
                Type = SignalGeneratorType.Sin
            };
            //var c4Wave = new SineWaveProvider(44100, NoteFrequency.NoteToHz('C', 4, ' '), 0);
            //var e4Wave = new SineWaveProvider(44100, NoteFrequency.NoteToHz('E', 4, ' '), 0);
            //var g4Wave = new SineWaveProvider(44100, NoteFrequency.NoteToHz('G', 4, ' '), 0);

            List<ISampleProvider> notes = new List<ISampleProvider> { c4Wave, e4Wave, g4Wave };
            //var cChord = new AdditiveWaveProvider(notes);
            MixingSampleProvider cChord = new MixingSampleProvider(notes);
            using (var wo = new NAudio.Wave.WaveOutEvent())
            {
                wo.Init(cChord);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    c4Wave.Frequency += 0.5;
                    g4Wave.Frequency += 0.5;
                    e4Wave.Frequency += 0.5;
                    //sine20Seconds.Frequency = GetKeyFreq();
                    //uncomment code below to make frequency change over time
                    // DateTime t = DateTime.Now;
                    //long uT = ((DateTimeOffset)t).ToUnixTimeMilliseconds();
                    //sine20Seconds.Frequency = 500 + 400*Math.Sin(uT/1200.0);
                    //Console.WriteLine(" Freq: " + sine20Seconds.Frequency);
                    Thread.Sleep(30);
                }
            }
        }


    }
}
