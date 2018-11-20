using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
namespace O.A.I.sys
{
    public partial class VIEW : Form
    {
        string Name1 = "Oasis";
        SpeechSynthesizer s = new SpeechSynthesizer();

        string Password = "user1";
        string[] CM = new string[8] { "C", "D", "E", "F", "G", "A", "B", "C2" };
        string[] DM = new string[8] { "D", "E", "F#", "G", "A", "B", "C#", "D2" };
        string[] EM = new string[8] { "E", "F#", "G#", "A", "B", "C#", "D#", "E2" };
        string[] FM = new string[8] { "F", "G", "A", "Bb", "C", "D", "E", "F2" };
        string[] GM = new string[8] { "G", "A", "B", "C", "D", "E", "F#", "G2" };
        string[] AM = new string[8] { "A", "B", "C#", "D", "E", "F#", "G#", "A2" };
        string[] Bm = new string[8] { "B", "C#", "D#", "E", "F#", "G#", "A#", "B2" };
        string[] CsDb = new string[8] { "Db", "Eb", "F", "Gb", "Ab", "Bb", "C", "Db2" };
        string[] DsEb = new string[8] { "Eb", "F", "G", "Ab", "Bb", "C", "D", "Eb2" };
        string[] FsGb = new string[8] { "F#", "G#", "A#", "B", "C#", "D#", "F", "F#2" };
        string[] GsAb = new string[8] { "Ab", "Bb", "C", "Db", "Eb", "F", "G", "Ab2" };
        string[] AsBb = new string[8] { "Bb", "C", "D", "Eb", "F", "G", "A", "Bb2" };
        string[] Am = new string[8] { "A", "B", "C", "D", "E", "F", "G", "A2" };
        string[] AsBbm = new string[8] { "A#", "C", "C#", "D#", "F", "F#", "G#", "A#2" };
        string[] Cm = new string[8] { "C", "D", "Db", "F", "G", "Ab", "Bb", "C2" };
        string[] CsDbm = new string[8] { "C#", "D#", "E", "F#", "G#", "A", "B", "C#2" };
        string[] Dm = new string[8] { "D", "E", "F", "G", "A", "Bb", "C", "D2" };
        string[] DsEbm = new string[8] { "D#", "F", "F#", "G#", "A#", "B", "C#", "D#2" };
        string[] Em = new string[8] { "E", "F#", "G", "A", "B", "C", "D", "E2" };
        string[] Fm = new string[8] { "F", "G", "Ab", "Bb", "C", "Db", "Eb", "F2" };
        string[] FsGbm = new string[8] { "F#", "G#", "A", "B", "C#", "D", "E", "F2" };
        string[] Gm = new string[8] { "G", "A", "Bb", "C", "D", "Eb", "F", "G2" };
        string[] GsAbm = new string[8] { "G#", "A#", "B", "C#", "D#", "Eb", "F#", "G#2" };

        /// <summary>
        /// CONTROLS SLEEP AND WAKE MODE SO ThAT it Doesnt RECOGNISE UNWANTED COMMANDS
        /// </summary>

        Boolean wake = true;

        Choices list = new Choices();
        public VIEW()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            /// ALWAAYS ADD NEW COMMANDS HERE THIS IS A LIST OF VIABLE COMMANDS KEEP LOWER CASE

            list.Add(new String[] { "restart", "open music ", "lets order pizza", "lets make a song", "hello", "how are you", "What time is it", "What day is it", "I need to search the web", "open google", "wake up", "sleep", "caip", "go to sleep" });

            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {


                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }



            s.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen, 1);

            InitializeComponent();
        }
        ///  public void restart()
        //   {
        //      Process.Start(c\)
        //  }
        /// <summary>

        public void say(String h)
        {
            s.Speak(h);
        }
        /// <summary>
        /// /The following public void rec_SpeachRecognized is the command log you can type new commands and respones 
        /// </summary>
        //ffff
        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;



            if (r == "sleep" || r == "go to sleep") wake = false;
            if (wake == false)
            {
                say("let me know is you need further assistance");
            }
            if (r == "wake up" || r == "caip") wake = true;
            if (wake == true)
            {




                // What You Say (ALWAYS KEEP LOWER CASE)
                if (r == "hello")
                {
                    //RESPONSE THROW BACK (pause)
                    //Say is a command
                    say("Hi am" + Name1);

                }

                // What You Say (ALWAYS KEEP LOWER CASE)
                if (r == "how are you")
                {
                    //RESPONSE THROW BACK (pause)
                    //Say is a command
                    say("I am great always good to be among the living");

                }
                if (r == "What time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }
                if (r == "What day is it")
                {
                    say(DateTime.Now.ToString("M/d/yyyy , h: mm tt"));

                }
                if (r == "I need to search the web" || r == "open google")
                {
                    Process.Start("http://www.google.com/‎");



                }

                if (r == "lets make a song")
                {
                    Console.WriteLine(" please enter a key  " +
                        "CM = c maj " +
                        "DM = d maj " +
                        "EM = e maj" +
                        "FM =  f maj" +
                        "GM = g maj  " +
                        "AM = a maj  " +
                        "Bm = b maj  " +
                        "CsDb c sharp / d flat " +
                        "DsEb d sharp / e flat" +
                        "FsGb f sharp / g flat " +
                        "GsAb g sharp / a flat " +
                        "AsBb a sharp / b flat " +
                        "Am = a minor " +
                        "AsBbm a sharp / b flat minor " +
                        "Cm = C minor " +
                        "CsDbm c sharp / d flat minor" +
                        "Dm = d minor " +
                        "DsEbm = d sharp / e flat minor  " +
                        "Em = e minor " +
                        "Fm =  f minor" +
                        "FsGbm f sharp / g flat major" +
                        "Gm = g minor " +
                        "GsAbm  = g sharp / a flat minor" );

                    string reeeet = Console.ReadLine () ;
                   

                    if (reeeet == "CM")
                    {

                         string[] keysr = KeyReturn(CM);
                        Console.WriteLine(keysr.ToString());

                    }


                }




                if (r == "lets order pizza")
                {
                    Process.Start(" http://www.papajohns.com‎/");

                    say("okay, lets see whats on the menu, I like pepperoni");

                }

            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public static string[] KeyReturn(string[] a)
        {

            string[] keys = a;


            return keys;

        }
    }

   

}
