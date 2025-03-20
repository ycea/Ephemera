namespace Ephemera
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sandBox = new PictureBox();
            panel1 = new Panel();
            CurrentElement = new Label();
            FireButton = new Button();
            WaterButton = new Button();
            Stone = new Button();
            SoilButton = new Button();
            label2 = new Label();
            elementSizeNumericUpDown = new NumericUpDown();
            stopGameButton = new Button();
            startGameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)sandBox).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)elementSizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // sandBox
            // 
            sandBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sandBox.BorderStyle = BorderStyle.FixedSingle;
            sandBox.Location = new Point(12, 24);
            sandBox.Name = "sandBox";
            sandBox.Size = new Size(639, 545);
            sandBox.TabIndex = 0;
            sandBox.TabStop = false;
            sandBox.MouseDown += sandBox_MouseDown;
            sandBox.MouseMove += sandBox_MouseMove;
            sandBox.MouseUp += sandBox_MouseUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(CurrentElement);
            panel1.Controls.Add(FireButton);
            panel1.Controls.Add(WaterButton);
            panel1.Controls.Add(Stone);
            panel1.Controls.Add(SoilButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(elementSizeNumericUpDown);
            panel1.Controls.Add(stopGameButton);
            panel1.Controls.Add(startGameButton);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(671, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(249, 593);
            panel1.TabIndex = 1;
            // 
            // CurrentElement
            // 
            CurrentElement.AutoSize = true;
            CurrentElement.Location = new Point(31, 17);
            CurrentElement.Name = "CurrentElement";
            CurrentElement.Size = new Size(133, 20);
            CurrentElement.TabIndex = 10;
            CurrentElement.Text = "Текущий элемент:";
            // 
            // FireButton
            // 
            FireButton.BackColor = Color.Red;
            FireButton.Location = new Point(78, 106);
            FireButton.Name = "FireButton";
            FireButton.Size = new Size(38, 30);
            FireButton.TabIndex = 9;
            FireButton.UseVisualStyleBackColor = false;
            FireButton.Click += FireButton_Click;
            // 
            // WaterButton
            // 
            WaterButton.BackColor = Color.CornflowerBlue;
            WaterButton.Location = new Point(78, 53);
            WaterButton.Name = "WaterButton";
            WaterButton.Size = new Size(38, 33);
            WaterButton.TabIndex = 8;
            WaterButton.UseVisualStyleBackColor = false;
            WaterButton.Click += WaterButton_Click;
            // 
            // Stone
            // 
            Stone.BackColor = SystemColors.ControlDark;
            Stone.Location = new Point(31, 106);
            Stone.Name = "Stone";
            Stone.Size = new Size(41, 30);
            Stone.TabIndex = 7;
            Stone.UseVisualStyleBackColor = false;
            Stone.Click += Stone_Click;
            // 
            // SoilButton
            // 
            SoilButton.BackColor = Color.SaddleBrown;
            SoilButton.Location = new Point(31, 53);
            SoilButton.Name = "SoilButton";
            SoilButton.Size = new Size(41, 33);
            SoilButton.TabIndex = 6;
            SoilButton.UseVisualStyleBackColor = false;
            SoilButton.Click += SoilButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 330);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 5;
            label2.Text = "Размер элемента";
            // 
            // elementSizeNumericUpDown
            // 
            elementSizeNumericUpDown.Location = new Point(47, 370);
            elementSizeNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            elementSizeNumericUpDown.Name = "elementSizeNumericUpDown";
            elementSizeNumericUpDown.Size = new Size(150, 27);
            elementSizeNumericUpDown.TabIndex = 4;
            elementSizeNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // stopGameButton
            // 
            stopGameButton.BackgroundImage = (Image)resources.GetObject("stopGameButton.BackgroundImage");
            stopGameButton.BackgroundImageLayout = ImageLayout.Stretch;
            stopGameButton.Location = new Point(31, 253);
            stopGameButton.Name = "stopGameButton";
            stopGameButton.Size = new Size(65, 52);
            stopGameButton.TabIndex = 3;
            stopGameButton.UseVisualStyleBackColor = true;
            stopGameButton.Click += stopGameButton_Click;
            // 
            // startGameButton
            // 
            startGameButton.BackgroundImage = (Image)resources.GetObject("startGameButton.BackgroundImage");
            startGameButton.BackgroundImageLayout = ImageLayout.Stretch;
            startGameButton.Location = new Point(31, 174);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(65, 41);
            startGameButton.TabIndex = 2;
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 593);
            Controls.Add(panel1);
            Controls.Add(sandBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "Ephemera";
            ((System.ComponentModel.ISupportInitialize)sandBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)elementSizeNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox sandBox;
        private Panel panel1;
        private Button startGameButton;
        private Button stopGameButton;
        private NumericUpDown elementSizeNumericUpDown;
        private Label label2;
        private Button FireButton;
        private Button WaterButton;
        private Button Stone;
        private Button SoilButton;
        private Label CurrentElement;
    }
}
