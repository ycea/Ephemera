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
            sandBox = new PictureBox();
            panel1 = new Panel();
            elementSizeNumericUpDown = new NumericUpDown();
            stopGameButton = new Button();
            startGameButton = new Button();
            label1 = new Label();
            comboBoxElements = new ComboBox();
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
            sandBox.Size = new Size(588, 483);
            sandBox.TabIndex = 0;
            sandBox.TabStop = false;
            sandBox.MouseClick += sandBox_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(elementSizeNumericUpDown);
            panel1.Controls.Add(stopGameButton);
            panel1.Controls.Add(startGameButton);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBoxElements);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(620, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(249, 531);
            panel1.TabIndex = 1;
            // 
            // elementSizeNumericUpDown
            // 
            elementSizeNumericUpDown.Location = new Point(34, 225);
            elementSizeNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            elementSizeNumericUpDown.Name = "elementSizeNumericUpDown";
            elementSizeNumericUpDown.Size = new Size(150, 27);
            elementSizeNumericUpDown.TabIndex = 4;
            elementSizeNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // stopGameButton
            // 
            stopGameButton.Location = new Point(22, 159);
            stopGameButton.Name = "stopGameButton";
            stopGameButton.Size = new Size(194, 29);
            stopGameButton.TabIndex = 3;
            stopGameButton.Text = "Уничтожить жизнь";
            stopGameButton.UseVisualStyleBackColor = true;
            stopGameButton.Click += stopGameButton_Click;
            // 
            // startGameButton
            // 
            startGameButton.Location = new Point(22, 104);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(194, 29);
            startGameButton.TabIndex = 2;
            startGameButton.Text = "Запустить жизнь";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 10);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 1;
            label1.Text = "Выбор элемента";
            // 
            // comboBoxElements
            // 
            comboBoxElements.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxElements.FormattingEnabled = true;
            comboBoxElements.Items.AddRange(new object[] { "Огонь", "Вода", "Земля", "Камень" });
            comboBoxElements.Location = new Point(22, 38);
            comboBoxElements.Name = "comboBoxElements";
            comboBoxElements.Size = new Size(194, 28);
            comboBoxElements.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 531);
            Controls.Add(panel1);
            Controls.Add(sandBox);
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
        private ComboBox comboBoxElements;
        private Label label1;
        private Button startGameButton;
        private Button stopGameButton;
        private NumericUpDown elementSizeNumericUpDown;
    }
}
