using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Runtime.InteropServices;

namespace GuitarPracticeLog
{
    public partial class Riff : Form
    {
        // Private fields
        private string noteValue;
        private int noteInterval;

        //Properties
        public string NoteValue
        {
            get { return noteValue; }
            set
            {
                noteValue = value;
            }
        }
        public int NoteInterval
        {
            get { return noteInterval; }
            set
            {
                noteInterval = value;
            }
        }
        public Riff()
        {
            InitializeComponent();
        }

        // Grab riff generator data from riff generator form
        List<string> riff = new List<string>();
        public Riff(List<string> riffList)
        {
            InitializeComponent();
            riff = riffList;
        }
        // List of riff objects
        List<Riff> riffList = new List<Riff>();
        private void Riff_Load(object sender, EventArgs e)
        {
            this.HorizontalScroll.Enabled = false;
            
            this.HScroll = false;
            // Load riffList with data from previous form
            for (int i = 0; i < riff.Count; i++)
            {
                Riff riffObject = new Riff();
                string[] data = riff[i].Split(',');
                riffObject.NoteValue = data[0];
                riffObject.NoteInterval = Convert.ToInt16(data[1]);
                riffList.Add(riffObject);
            }

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Acquire images for drawing
                using (
                Bitmap whole = new Bitmap(Image.FromFile("images/whole.png"), new Size(25, 25)),
                half = new Bitmap(Image.FromFile("images/half.png"), new Size(25, 25)),
                quarter = new Bitmap(Image.FromFile("images/quarter.png"), new Size(25, 25)),
                eighth = new Bitmap(Image.FromFile("images/eighth.png"), new Size(25, 25)),
                sixteenth = new Bitmap(Image.FromFile("images/sixteenth.png"), new Size(25, 25)),
                thirtySecond = new Bitmap(Image.FromFile("images/thirtysecond.png"), new Size(25, 25)),
                sixtyFourth = new Bitmap(Image.FromFile("images/sixtyfourth.png"), new Size(25, 25)),
                barSplitter = new Bitmap(Image.FromFile("images/barSplitter.png"), new Size(2, 150)),
                sharp = new Bitmap(Image.FromFile("images/sharp.png"), new Size(25, 25)),
                staff = new Bitmap(Image.FromFile("images/staff.png"), new Size(this.Width - 75, 150)),
                zero = new Bitmap(Image.FromFile("images/0.png"), new Size(25, 25)),
                one = new Bitmap(Image.FromFile("images/1.png"), new Size(25, 25)),
                two = new Bitmap(Image.FromFile("images/2.png"), new Size(25, 25)),
                three = new Bitmap(Image.FromFile("images/3.png"), new Size(25, 25)),
                four = new Bitmap(Image.FromFile("images/4.png"), new Size(25, 25)),
                five = new Bitmap(Image.FromFile("images/5.png"), new Size(25, 25)),
                six = new Bitmap(Image.FromFile("images/6.png"), new Size(25, 25)),
                seven = new Bitmap(Image.FromFile("images/7.png"), new Size(25, 25)),
                eight = new Bitmap(Image.FromFile("images/8.png"), new Size(25, 25)),
                nine = new Bitmap(Image.FromFile("images/9.png"), new Size(25, 25)),
                ten = new Bitmap(Image.FromFile("images/10.png"), new Size(25, 25)),
                eleven = new Bitmap(Image.FromFile("images/11.png"), new Size(25, 25)))
                {

                    // Upper left corner start
                    Point ulCorner = new Point(50, 25);
                    Point staffCorner = new Point(25, 25);
                    Point numberCorner = new Point(50, 165);
                    //Pen rectangle = new Pen(Color.Red);
                    // Draw the staff
                    e.Graphics.DrawImage(staff, staffCorner);
                    //e.Graphics.DrawRectangle(rectangle, new Rectangle(60, 100, 50, 90));

                    // Variable to hold width of the staff
                    int staffWidth = 0;
                    int rowAddition = 0;

                    for (int i = 0; i < riffList.Count; i++)
                    {
                        if (staffWidth >= this.Width - 150)
                        {
                            // Reset x co ordinates and add 200 pixels to Y co ordinates, draw new staff
                            ulCorner.X = 50;
                            staffCorner.Y += 200;
                            staffWidth = 0;
                            rowAddition += 200;
                            e.Graphics.DrawImage(staff, staffCorner);
                            numberCorner.X = 50;
                            numberCorner.Y += 200;
                        }
                        // Determine if sharps are needed
                        if (riffList[i].NoteInterval == 0)
                        {
                            ulCorner.Y = 137 + rowAddition;
                            e.Graphics.DrawImage(zero, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 1)
                        {
                            ulCorner.Y = 125 + rowAddition;
                            e.Graphics.DrawImage(one, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 2)
                        {
                            ulCorner.Y = 25 + rowAddition;
                            e.Graphics.DrawImage(sharp, ulCorner);
                            ulCorner.Y = 125 + rowAddition;
                            e.Graphics.DrawImage(two, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 3)
                        {
                            ulCorner.Y = 113 + rowAddition;
                            e.Graphics.DrawImage(three, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 4)
                        {
                            ulCorner.Y = 25 + rowAddition;
                            e.Graphics.DrawImage(sharp, ulCorner);
                            ulCorner.Y = 113 + rowAddition;
                            e.Graphics.DrawImage(four, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 5)
                        {
                            ulCorner.Y = 100 + rowAddition;
                            e.Graphics.DrawImage(five, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 6)
                        {
                            ulCorner.Y = 88 + rowAddition;
                            e.Graphics.DrawImage(six, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 7)
                        {
                            ulCorner.Y = 25 + rowAddition;
                            e.Graphics.DrawImage(sharp, ulCorner);
                            ulCorner.Y = 88 + rowAddition;
                            e.Graphics.DrawImage(seven, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 8)
                        {
                            ulCorner.Y = 75 + rowAddition;
                            e.Graphics.DrawImage(eight, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 9)
                        {
                            ulCorner.Y = 25 + rowAddition;
                            e.Graphics.DrawImage(sharp, ulCorner);
                            ulCorner.Y = 75 + rowAddition;
                            e.Graphics.DrawImage(nine, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 10)
                        {
                            ulCorner.Y = 63 + rowAddition;
                            e.Graphics.DrawImage(ten, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        else if (riffList[i].NoteInterval == 11)
                        {
                            ulCorner.Y = 25 + rowAddition;
                            e.Graphics.DrawImage(sharp, ulCorner);
                            ulCorner.Y = 63 + rowAddition;
                            e.Graphics.DrawImage(eleven, numberCorner);
                            if (riffList[i].NoteValue == "1/1")
                                numberCorner.X += whole.Width + 160;
                            else if (riffList[i].NoteValue == "1/2")
                                numberCorner.X += half.Width + 80;
                            else if (riffList[i].NoteValue == "1/4")
                                numberCorner.X += quarter.Width + 40;
                            else if (riffList[i].NoteValue == "8")
                                numberCorner.X += eighth.Width + 20;
                            else if (riffList[i].NoteValue == "16")
                                numberCorner.X += sixteenth.Width + 10;
                            else if (riffList[i].NoteValue == "32")
                                numberCorner.X += thirtySecond.Width + 5;
                            else if (riffList[i].NoteValue == "64")
                                numberCorner.X += sixtyFourth.Width;
                        }
                        // Determine position on the staff to draw notes
                        if (riffList[i].NoteValue == "1/1")
                        {
                            e.Graphics.DrawImage(whole, ulCorner);
                            ulCorner.X += whole.Width + 160;
                            staffWidth += whole.Width + 160;
                        }
                        else if (riffList[i].NoteValue == "1/2")
                        {
                            e.Graphics.DrawImage(half, ulCorner);
                            ulCorner.X += half.Width + 80;
                            staffWidth += half.Width + 80;
                        }
                        else if (riffList[i].NoteValue == "1/4")
                        {
                            e.Graphics.DrawImage(quarter, ulCorner);
                            ulCorner.X += quarter.Width + 40;
                            staffWidth += quarter.Width + 40;
                        }
                        else if (riffList[i].NoteValue == "8")
                        {
                            e.Graphics.DrawImage(eighth, ulCorner);
                            ulCorner.X += eighth.Width + 20;
                            staffWidth += eighth.Width + 20;
                        }
                        else if (riffList[i].NoteValue == "16")
                        {
                            e.Graphics.DrawImage(sixteenth, ulCorner);
                            ulCorner.X += sixteenth.Width + 10;
                            staffWidth += sixteenth.Width + 10;
                        }
                        else if (riffList[i].NoteValue == "32")
                        {
                            e.Graphics.DrawImage(thirtySecond, ulCorner);
                            ulCorner.X += thirtySecond.Width + 5;
                            staffWidth += thirtySecond.Width + 5;
                        }
                        else if (riffList[i].NoteValue == "64")
                        {
                            e.Graphics.DrawImage(sixtyFourth, ulCorner);
                            ulCorner.X += sixtyFourth.Width;
                            staffWidth += sixtyFourth.Width;
                        }
                    }
                    this.AutoScrollMinSize = new Size(this.Width, rowAddition + 200);
                    pictureBox.Size = new Size(this.Width, rowAddition + 200);
                    this.HorizontalScroll.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nShow Ryan this error message.", "Error");
            }
        }
    }
}
