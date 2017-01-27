using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarPracticeLog
{
    public partial class RiffGenerator : Form
    {
        public RiffGenerator()
        {
            InitializeComponent();
        }

        public class NoteValue
        {
            // Fields
            private int whole = 4;
            private int half = 2;
            private int quarter = 1;
            private double eighth = 1.0 / 2.0;
            private double sixteenth = 1.0 / 4.0;
            private double thirtySecond = 1.0 / 8.0;
            private double sixtyFourth = 1.0 / 16.0;

            // Properties
            public int Whole
            {
                get{ return whole; }
            }
            public int Half
            {
                get{ return half; }
            }
            public int Quarter
            {
                get{ return quarter; }
            }
            public double Eighth
            {
                get{ return eighth; }
            }
            public double Sixteenth
            {
                get{ return sixteenth; }
            }
            public double ThirtySecond
            {
                get{ return thirtySecond; }
            }
            public double SixtyFourth
            {
                get { return sixtyFourth; }
            }
        }
        // Holds the value of each note
        double value;

        // Holds the name of each note in the riff
        List<string> riff = new List<string>();
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Hold errors
                string error = "";
                // Variable to hold total of space used for bars chosen
                double counter = 0;
                double bars = 0;

                // Variable to hold time signature
                double listSelection = ddlTimeSignature.SelectedIndex;

                // Variable to hold bars
                if (nudBars.Value < 1)
                    error += "-Choose # of bars.\n";
                else
                    bars = Convert.ToDouble(nudBars.Value);

                // Determine Time Signature
                if (listSelection == 0)
                    bars *= 1;
                else if (listSelection == 1) // 2/4
                    bars *= 2;
                else if (listSelection == 2) // 3/4
                    bars *= 3;
                else if (listSelection == 3) // 4/4
                    bars *= 4;
                else if (listSelection == 4) // 5/4
                    bars *= 5;
                else if (listSelection == 5) // 6/4
                    bars *= 6;
                else if (listSelection == 6) // 7/4
                    bars *= 7;
                else
                    error += "-Choose a time signature.\n";

                // Array to hold status of each note value checkbox
                bool[] noteArray = new bool[] { chkWhole.Checked, chkHalf.Checked, chkQuarter.Checked, chk8.Checked, chk16.Checked, chk32.Checked, chk64.Checked };

                // Variable to check how many are checked
                int noteIsTrue = 0;
                for (int i = 0; i < noteArray.Length; i++)
                {
                    if (noteArray[i])
                        noteIsTrue++;
                }
                if (noteIsTrue == 0)
                    error += "-At least one note value must be selected.\n";

                // Array to hold status of each interval checkbox
                bool[] intervalArray = new bool[] { chkRoot.Checked, chkMinor2nd.Checked, chkMajor2nd.Checked, chkMinor3rd.Checked, chkMajor3rd.Checked, chkPerfect4th.Checked, chkTritone.Checked, chkPerfect5th.Checked, chkMinor6th.Checked, chkMajor6th.Checked, chkMinor7th.Checked, chkMajor7th.Checked };

                // List of allowed intervals for comparison
                List<int> allowedIntervals = new List<int>();

                // Populate list of allowed intervals
                for (int i = 0; i < intervalArray.Length; i++)
                {
                    if (intervalArray[i])
                    {
                        allowedIntervals.Add(i);
                    }
                }
                if (allowedIntervals.Count < 1)
                    error += "-Must select at least 1 interval to use.\n";

                if (error == "")
                {
                    // Create NoteValue Object
                    NoteValue noteValue = new NoteValue();
                    int note = 0;
                    int interval = 0;
                    // Random number object
                    Random noteValueGenerator = new Random();
                    for (; counter != bars; )
                    {
                        note = noteValueGenerator.Next(0, 7);
                        interval = noteValueGenerator.Next(0, 12);
                        for (int j = 0; j < allowedIntervals.Count; j++)
                        {
                            if (interval == allowedIntervals[j])
                                break;
                            
                            if (j == (allowedIntervals.Count - 1))
                            {
                                interval = noteValueGenerator.Next(0, 12);
                                j = -1;
                            }
                        }
                        if (note == 0)
                        {
                            if (noteArray[6])
                            {
                                value = noteValue.SixtyFourth;
                                counter += value;
                                riff.Add("64," + interval);
                            }
                            else
                                continue;
                        }
                        else if (note == 1)
                        {
                            if (noteArray[5])
                            {
                                value = noteValue.ThirtySecond;
                                counter += value;
                                riff.Add("32," + interval);
                            }
                            else
                                continue;

                        }
                        else if (note == 2)
                        {
                            if (noteArray[4])
                            {
                                value = noteValue.Sixteenth;
                                counter += value;
                                riff.Add("16," + interval);
                            }
                            else
                                continue;
                        }
                        else if (note == 3)
                        {
                            if (noteArray[3])
                            {
                                value = noteValue.Eighth;
                                counter += value;
                                riff.Add("8," + interval);
                            }
                            else
                                continue;
                        }
                        else if (note == 4)
                        {
                            if (noteArray[2])
                            {
                                value = noteValue.Quarter;
                                counter += value;
                                riff.Add("1/4," + interval);
                            }
                            else
                                continue;

                        }
                        else if (note == 5)
                        {
                            if (noteArray[1])
                            {
                                value = noteValue.Half;
                                counter += value;
                                riff.Add("1/2," + interval);
                            }
                            else
                                continue;
                        }
                        else if (note == 6)
                        {
                            if (noteArray[0])
                            {
                                value = noteValue.Whole;
                                counter += value;
                                riff.Add("1/1," + interval);
                            }
                            else
                                continue;
                        }
                        if (counter > bars)
                        {
                            // Remove last note value if total goes higher than total bars and note values
                            riff.RemoveAt(riff.Count - 1);
                            counter -= value;
                        }
                    }
                    
                    // Create Riff form.
                    Riff showRiffForm = new Riff(riff);
                    showRiffForm.ShowDialog();

                    // Clear Riff
                    riff.Clear();
                }
                else
                    MessageBox.Show(error, "Fix Errors");
            }
            catch(FormatException)
            {
                MessageBox.Show("-Invalid # of Bars. Has to be a whole number.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nShow Ryan this error message.", "Error");
            }
        }

        private void chkAllNoteValues_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllNoteValues.Checked)
                SelectAllNoteValues(true);
            else
                SelectAllNoteValues(false);
        }
        private void SelectAllNoteValues(bool c)
        {
            chkWhole.Checked = c;
            chkHalf.Checked = c;
            chkQuarter.Checked = c;
            chk8.Checked = c;
            chk16.Checked = c;
            chk32.Checked = c;
            chk64.Checked = c;
        }

        private void chkAllIntervals_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllIntervals.Checked)
                SelectAllIntervals(true);
            else
                SelectAllIntervals(false);
        }
        private void SelectAllIntervals(bool c)
        {
            chkRoot.Checked = c;
            chkMinor2nd.Checked = c;
            chkMajor2nd.Checked = c;
            chkMinor3rd.Checked = c;
            chkMajor3rd.Checked = c;
            chkPerfect4th.Checked = c;
            chkTritone.Checked = c;
            chkPerfect5th.Checked = c;
            chkMinor6th.Checked = c;
            chkMajor6th.Checked = c;
            chkMinor7th.Checked = c;
            chkMajor7th.Checked = c;
        }
    }
}
