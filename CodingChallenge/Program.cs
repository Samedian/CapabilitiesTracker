using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    class NegativeNumberException : Exception
    {
        public NegativeNumberException(string msg) : base(msg)
        {

        }
    }

    class TrackDoesnotExist : Exception
    {
        public TrackDoesnotExist(string msg) : base(msg)
        {

        }
    }
    class DuplicateKey : Exception
    {
        public DuplicateKey(string msg) : base(msg)
        {

        }
    }
    class StringContainDigit : Exception
    {
        public StringContainDigit(string msg) : base(msg)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Track> track = new Dictionary<string, Track>();
            ArrayList capability = new ArrayList();
            Track TrackDetails = null;
            Capability CapabilityDetails = null;

            int choice = -1;
            char ch;
            do
            {
                Console.WriteLine("Choose from Menu :");
                Console.WriteLine("1.Add Track");
                Console.WriteLine("2.Add Capability");
                Console.WriteLine("3.Display Capabilities as per Track");
                Console.WriteLine("4.Display All Capabilities and write in txt file");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 0)
                        throw new NegativeNumberException("Sorry Number is negative");
                }
                catch (NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception);
                }

                switch (choice)
                {
                    case 1:
                        track = AddTrack(TrackDetails, track);
                        break;

                    case 2:
                        CapabilityDetails = AddCapability(CapabilityDetails, track);
                        if (CapabilityDetails != null)
                            capability.Add(CapabilityDetails);
                        break;

                    case 3:
                        Display(capability, track);
                        break;

                    case 4:
                        DisplayAll(capability);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;

                }
                Console.WriteLine("Do you want to continue :");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'y' || ch == 'Y');
        }

        private static void DisplayAll(ArrayList capability)
        {
            foreach (Capability data in capability)
            {
                DisplayCapability(data);
                WriteTextFile(data);

            }

        }

        private static void WriteTextFile(Capability data)
        {
            string path = @"E:\capability.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Capability Id :" + data.CapabilityId);
                    writer.WriteLine("Summary      :" + data.Summary);
                    writer.Write("Ko           :");
                    foreach (string el in data.Ko)
                    {
                        writer.Write(el + "\t");
                    }

                    writer.Write("Non-Ko           :");
                    foreach (string el in data.NonKo)
                    {
                        writer.Write(el + "\t");
                    }
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine("Capability Id :" + data.CapabilityId);
                    writer.WriteLine("Summary      :" + data.Summary);
                    writer.Write("Ko           :");
                    foreach (string el in data.Ko)
                    {
                        writer.Write(el + "\t");
                    }

                    writer.Write("Non-Ko           :");
                    foreach (string el in data.NonKo)
                    {
                        writer.Write(el + "\t");
                    }
                }
            }
        }

        private static void Display(ArrayList capability, Dictionary<string, Track> track)
        {
            Console.WriteLine("Enter Track Name ");
            string trackName = Console.ReadLine();
            trackName = TitleCase(trackName);
            try
            {
                if (trackName == null || !track.ContainsKey(trackName))
                    throw new TrackDoesnotExist("Track Not Found !!!!!");

            }
            catch (TrackDoesnotExist exception)
            {
                Console.WriteLine(exception);
            }

            foreach (Capability data in capability)
            {
                if (data.MyTrack.TrackName.Equals(trackName))
                {
                    DisplayCapability(data);
                }
            }
        }

        private static void DisplayCapability(Capability data)
        {

            Console.WriteLine("Track :" + data.MyTrack.TrackName);

            Console.WriteLine("1.Capability Id  :" + data.CapabilityId);
            Console.WriteLine();
            Console.WriteLine("2.Ko\'s");

            foreach (string el in data.Ko)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            Console.WriteLine("3.Non Ko\'s");
            foreach (string el in data.NonKo)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine("4.Summary");
            Console.WriteLine(data.Summary);
            Console.WriteLine();
        }

        private static Capability AddCapability(Capability capabilityDetails, Dictionary<string, Track> track)
        {
            int num = 0;
            string trackName, str, summary;
            List<string> Ko = new List<string>();
            ArrayList NonKo = new ArrayList();
            Track trackfind = new Track();

            Console.WriteLine("Enter Track Name ");
            trackName = Console.ReadLine();

            trackName = TitleCase(trackName);

            try
            {
                if (!track.ContainsKey(trackName))
                    throw new TrackDoesnotExist("Track Doesn't Exist");
            }
            catch (TrackDoesnotExist exception)
            {
                Console.WriteLine(exception);
                return null;
            }

            foreach (var item in track)
            {
                if (item.Key.Equals(trackName))
                {
                    trackfind = item.Value;
                }
            }
            Console.WriteLine("Enter No of Ko's :");

            try
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num < 0)
                    throw new NegativeNumberException("Sorry Number is negative");
            }
            catch (NegativeNumberException exception)
            {
                Console.WriteLine(exception);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Ko's");
            for (int index = 0; index < num; index++)
            {
                str = Console.ReadLine();
                Ko.Add(str);
            }

            Console.WriteLine("Enter No of Non-Ko's :");

            try
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num < 0)
                    throw new NegativeNumberException("Sorry Number is negative");
            }
            catch (NegativeNumberException exception)
            {
                Console.WriteLine(exception);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Non Ko's");
            for (int index = 0; index < num; index++)
            {
                str = Console.ReadLine();
                NonKo.Add(str);
            }

            Console.WriteLine("Enter Summary");
            summary = Console.ReadLine();

            capabilityDetails = new Capability(Ko, NonKo, summary, trackfind);
            return capabilityDetails;


        }

        private static Dictionary<string, Track> AddTrack(Track trackDetails, Dictionary<string, Track> track)
        {
            string name;
            int id = 0;


            Console.WriteLine("Enter Track Name :");
            name = Console.ReadLine();

            name = TitleCase(name);
            try
            {
                if (track.ContainsKey(name) || name == null)
                {
                    throw new DuplicateKey("sorry Its already Present");
                }
            }
            catch (DuplicateKey exception)
            {
                Console.WriteLine(exception);
                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("Enter Id");

            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                if (id < 0)
                    throw new NegativeNumberException("Sorry Id can't be negative");
            }
            catch (NegativeNumberException exception)
            {
                Console.WriteLine(exception);
            }
            catch (System.FormatException exception)
            {
                Console.WriteLine(exception);
            }

            trackDetails = new Track(id, name);
            track.Add(name, trackDetails);
            return track;
        }

        private static string TitleCase(string str)
        {
            if (str.Any(char.IsDigit))
                return null;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            str = textInfo.ToTitleCase(str);

            return str;
        }

        private static string UpperCase(string str)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            str = textInfo.ToUpper(str);

            return str;
        }
    }
}
