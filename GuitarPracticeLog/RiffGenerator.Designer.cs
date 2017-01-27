namespace GuitarPracticeLog
{
    partial class RiffGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ddlTimeSignature = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbNoteValues = new System.Windows.Forms.GroupBox();
            this.chk64 = new System.Windows.Forms.CheckBox();
            this.chk32 = new System.Windows.Forms.CheckBox();
            this.chk16 = new System.Windows.Forms.CheckBox();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chkQuarter = new System.Windows.Forms.CheckBox();
            this.chkHalf = new System.Windows.Forms.CheckBox();
            this.chkWhole = new System.Windows.Forms.CheckBox();
            this.gbIntervals = new System.Windows.Forms.GroupBox();
            this.chkMajor7th = new System.Windows.Forms.CheckBox();
            this.chkMinor7th = new System.Windows.Forms.CheckBox();
            this.chkMajor6th = new System.Windows.Forms.CheckBox();
            this.chkMinor6th = new System.Windows.Forms.CheckBox();
            this.chkPerfect5th = new System.Windows.Forms.CheckBox();
            this.chkTritone = new System.Windows.Forms.CheckBox();
            this.chkPerfect4th = new System.Windows.Forms.CheckBox();
            this.chkMajor3rd = new System.Windows.Forms.CheckBox();
            this.chkMinor3rd = new System.Windows.Forms.CheckBox();
            this.chkMajor2nd = new System.Windows.Forms.CheckBox();
            this.chkMinor2nd = new System.Windows.Forms.CheckBox();
            this.chkRoot = new System.Windows.Forms.CheckBox();
            this.nudBars = new System.Windows.Forms.NumericUpDown();
            this.chkAllNoteValues = new System.Windows.Forms.CheckBox();
            this.chkAllIntervals = new System.Windows.Forms.CheckBox();
            this.gbNoteValues.SuspendLayout();
            this.gbIntervals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBars)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlTimeSignature
            // 
            this.ddlTimeSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimeSignature.FormattingEnabled = true;
            this.ddlTimeSignature.Items.AddRange(new object[] {
            "1/4",
            "2/4",
            "3/4",
            "4/4",
            "5/4",
            "6/4",
            "7/4"});
            this.ddlTimeSignature.Location = new System.Drawing.Point(99, 6);
            this.ddlTimeSignature.Name = "ddlTimeSignature";
            this.ddlTimeSignature.Size = new System.Drawing.Size(54, 21);
            this.ddlTimeSignature.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Signature:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# of Bars:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(164, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(188, 47);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gbNoteValues
            // 
            this.gbNoteValues.Controls.Add(this.chkAllNoteValues);
            this.gbNoteValues.Controls.Add(this.chk64);
            this.gbNoteValues.Controls.Add(this.chk32);
            this.gbNoteValues.Controls.Add(this.chk16);
            this.gbNoteValues.Controls.Add(this.chk8);
            this.gbNoteValues.Controls.Add(this.chkQuarter);
            this.gbNoteValues.Controls.Add(this.chkHalf);
            this.gbNoteValues.Controls.Add(this.chkWhole);
            this.gbNoteValues.Location = new System.Drawing.Point(15, 59);
            this.gbNoteValues.Name = "gbNoteValues";
            this.gbNoteValues.Size = new System.Drawing.Size(107, 206);
            this.gbNoteValues.TabIndex = 4;
            this.gbNoteValues.TabStop = false;
            this.gbNoteValues.Text = "Note Values Used";
            // 
            // chk64
            // 
            this.chk64.AutoSize = true;
            this.chk64.Location = new System.Drawing.Point(6, 180);
            this.chk64.Name = "chk64";
            this.chk64.Size = new System.Drawing.Size(49, 17);
            this.chk64.TabIndex = 7;
            this.chk64.Text = "1/64";
            this.chk64.UseVisualStyleBackColor = true;
            // 
            // chk32
            // 
            this.chk32.AutoSize = true;
            this.chk32.Location = new System.Drawing.Point(6, 157);
            this.chk32.Name = "chk32";
            this.chk32.Size = new System.Drawing.Size(49, 17);
            this.chk32.TabIndex = 6;
            this.chk32.Text = "1/32";
            this.chk32.UseVisualStyleBackColor = true;
            // 
            // chk16
            // 
            this.chk16.AutoSize = true;
            this.chk16.Location = new System.Drawing.Point(6, 134);
            this.chk16.Name = "chk16";
            this.chk16.Size = new System.Drawing.Size(49, 17);
            this.chk16.TabIndex = 5;
            this.chk16.Text = "1/16";
            this.chk16.UseVisualStyleBackColor = true;
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.Location = new System.Drawing.Point(6, 111);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(43, 17);
            this.chk8.TabIndex = 4;
            this.chk8.Text = "1/8";
            this.chk8.UseVisualStyleBackColor = true;
            // 
            // chkQuarter
            // 
            this.chkQuarter.AutoSize = true;
            this.chkQuarter.Location = new System.Drawing.Point(6, 88);
            this.chkQuarter.Name = "chkQuarter";
            this.chkQuarter.Size = new System.Drawing.Size(61, 17);
            this.chkQuarter.TabIndex = 3;
            this.chkQuarter.Text = "Quarter";
            this.chkQuarter.UseVisualStyleBackColor = true;
            // 
            // chkHalf
            // 
            this.chkHalf.AutoSize = true;
            this.chkHalf.Location = new System.Drawing.Point(6, 65);
            this.chkHalf.Name = "chkHalf";
            this.chkHalf.Size = new System.Drawing.Size(45, 17);
            this.chkHalf.TabIndex = 2;
            this.chkHalf.Text = "Half";
            this.chkHalf.UseVisualStyleBackColor = true;
            // 
            // chkWhole
            // 
            this.chkWhole.AutoSize = true;
            this.chkWhole.Location = new System.Drawing.Point(6, 42);
            this.chkWhole.Name = "chkWhole";
            this.chkWhole.Size = new System.Drawing.Size(57, 17);
            this.chkWhole.TabIndex = 1;
            this.chkWhole.Text = "Whole";
            this.chkWhole.UseVisualStyleBackColor = true;
            // 
            // gbIntervals
            // 
            this.gbIntervals.Controls.Add(this.chkAllIntervals);
            this.gbIntervals.Controls.Add(this.chkMajor7th);
            this.gbIntervals.Controls.Add(this.chkMinor7th);
            this.gbIntervals.Controls.Add(this.chkMajor6th);
            this.gbIntervals.Controls.Add(this.chkMinor6th);
            this.gbIntervals.Controls.Add(this.chkPerfect5th);
            this.gbIntervals.Controls.Add(this.chkTritone);
            this.gbIntervals.Controls.Add(this.chkPerfect4th);
            this.gbIntervals.Controls.Add(this.chkMajor3rd);
            this.gbIntervals.Controls.Add(this.chkMinor3rd);
            this.gbIntervals.Controls.Add(this.chkMajor2nd);
            this.gbIntervals.Controls.Add(this.chkMinor2nd);
            this.gbIntervals.Controls.Add(this.chkRoot);
            this.gbIntervals.Location = new System.Drawing.Point(133, 59);
            this.gbIntervals.Name = "gbIntervals";
            this.gbIntervals.Size = new System.Drawing.Size(219, 206);
            this.gbIntervals.TabIndex = 5;
            this.gbIntervals.TabStop = false;
            this.gbIntervals.Text = "Intervals Used";
            // 
            // chkMajor7th
            // 
            this.chkMajor7th.AutoSize = true;
            this.chkMajor7th.Location = new System.Drawing.Point(119, 157);
            this.chkMajor7th.Name = "chkMajor7th";
            this.chkMajor7th.Size = new System.Drawing.Size(91, 17);
            this.chkMajor7th.TabIndex = 12;
            this.chkMajor7th.Text = "11 - Major 7th";
            this.chkMajor7th.UseVisualStyleBackColor = true;
            // 
            // chkMinor7th
            // 
            this.chkMinor7th.AutoSize = true;
            this.chkMinor7th.Location = new System.Drawing.Point(119, 134);
            this.chkMinor7th.Name = "chkMinor7th";
            this.chkMinor7th.Size = new System.Drawing.Size(91, 17);
            this.chkMinor7th.TabIndex = 11;
            this.chkMinor7th.Text = "10 - Minor 7th";
            this.chkMinor7th.UseVisualStyleBackColor = true;
            // 
            // chkMajor6th
            // 
            this.chkMajor6th.AutoSize = true;
            this.chkMajor6th.Location = new System.Drawing.Point(119, 111);
            this.chkMajor6th.Name = "chkMajor6th";
            this.chkMajor6th.Size = new System.Drawing.Size(85, 17);
            this.chkMajor6th.TabIndex = 10;
            this.chkMajor6th.Text = "9 - Major 6th";
            this.chkMajor6th.UseVisualStyleBackColor = true;
            // 
            // chkMinor6th
            // 
            this.chkMinor6th.AutoSize = true;
            this.chkMinor6th.Location = new System.Drawing.Point(119, 88);
            this.chkMinor6th.Name = "chkMinor6th";
            this.chkMinor6th.Size = new System.Drawing.Size(85, 17);
            this.chkMinor6th.TabIndex = 9;
            this.chkMinor6th.Text = "8 - Minor 6th";
            this.chkMinor6th.UseVisualStyleBackColor = true;
            // 
            // chkPerfect5th
            // 
            this.chkPerfect5th.AutoSize = true;
            this.chkPerfect5th.Location = new System.Drawing.Point(119, 65);
            this.chkPerfect5th.Name = "chkPerfect5th";
            this.chkPerfect5th.Size = new System.Drawing.Size(93, 17);
            this.chkPerfect5th.TabIndex = 8;
            this.chkPerfect5th.Text = "7 - Perfect 5th";
            this.chkPerfect5th.UseVisualStyleBackColor = true;
            // 
            // chkTritone
            // 
            this.chkTritone.AutoSize = true;
            this.chkTritone.Location = new System.Drawing.Point(119, 42);
            this.chkTritone.Name = "chkTritone";
            this.chkTritone.Size = new System.Drawing.Size(74, 17);
            this.chkTritone.TabIndex = 7;
            this.chkTritone.Text = "6 - Tritone";
            this.chkTritone.UseVisualStyleBackColor = true;
            // 
            // chkPerfect4th
            // 
            this.chkPerfect4th.AutoSize = true;
            this.chkPerfect4th.Location = new System.Drawing.Point(6, 157);
            this.chkPerfect4th.Name = "chkPerfect4th";
            this.chkPerfect4th.Size = new System.Drawing.Size(93, 17);
            this.chkPerfect4th.TabIndex = 6;
            this.chkPerfect4th.Text = "5 - Perfect 4th";
            this.chkPerfect4th.UseVisualStyleBackColor = true;
            // 
            // chkMajor3rd
            // 
            this.chkMajor3rd.AutoSize = true;
            this.chkMajor3rd.Location = new System.Drawing.Point(6, 134);
            this.chkMajor3rd.Name = "chkMajor3rd";
            this.chkMajor3rd.Size = new System.Drawing.Size(94, 17);
            this.chkMajor3rd.TabIndex = 5;
            this.chkMajor3rd.Text = "4 - Major Third";
            this.chkMajor3rd.UseVisualStyleBackColor = true;
            // 
            // chkMinor3rd
            // 
            this.chkMinor3rd.AutoSize = true;
            this.chkMinor3rd.Location = new System.Drawing.Point(6, 111);
            this.chkMinor3rd.Name = "chkMinor3rd";
            this.chkMinor3rd.Size = new System.Drawing.Size(85, 17);
            this.chkMinor3rd.TabIndex = 4;
            this.chkMinor3rd.Text = "3 - Minor 3rd";
            this.chkMinor3rd.UseVisualStyleBackColor = true;
            // 
            // chkMajor2nd
            // 
            this.chkMajor2nd.AutoSize = true;
            this.chkMajor2nd.Location = new System.Drawing.Point(6, 88);
            this.chkMajor2nd.Name = "chkMajor2nd";
            this.chkMajor2nd.Size = new System.Drawing.Size(88, 17);
            this.chkMajor2nd.TabIndex = 3;
            this.chkMajor2nd.Text = "2 - Major 2nd";
            this.chkMajor2nd.UseVisualStyleBackColor = true;
            // 
            // chkMinor2nd
            // 
            this.chkMinor2nd.AutoSize = true;
            this.chkMinor2nd.Location = new System.Drawing.Point(6, 65);
            this.chkMinor2nd.Name = "chkMinor2nd";
            this.chkMinor2nd.Size = new System.Drawing.Size(88, 17);
            this.chkMinor2nd.TabIndex = 2;
            this.chkMinor2nd.Text = "1 - Minor 2nd";
            this.chkMinor2nd.UseVisualStyleBackColor = true;
            // 
            // chkRoot
            // 
            this.chkRoot.AutoSize = true;
            this.chkRoot.Location = new System.Drawing.Point(6, 42);
            this.chkRoot.Name = "chkRoot";
            this.chkRoot.Size = new System.Drawing.Size(64, 17);
            this.chkRoot.TabIndex = 1;
            this.chkRoot.Text = "0 - Root";
            this.chkRoot.UseVisualStyleBackColor = true;
            // 
            // nudBars
            // 
            this.nudBars.Location = new System.Drawing.Point(99, 33);
            this.nudBars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBars.Name = "nudBars";
            this.nudBars.ReadOnly = true;
            this.nudBars.Size = new System.Drawing.Size(54, 20);
            this.nudBars.TabIndex = 3;
            this.nudBars.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkAllNoteValues
            // 
            this.chkAllNoteValues.AutoSize = true;
            this.chkAllNoteValues.Location = new System.Drawing.Point(7, 19);
            this.chkAllNoteValues.Name = "chkAllNoteValues";
            this.chkAllNoteValues.Size = new System.Drawing.Size(70, 17);
            this.chkAllNoteValues.TabIndex = 0;
            this.chkAllNoteValues.Text = "Select All";
            this.chkAllNoteValues.UseVisualStyleBackColor = true;
            this.chkAllNoteValues.CheckedChanged += new System.EventHandler(this.chkAllNoteValues_CheckedChanged);
            // 
            // chkAllIntervals
            // 
            this.chkAllIntervals.AutoSize = true;
            this.chkAllIntervals.Location = new System.Drawing.Point(7, 19);
            this.chkAllIntervals.Name = "chkAllIntervals";
            this.chkAllIntervals.Size = new System.Drawing.Size(70, 17);
            this.chkAllIntervals.TabIndex = 0;
            this.chkAllIntervals.Text = "Select All";
            this.chkAllIntervals.UseVisualStyleBackColor = true;
            this.chkAllIntervals.CheckedChanged += new System.EventHandler(this.chkAllIntervals_CheckedChanged);
            // 
            // RiffGenerator
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 279);
            this.Controls.Add(this.nudBars);
            this.Controls.Add(this.gbIntervals);
            this.Controls.Add(this.gbNoteValues);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlTimeSignature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RiffGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Riff Generator";
            this.gbNoteValues.ResumeLayout(false);
            this.gbNoteValues.PerformLayout();
            this.gbIntervals.ResumeLayout(false);
            this.gbIntervals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTimeSignature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbNoteValues;
        private System.Windows.Forms.CheckBox chk64;
        private System.Windows.Forms.CheckBox chk32;
        private System.Windows.Forms.CheckBox chk16;
        private System.Windows.Forms.CheckBox chk8;
        private System.Windows.Forms.CheckBox chkQuarter;
        private System.Windows.Forms.CheckBox chkHalf;
        private System.Windows.Forms.CheckBox chkWhole;
        private System.Windows.Forms.GroupBox gbIntervals;
        private System.Windows.Forms.CheckBox chkMajor7th;
        private System.Windows.Forms.CheckBox chkMinor7th;
        private System.Windows.Forms.CheckBox chkMajor6th;
        private System.Windows.Forms.CheckBox chkMinor6th;
        private System.Windows.Forms.CheckBox chkPerfect5th;
        private System.Windows.Forms.CheckBox chkTritone;
        private System.Windows.Forms.CheckBox chkPerfect4th;
        private System.Windows.Forms.CheckBox chkMajor3rd;
        private System.Windows.Forms.CheckBox chkMinor3rd;
        private System.Windows.Forms.CheckBox chkMajor2nd;
        private System.Windows.Forms.CheckBox chkMinor2nd;
        private System.Windows.Forms.CheckBox chkRoot;
        private System.Windows.Forms.NumericUpDown nudBars;
        private System.Windows.Forms.CheckBox chkAllNoteValues;
        private System.Windows.Forms.CheckBox chkAllIntervals;

    }
}