using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarPracticeLog
{
    //public class SubExercise : Exercise
    //{
    //    private int totalTimes
    //}
    public class Exercise
    {
        // Private Variables
        private int id;
        private string name;
        private string category;
        private int tempo;
        private int timer;
        private int notesPerBeat;
        private string comments;
        private DateTime date;
        
        // Counter Variables
        private static int arpeggio = 1;
        private static int chord = 1;
        private static int lick = 1;
        private static int scale = 1;
        private static int song = 1;
        private static int twoHand = 1;
        

        // Public Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }
        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int NotesPerBeat
        { 
            get { return notesPerBeat; }
            set { notesPerBeat = value; }
        }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public static int Arpeggio
        {
            get { return arpeggio; }
            set { arpeggio = value; }
        }
        public static int Chord
        {
            get { return chord; }
            set { chord = value; }
        }
        public static int Lick
        {
            get { return lick; }
            set { lick = value; }
        }
        public static int Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public static int Song
        {
            get { return song; }
            set { song = value; }
        }
        public static int TwoHand
        {
            get { return twoHand; }
            set { twoHand = value; }
        }
        //// Methods
        public static void ReadFile(string fileName, List<Exercise> exerciseCollection)
        {
            try
            {
                // Check for file
                if (!File.Exists(fileName))
                {
                    using (File.Create(fileName))
                    {
                        string path = Path.GetFullPath(fileName);
                        //MessageBox.Show(fileName + " was created in: " + path, "Practice Log");
                    }
                }
                else
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Exercise ex = new Exercise();
                            string[] data = line.Split('|');
                            if (data[3] == "Arpeggio")
                            {
                                ex.ID = Exercise.Arpeggio;
                                Exercise.Arpeggio++;
                            }                                
                            else if (data[3] == "Chord")
                            {
                                ex.ID = Exercise.Chord;
                                Exercise.Chord++;
                            }                                
                            else if (data[3] == "Lick/Etude")
                            {
                                ex.ID = Exercise.Lick;
                                Exercise.Lick++;
                            }                                
                            else if (data[3] == "Scale Sequence")
                            {
                                ex.ID = Exercise.Scale;
                                Exercise.Scale++;
                            }                                
                            else if (data[3] == "Song")
                            {
                                ex.ID = Exercise.Song;
                                Exercise.Song++;
                            }                                
                            else if (data[3] == "Two Hand Synchronization")
                            {
                                ex.ID = Exercise.TwoHand;
                                Exercise.TwoHand++;
                            }
                             
                            ex.Date = DateTime.Parse(data[1]);
                            ex.Name = data[2];
                            ex.Category = data[3];
                            ex.Tempo = Convert.ToInt16(data[4]);
                            ex.Timer = Convert.ToInt16(data[5]);
                            ex.NotesPerBeat = Convert.ToInt16(data[6]);
                            ex.Comments = data[7];
                            exerciseCollection.Add(ex);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
        public static void WriteFile(string fileName, string writeThis)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(writeThis);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
    }
}
