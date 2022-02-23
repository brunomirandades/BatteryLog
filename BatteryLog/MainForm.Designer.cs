namespace BatteryLog
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.GeneralLogListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.slot5Button = new System.Windows.Forms.Button();
            this.slot4Button = new System.Windows.Forms.Button();
            this.slot3Button = new System.Windows.Forms.Button();
            this.slot2Button = new System.Windows.Forms.Button();
            this.slot1Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.testConfigBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.measDataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.currentMeasLabel = new System.Windows.Forms.Label();
            this.voltageMeasLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.stopTestButton = new System.Windows.Forms.Button();
            this.startTestButton = new System.Windows.Forms.Button();
            this.testConfigButton = new System.Windows.Forms.Button();
            this.baudrateComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comPortComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.currentInputTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.voltageInputTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.testTimeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.slotTitleLabel = new System.Windows.Forms.Label();
            this.testMeasurementBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.addProjectBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.GeneralLogListBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 527);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 118);
            this.panel2.TabIndex = 1;
            // 
            // GeneralLogListBox
            // 
            this.GeneralLogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralLogListBox.FormattingEnabled = true;
            this.GeneralLogListBox.Location = new System.Drawing.Point(12, 22);
            this.GeneralLogListBox.Name = "GeneralLogListBox";
            this.GeneralLogListBox.Size = new System.Drawing.Size(821, 82);
            this.GeneralLogListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "General Log";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.slot5Button);
            this.panel3.Controls.Add(this.slot4Button);
            this.panel3.Controls.Add(this.slot3Button);
            this.panel3.Controls.Add(this.slot2Button);
            this.panel3.Controls.Add(this.slot1Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 449);
            this.panel3.TabIndex = 2;
            // 
            // slot5Button
            // 
            this.slot5Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slot5Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.slot5Button.FlatAppearance.BorderSize = 0;
            this.slot5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot5Button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slot5Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.slot5Button.Location = new System.Drawing.Point(0, 200);
            this.slot5Button.Name = "slot5Button";
            this.slot5Button.Size = new System.Drawing.Size(135, 50);
            this.slot5Button.TabIndex = 4;
            this.slot5Button.Text = "Slot 5";
            this.slot5Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slot5Button.UseVisualStyleBackColor = false;
            this.slot5Button.Click += new System.EventHandler(this.slot5Button_Click);
            // 
            // slot4Button
            // 
            this.slot4Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slot4Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.slot4Button.FlatAppearance.BorderSize = 0;
            this.slot4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot4Button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slot4Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.slot4Button.Location = new System.Drawing.Point(0, 150);
            this.slot4Button.Name = "slot4Button";
            this.slot4Button.Size = new System.Drawing.Size(135, 50);
            this.slot4Button.TabIndex = 3;
            this.slot4Button.Text = "Slot 4";
            this.slot4Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slot4Button.UseVisualStyleBackColor = false;
            this.slot4Button.Click += new System.EventHandler(this.slot4Button_Click);
            // 
            // slot3Button
            // 
            this.slot3Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slot3Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.slot3Button.FlatAppearance.BorderSize = 0;
            this.slot3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot3Button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slot3Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.slot3Button.Location = new System.Drawing.Point(0, 100);
            this.slot3Button.Name = "slot3Button";
            this.slot3Button.Size = new System.Drawing.Size(135, 50);
            this.slot3Button.TabIndex = 2;
            this.slot3Button.Text = "Slot 3";
            this.slot3Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slot3Button.UseVisualStyleBackColor = false;
            this.slot3Button.Click += new System.EventHandler(this.slot3Button_Click);
            // 
            // slot2Button
            // 
            this.slot2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slot2Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.slot2Button.FlatAppearance.BorderSize = 0;
            this.slot2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot2Button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slot2Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.slot2Button.Location = new System.Drawing.Point(0, 50);
            this.slot2Button.Name = "slot2Button";
            this.slot2Button.Size = new System.Drawing.Size(135, 50);
            this.slot2Button.TabIndex = 1;
            this.slot2Button.Text = "Slot 2";
            this.slot2Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slot2Button.UseVisualStyleBackColor = false;
            this.slot2Button.Click += new System.EventHandler(this.slot2Button_Click);
            // 
            // slot1Button
            // 
            this.slot1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slot1Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.slot1Button.FlatAppearance.BorderSize = 0;
            this.slot1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slot1Button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slot1Button.ForeColor = System.Drawing.Color.Gainsboro;
            this.slot1Button.Location = new System.Drawing.Point(0, 0);
            this.slot1Button.Name = "slot1Button";
            this.slot1Button.Size = new System.Drawing.Size(135, 50);
            this.slot1Button.TabIndex = 0;
            this.slot1Button.Text = "Slot 1";
            this.slot1Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.slot1Button.UseVisualStyleBackColor = false;
            this.slot1Button.Click += new System.EventHandler(this.slot1Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = global::BatteryLog.Properties.Resources.Battery;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "        Battery Log";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 78);
            this.panel1.TabIndex = 0;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 15000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // testConfigBackgroundWorker
            // 
            this.testConfigBackgroundWorker.WorkerSupportsCancellation = true;
            this.testConfigBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testConfigBackgroundWorker_DoWork);
            this.testConfigBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testConfigBackgroundWorker_RunWorkerCompleted);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.panel6);
            this.controlPanel.Controls.Add(this.panel5);
            this.controlPanel.Controls.Add(this.panel4);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(135, 78);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(710, 449);
            this.controlPanel.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.clearButton);
            this.panel6.Controls.Add(this.exportButton);
            this.panel6.Controls.Add(this.measDataGridView);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(180, 194);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(530, 255);
            this.panel6.TabIndex = 14;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(265, 225);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 33;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exportButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(184, 225);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 32;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // measDataGridView
            // 
            this.measDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.measDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.measDataGridView.Location = new System.Drawing.Point(6, 6);
            this.measDataGridView.Name = "measDataGridView";
            this.measDataGridView.Size = new System.Drawing.Size(512, 213);
            this.measDataGridView.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.timeLeftLabel);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.startDateLabel);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 194);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 255);
            this.panel5.TabIndex = 13;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Controls.Add(this.currentMeasLabel);
            this.panel7.Controls.Add(this.voltageMeasLabel);
            this.panel7.Location = new System.Drawing.Point(14, 191);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(157, 38);
            this.panel7.TabIndex = 6;
            // 
            // currentMeasLabel
            // 
            this.currentMeasLabel.AutoSize = true;
            this.currentMeasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMeasLabel.ForeColor = System.Drawing.Color.Yellow;
            this.currentMeasLabel.Location = new System.Drawing.Point(80, 9);
            this.currentMeasLabel.Name = "currentMeasLabel";
            this.currentMeasLabel.Size = new System.Drawing.Size(71, 20);
            this.currentMeasLabel.TabIndex = 1;
            this.currentMeasLabel.Text = "99.99 A";
            this.currentMeasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voltageMeasLabel
            // 
            this.voltageMeasLabel.AutoSize = true;
            this.voltageMeasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voltageMeasLabel.ForeColor = System.Drawing.Color.Yellow;
            this.voltageMeasLabel.Location = new System.Drawing.Point(2, 9);
            this.voltageMeasLabel.Name = "voltageMeasLabel";
            this.voltageMeasLabel.Size = new System.Drawing.Size(71, 20);
            this.voltageMeasLabel.TabIndex = 0;
            this.voltageMeasLabel.Text = "99.99 V";
            this.voltageMeasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(59, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 17);
            this.label17.TabIndex = 5;
            this.label17.Text = "Test Info";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(42, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 17);
            this.label16.TabIndex = 4;
            this.label16.Text = "Battery Output";
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeftLabel.Location = new System.Drawing.Point(94, 103);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(69, 39);
            this.timeLeftLabel.TabIndex = 3;
            this.timeLeftLabel.Text = "dd days\nhh hours\nmm minutes";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Test time left:";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDateLabel.Location = new System.Drawing.Point(94, 58);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(69, 26);
            this.startDateLabel.TabIndex = 1;
            this.startDateLabel.Text = "dd/MM/yyyy\nhh:mm";
            this.startDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(32, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Started at:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Controls.Add(this.stopTestButton);
            this.panel4.Controls.Add(this.startTestButton);
            this.panel4.Controls.Add(this.testConfigButton);
            this.panel4.Controls.Add(this.baudrateComboBox);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.comPortComboBox);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.currentInputTextBox);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.voltageInputTextBox);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.intervalTextBox);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.testTimeTextBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.projectNameTextBox);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.slotTitleLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(710, 194);
            this.panel4.TabIndex = 12;
            // 
            // stopTestButton
            // 
            this.stopTestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.stopTestButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopTestButton.Location = new System.Drawing.Point(415, 159);
            this.stopTestButton.Name = "stopTestButton";
            this.stopTestButton.Size = new System.Drawing.Size(75, 23);
            this.stopTestButton.TabIndex = 27;
            this.stopTestButton.Text = "Stop";
            this.stopTestButton.UseVisualStyleBackColor = true;
            this.stopTestButton.Click += new System.EventHandler(this.stopTestButton_Click);
            // 
            // startTestButton
            // 
            this.startTestButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startTestButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTestButton.Location = new System.Drawing.Point(334, 159);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(75, 23);
            this.startTestButton.TabIndex = 26;
            this.startTestButton.Text = "Start";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // testConfigButton
            // 
            this.testConfigButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.testConfigButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testConfigButton.Location = new System.Drawing.Point(253, 159);
            this.testConfigButton.Name = "testConfigButton";
            this.testConfigButton.Size = new System.Drawing.Size(75, 23);
            this.testConfigButton.TabIndex = 25;
            this.testConfigButton.Text = "Test Config";
            this.testConfigButton.UseVisualStyleBackColor = true;
            this.testConfigButton.Click += new System.EventHandler(this.testConfigButton_Click);
            // 
            // baudrateComboBox
            // 
            this.baudrateComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.baudrateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudrateComboBox.FormattingEnabled = true;
            this.baudrateComboBox.Location = new System.Drawing.Point(335, 122);
            this.baudrateComboBox.Name = "baudrateComboBox";
            this.baudrateComboBox.Size = new System.Drawing.Size(121, 21);
            this.baudrateComboBox.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(276, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Baudrate:";
            // 
            // comPortComboBox
            // 
            this.comPortComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortComboBox.FormattingEnabled = true;
            this.comPortComboBox.Location = new System.Drawing.Point(335, 91);
            this.comPortComboBox.Name = "comPortComboBox";
            this.comPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.comPortComboBox.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(300, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Port:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(618, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "A";
            // 
            // currentInputTextBox
            // 
            this.currentInputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.currentInputTextBox.Location = new System.Drawing.Point(569, 122);
            this.currentInputTextBox.Name = "currentInputTextBox";
            this.currentInputTextBox.Size = new System.Drawing.Size(43, 20);
            this.currentInputTextBox.TabIndex = 19;
            this.currentInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(519, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Current:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(618, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "V";
            // 
            // voltageInputTextBox
            // 
            this.voltageInputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.voltageInputTextBox.Location = new System.Drawing.Point(569, 91);
            this.voltageInputTextBox.Name = "voltageInputTextBox";
            this.voltageInputTextBox.Size = new System.Drawing.Size(43, 20);
            this.voltageInputTextBox.TabIndex = 16;
            this.voltageInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(517, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Voltage:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(196, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Minutes";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.intervalTextBox.Location = new System.Drawing.Point(147, 122);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(43, 20);
            this.intervalTextBox.TabIndex = 13;
            this.intervalTextBox.Text = "10";
            this.intervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Reg. Interval:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(196, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hours";
            // 
            // testTimeTextBox
            // 
            this.testTimeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.testTimeTextBox.Location = new System.Drawing.Point(147, 91);
            this.testTimeTextBox.Name = "testTimeTextBox";
            this.testTimeTextBox.Size = new System.Drawing.Size(43, 20);
            this.testTimeTextBox.TabIndex = 10;
            this.testTimeTextBox.Text = "168";
            this.testTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Test Time:";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.projectNameTextBox.Location = new System.Drawing.Point(147, 61);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(487, 20);
            this.projectNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project Name:";
            // 
            // slotTitleLabel
            // 
            this.slotTitleLabel.AutoSize = true;
            this.slotTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotTitleLabel.Location = new System.Drawing.Point(18, 16);
            this.slotTitleLabel.Name = "slotTitleLabel";
            this.slotTitleLabel.Size = new System.Drawing.Size(64, 30);
            this.slotTitleLabel.TabIndex = 0;
            this.slotTitleLabel.Text = "Slot 1";
            // 
            // testMeasurementBackgroundWorker
            // 
            this.testMeasurementBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testMeasurementBackgroundWorker_DoWork);
            // 
            // addProjectBackgroundWorker
            // 
            this.addProjectBackgroundWorker.WorkerSupportsCancellation = true;
            this.addProjectBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.addProjectBackgroundWorker_DoWork);
            this.addProjectBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.addProjectBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 645);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BatteryLog v1.00";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.measDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox GeneralLogListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button slot1Button;
        private System.Windows.Forms.Button slot5Button;
        private System.Windows.Forms.Button slot4Button;
        private System.Windows.Forms.Button slot3Button;
        private System.Windows.Forms.Button slot2Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer updateTimer;
        private System.ComponentModel.BackgroundWorker testConfigBackgroundWorker;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridView measDataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label currentMeasLabel;
        private System.Windows.Forms.Label voltageMeasLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button stopTestButton;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Button testConfigButton;
        private System.Windows.Forms.ComboBox baudrateComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox currentInputTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox voltageInputTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox testTimeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label slotTitleLabel;
        private System.ComponentModel.BackgroundWorker testMeasurementBackgroundWorker;
        private System.ComponentModel.BackgroundWorker addProjectBackgroundWorker;
    }
}

