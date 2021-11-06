using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NAudio.Midi;

namespace Cynthesizer
{

    class MidiTest
    {
        static int mInDeviceIndex = -1;
        static int mOutDeviceIndex = -1;
        static MidiIn mMidiIn = null;
        static Boolean mReady = false;

        public static void listDevices()
        {
            Console.WriteLine("MIDI In Devices");
            Console.WriteLine("===============");
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                mReady = true; //  some midi in device exists
                Console.WriteLine(MidiIn.DeviceInfo(device).ProductName);
            }
            mInDeviceIndex = 0;
            Console.WriteLine("\n\n\nMIDI Out Devices");

            Console.WriteLine("=====================");


            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                Console.WriteLine(MidiOut.DeviceInfo(device).ProductName);
            }
            mOutDeviceIndex = 1;
        }
        public static void handleMidiMessages()
        {
            mMidiIn = new MidiIn(mInDeviceIndex);
            mMidiIn.MessageReceived += midiIn_MessageReceived;
            mMidiIn.ErrorReceived += midiIn_ErrorReceived;
            mMidiIn.Start();
        }

        static void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            Console.WriteLine(String.Format(" Time { 0} Message 0x{ 1:X8} Event { 2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }
        private static void printProperties(Object obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
        }
        static void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            MidiEvent m;
            printProperties(e);
           // NoteOnEvent midiEvent = e.MidiEvent;
            //Console.WriteLine("Note: " + midiEvent.NoteName);
            //Console.WriteLine()
            //Console.WriteLine(String.Format("Time { 0} Message 0x{ 1:X8} Event { 2}", e.Timestamp, e.RawMessage, e.MidiEvent));
        }
    }
}
