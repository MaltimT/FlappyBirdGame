namespace FlappyBird
{
    partial class Form1
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDown = new System.Windows.Forms.CheckBox();
            this.rbLeft = new System.Windows.Forms.CheckBox();
            this.rbUp = new System.Windows.Forms.CheckBox();
            this.rbRight = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnlControls.Controls.Add(this.tbSpeed);
            this.pnlControls.Controls.Add(this.btnStart);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.rbDown);
            this.pnlControls.Controls.Add(this.rbLeft);
            this.pnlControls.Controls.Add(this.rbUp);
            this.pnlControls.Controls.Add(this.rbRight);
            this.pnlControls.Location = new System.Drawing.Point(476, 35);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(542, 551);
            this.pnlControls.TabIndex = 0;
            // 
            // tbSpeed
            // 
            this.tbSpeed.BackColor = System.Drawing.Color.DarkViolet;
            this.tbSpeed.Location = new System.Drawing.Point(186, 281);
            this.tbSpeed.Maximum = 40;
            this.tbSpeed.Minimum = 20;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(167, 45);
            this.tbSpeed.TabIndex = 7;
            this.tbSpeed.Value = 40;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkViolet;
            this.btnStart.Location = new System.Drawing.Point(186, 344);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(167, 101);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(200, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose your maximum speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(220, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose your direction";
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.BackColor = System.Drawing.Color.DarkViolet;
            this.rbDown.Location = new System.Drawing.Point(336, 165);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(54, 17);
            this.rbDown.TabIndex = 3;
            this.rbDown.Text = "Down";
            this.rbDown.UseVisualStyleBackColor = false;
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.BackColor = System.Drawing.Color.DarkViolet;
            this.rbLeft.Location = new System.Drawing.Point(151, 208);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(44, 17);
            this.rbLeft.TabIndex = 2;
            this.rbLeft.Text = "Left";
            this.rbLeft.UseVisualStyleBackColor = false;
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.BackColor = System.Drawing.Color.DarkViolet;
            this.rbUp.Location = new System.Drawing.Point(336, 208);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(40, 17);
            this.rbUp.TabIndex = 1;
            this.rbUp.Text = "Up";
            this.rbUp.UseVisualStyleBackColor = false;
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.BackColor = System.Drawing.Color.DarkViolet;
            this.rbRight.Location = new System.Drawing.Point(151, 165);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(51, 17);
            this.rbRight.TabIndex = 0;
            this.rbRight.Text = "Right";
            this.rbRight.UseVisualStyleBackColor = false;
            // 
            // timer
            // 
            this.timer.Interval = 33;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1284, 639);
            this.Controls.Add(this.pnlControls);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rbDown;
        private System.Windows.Forms.CheckBox rbLeft;
        private System.Windows.Forms.CheckBox rbUp;
        private System.Windows.Forms.CheckBox rbRight;
        private System.Windows.Forms.Timer timer;
    }
}

