using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GuitarPracticeLog
{
    
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        List<Exercise> exercises = new List<Exercise>();
        // FORM LOAD
        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string file = "Log.txt";
                string path = Path.GetFullPath(file);
                fileSystemWatcher1.Path = path.Substring(0, (path.Length - file.Length));
                tvToolTip.SetToolTip(tvExercises, "Double-click an exercise to view more details.");
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                // TEST XML SAVE
                DataAccess.SaveData(exercises, "test.xml");

                // RETREIVE DATA
                if(File.Exists("test.xml"))
                {
                   
                    using(FileStream read = new FileStream("test.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(List<Exercise>));
                        List<Exercise> exercise = (List<Exercise>)xs.Deserialize(read);
                        MessageBox.Show(exercise[0].Name);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
        }

        // TREE VIEW
        private void tvExercises_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string node = e.Node.Name;
                if (node != "nArpeggios" && node != "nChords" && node != "nLicksEtudes" && node != "nScaleSequences" && node != "nSongs" && node != "n2HandSync")
                {
                    // Check which tab page is selected
                    if (tabExercise.SelectedTab == tabExercise.TabPages["tabpNew"])
                        tabExercise.SelectedTab = tabExercise.TabPages["tabpView"];

                    // Populate textboxes with selected data
                    for (int i = 0; i < exercises.Count; i++)
                    {
                        if (exercises[i].Name == e.Node.Text)
                        {
                            txtViewDate.Text = exercises[i].Date.ToLongDateString();
                            txtViewName.Text = exercises[i].Name;
                            txtViewCategory.Text = exercises[i].Category;
                            txtViewNotesPerBeat.Text = exercises[i].NotesPerBeat.ToString();
                            txtViewNPM.Text = (exercises[i].NotesPerBeat * exercises[i].Tempo).ToString();
                            txtViewTempo.Text = exercises[i].Tempo.ToString();
                            txtViewTime.Text = exercises[i].Timer.ToString();
                            if (exercises[i].Comments == "blank")
                                rtxtComments.Text = "";
                            else
                                rtxtComments.Text = exercises[i].Comments;
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
            
        }

        // MENU BUTTONS
        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutPracticeLog showAboutPracticeLog = new AboutPracticeLog();
            showAboutPracticeLog.ShowDialog();
        }

        private void menuRhythmGenerator_Click(object sender, EventArgs e)
        {
            RiffGenerator showRhythmGeneratorForm = new RiffGenerator();
            showRhythmGeneratorForm.ShowDialog();
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // NEW EXERCISE
        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                // Error Variable
                string error = "";

                // Name Textbox Logic
                string name = txtNewName.Text;
                if (name == "")
                {
                    error += "-Name: Cannot be blank.\n";
                    lblNewName.ForeColor = Color.Red;
                }
                else
                {
                    lblNewName.ForeColor = Color.Black;
                    // Duplicate Names
                    for (int i = 0; i < exercises.Count; i++)
                    {
                        if (name == exercises[i].Name)
                        {
                            error += "-Name: There is already an exercise named \"" + name + "\".\n";
                            lblNewName.ForeColor = Color.Red;
                            break;
                        }
                    }
                }
                
                // Category Logic
                int category = ddlNewCategory.SelectedIndex;
                if (category == -1)
                {
                    error += "-Category: Select a Category.\n";
                    lblNewCategory.ForeColor = Color.Red;
                }
                else
                    lblNewCategory.ForeColor = Color.Black;

                // Tempo Logic
                int tempo = Convert.ToInt16(nudTempo.Value);
                if (tempo <= 0)
                {
                    error += "-Tempo: Must be greater than 0 BPM.\n";
                    lblNewTempo.ForeColor = Color.Red;
                }
                else
                    lblNewTempo.ForeColor = Color.Black;

                // Notes Per Beat Logic
                gbNotesPerBeat.ForeColor = Color.Black;
                string npb = "";
                if (radQuarter.Checked)
                    npb = radQuarter.Text.Substring(0, 1);
                else if (rad8.Checked)
                    npb = rad8.Text.Substring(0, 1);
                else if (rad8Triplet.Checked)
                    npb = rad8Triplet.Text.Substring(0, 1);
                else if (rad16.Checked)
                    npb = rad16.Text.Substring(0, 1);
                else if (rad16Triplet.Checked)
                    npb = rad16Triplet.Text.Substring(0, 1);
                else if (rad32.Checked)
                    npb = rad32.Text.Substring(0, 1);
                else
                {
                    error += "-Notes Per Beat: Cannot be unchecked.\n";
                    gbNotesPerBeat.ForeColor = Color.Red;
                }

                // Timer Logic
                if (Convert.ToInt16(nudTimer.Text) > 0)
                    lblTime.ForeColor = Color.Black;
                else
                {
                    error += "-Timer: Must be greater than 0.\n";
                    lblTime.ForeColor = Color.Red;
                }

                // Comments Logic
                string comments = rtxtNewComments.Text;
                if (comments == "" || comments.Length < 1)
                    comments = "blank";

                // ID Logic
                int id = 0;
                if (category == 0)
                    id = Exercise.Arpeggio;
                else if (category == 1)
                    id = Exercise.Chord;
                else if (category == 2)
                    id = Exercise.Lick;
                else if (category == 3)
                    id = Exercise.Scale;
                else if (category == 4)
                    id = Exercise.Song;
                else if (category == 5)
                    id = Exercise.TwoHand;

                    // No Errors
                    if (error == "")
                    {                        
                        DialogResult correctInfo = MessageBox.Show("Are you sure everything is entered correctly?", "Ready to Start?", MessageBoxButtons.YesNo);
                        if (correctInfo == DialogResult.Yes)
                        {
                            // Get information to write to a file
                            string info = id + "|" + DateTime.Now.ToShortDateString() + "|" + name + "|" + ddlNewCategory.Items[category].ToString() + "|" + tempo + "|" + startTime + "|" + npb + "|" + comments;
                            GetNewExerciseInfo(info);

                            //  Enable cancel button
                            btn_Cancel.Enabled = true;

                            // Set the metronome
                            nudMetronome.Value = nudTempo.Value;

                            // Get Timer information
                            startTime = Convert.ToInt16(nudTimer.Value);
                            endTime = DateTime.Now.AddMinutes(startTime);

                            // Start the Timer
                            timerControl.Start();

                            // Disable Input areas while timer is enabled.
                            if (timerControl.Enabled)
                                EnableControls(false);
                            if (newMetronome.Enabled)
                                SetMetronomeSpeed(nudTempo);

                            else
                            {
                                SetMetronomeSpeed(nudTempo);
                                metronomeSound.Play();
                                newMetronome.Start();
                            }
                        }
                    }
                    else
                        MessageBox.Show(error, "Fix Errors");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("This exercise will not save if you cancel. Are you sure you want to cancel?", "Cancel Exercise", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (timerControl.Enabled)
                        timerControl.Stop();
                    if (newMetronome.Enabled)
                        newMetronome.Stop();
                    lblTimer.Text = "00:00:00";
                    EnableControls(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
        }
        // METRONOME 
        System.Media.SoundPlayer metronomeSound = new System.Media.SoundPlayer("audio/metronomeSound.wav");
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                decimal speed = nudMetronome.Value;
                if (speed <= 0 || speed > 300)
                    MessageBox.Show("Metronome: Must be higher than 0 and less than 300.");
                else
                {
                    if (newMetronome.Enabled)
                        newMetronome.Stop();
                    // Get and set metronome speed
                    SetMetronomeSpeed(nudMetronome);
                    metronomeSound.Play();
                    newMetronome.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            newMetronome.Stop();
        }
        private void metronome_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            metronomeSound.Play();
        }
        // TIMER
        // Timer Variables
        int startTime;
        DateTime endTime;
        string writeThis;
        System.Media.SoundPlayer finishedSound = new System.Media.SoundPlayer("audio/finished.wav");
        private void timerControl_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = endTime.Subtract(DateTime.Now);
                lblTimer.Text = ts.ToString().Substring(0, 8);
                if (endTime.Ticks < DateTime.Now.Ticks)
                {
                    newMetronome.Stop();
                    finishedSound.Play();
                    timerControl.Stop();
                    lblTimer.Text = "00:00:00";
                    btn_Cancel.Enabled = false;

                    // Call writefile method
                    Exercise.WriteFile("Log.txt", writeThis);

                    // Reset writeThis variable
                    writeThis = "";
                    MessageBox.Show("Time is up! Your practice was recorded.", "Exercise Added");
                    EnableControls(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTell Ryan this error message.", "Error");
            }
        }
        // HELPER METHODS
        public void EnableControls(bool enabled)
        {
            btn_Start.Enabled = enabled;
            txtNewName.Enabled = enabled;
            ddlNewCategory.Enabled = enabled;
            rtxtNewComments.Enabled = enabled;
            gbNotesPerBeat.Enabled = enabled;
            nudTempo.Enabled = enabled;
            nudTimer.Enabled = enabled;
        }
        public void SetMetronomeSpeed(NumericUpDown tempobox)
        {
            newMetronome.Interval = Convert.ToInt16((double)60000 / Convert.ToDouble(tempobox.Value));
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            exercises.Clear();
            // Clear child nodes from treeview
            for (int i = 0; i < tvExercises.GetNodeCount(false); i++)
            {
                tvExercises.Nodes[i].Nodes.Clear();
            }
            // Reset static variables back to 1 before reloading
            Exercise.Arpeggio = 1;
            Exercise.Chord = 1;
            Exercise.Lick = 1;
            Exercise.Scale = 1;
            Exercise.Song = 1;
            Exercise.TwoHand = 1;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                // Populate data fields
                Exercise.ReadFile("Log.txt", exercises);

                //Total Exercise Variable
                txtTotalExercises.Text = exercises.Count.ToString();

                // Category Variables
                int counter2HandSync = 0;
                int counterArpeggio = 0;
                int counterChord = 0;
                int counterLickEtude = 0;
                int counterScaleSequence = 0;
                int counterSongs = 0;

                // Practice Time Variable
                double totalPractice = 0;

                // NPM Variables
                double totalNPM = 0;
                double minNPM = 10000;
                double maxNPM = 0;
                double thisNPM;

                // Tempo Variable
                int totalTempo = 0;
                int minTempo = 301;
                int maxTempo = 0;

                for (int i = 0; i < exercises.Count; i++)
                {
                    // Category Counter
                    if (exercises[i].Category == "Two Hand Synchronization")
                        counter2HandSync++;
                    if (exercises[i].Category == "Arpeggio")
                        counterArpeggio++;
                    if (exercises[i].Category == "Chord")
                        counterChord++;
                    if (exercises[i].Category == "Lick/Etude")
                        counterLickEtude++;
                    if (exercises[i].Category == "Scale Sequence")
                        counterScaleSequence++;
                    if (exercises[i].Category == "Song")
                        counterSongs++;

                    // Add Up Practice Time
                    totalPractice += Convert.ToDouble(exercises[i].Timer);

                    //Add Up Tempo for Average
                    totalTempo += Convert.ToInt16(exercises[i].Tempo);

                    // Determine minimum tempo
                    if (exercises[i].Tempo < minTempo)
                        minTempo = exercises[i].Tempo;

                    // Determine Maximum tempo
                    if (exercises[i].Tempo > maxTempo)
                        maxTempo = exercises[i].Tempo;

                    // Add up total NPM
                    totalNPM += exercises[i].NotesPerBeat * exercises[i].Tempo;

                    thisNPM = exercises[i].NotesPerBeat * exercises[i].Tempo;
                    // Determine Minimum NPM

                    if (thisNPM < minNPM)
                        minNPM = thisNPM;
                    // Determine Maximum NPM
                    if (thisNPM > maxNPM)
                        maxNPM = thisNPM;
                }

                // Assign values to Appropriate Textboxes
                txt2HandSync.Text = counter2HandSync.ToString();
                txtArpeggios.Text = counterArpeggio.ToString();
                txtChords.Text = counterChord.ToString();
                txtLicksEtudes.Text = counterLickEtude.ToString();
                txtScaleSequences.Text = counterScaleSequence.ToString();
                txtSongs.Text = counterSongs.ToString();
                txtTotalTime.Text = (totalPractice / 60).ToString("F1");

                if (totalPractice > 0)
                    txtAvgTime.Text = (totalPractice / exercises.Count).ToString("F0");
                else
                    txtAvgTime.Text = "0";

                if (totalNPM > 0)
                    txtAverageNPM.Text = (totalNPM / exercises.Count).ToString("F0");
                else
                    txtAverageNPM.Text = "0";

                if (minNPM != 10000)
                    txtMinNPM.Text = minNPM.ToString();
                else
                    txtMinNPM.Text = "0";
                if (maxNPM > 0)
                    txtMaxNPM.Text = maxNPM.ToString();
                else
                    txtMaxNPM.Text = "0";

                if (exercises.Count != 0)
                    txtAvgTempo.Text = (totalTempo / exercises.Count).ToString();
                else
                    txtAvgTempo.Text = "0";

                if (minTempo < 301 && minTempo > 0)
                    txtMinTempo.Text = minTempo.ToString();
                else
                    txtMinTempo.Text = "0";
                if (maxTempo > 0 && maxTempo < 301)
                    txtMaxTempo.Text = maxTempo.ToString();
                else
                    txtMaxTempo.Text = "0";

                // Populate TreeView
                for (int i = 0; i < exercises.Count; i++)
                {
                    if (exercises[i].Category == "Arpeggio")
                        tvExercises.Nodes[0].Nodes.Add(exercises[i].Name);
                    else if (exercises[i].Category == "Chord")
                        tvExercises.Nodes[1].Nodes.Add(exercises[i].Name);
                    else if (exercises[i].Category == "Lick/Etude")
                        tvExercises.Nodes[2].Nodes.Add(exercises[i].Name);
                    else if (exercises[i].Category == "Scale Sequence")
                        tvExercises.Nodes[3].Nodes.Add(exercises[i].Name);
                    else if (exercises[i].Category == "Song")
                        tvExercises.Nodes[4].Nodes.Add(exercises[i].Name);
                    else if (exercises[i].Category == "Two Hand Synchronization")
                        tvExercises.Nodes[5].Nodes.Add(exercises[i].Name);
                    
                    //Exercise.CheckFileForUpdate("Log.txt");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nShow Ryan this error message.", "Error");
            }
        }
        private void GetNewExerciseInfo(string info)
        {
            writeThis = info;
        }
    }
}
