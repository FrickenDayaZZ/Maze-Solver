namespace visualtrees
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
            this.SolveMaze = new System.Windows.Forms.Button();
            this.imgBoxTree = new Emgu.CV.UI.ImageBox();
            this.btnCreateMaze = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadMaze = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.txtStartingSquare = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtEndSquare = new System.Windows.Forms.TextBox();
            this.Prims = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxTree)).BeginInit();
            this.SuspendLayout();
            // 
            // SolveMaze
            // 
            this.SolveMaze.Location = new System.Drawing.Point(638, 12);
            this.SolveMaze.Name = "SolveMaze";
            this.SolveMaze.Size = new System.Drawing.Size(150, 23);
            this.SolveMaze.TabIndex = 5;
            this.SolveMaze.Text = "Render the maze in question\r\n\r\n\r\n\r\n";
            this.SolveMaze.UseVisualStyleBackColor = true;
            this.SolveMaze.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // imgBoxTree
            // 
            this.imgBoxTree.Location = new System.Drawing.Point(1161, 481);
            this.imgBoxTree.Name = "imgBoxTree";
            this.imgBoxTree.Size = new System.Drawing.Size(75, 23);
            this.imgBoxTree.TabIndex = 2;
            this.imgBoxTree.TabStop = false;
            // 
            // btnCreateMaze
            // 
            this.btnCreateMaze.Location = new System.Drawing.Point(1125, 331);
            this.btnCreateMaze.Name = "btnCreateMaze";
            this.btnCreateMaze.Size = new System.Drawing.Size(146, 28);
            this.btnCreateMaze.TabIndex = 6;
            this.btnCreateMaze.Text = "Create Maze";
            this.btnCreateMaze.UseVisualStyleBackColor = true;
            this.btnCreateMaze.Click += new System.EventHandler(this.btnCreateMaze_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1161, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save Maze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadMaze
            // 
            this.LoadMaze.Location = new System.Drawing.Point(1161, 394);
            this.LoadMaze.Name = "LoadMaze";
            this.LoadMaze.Size = new System.Drawing.Size(75, 23);
            this.LoadMaze.TabIndex = 8;
            this.LoadMaze.Text = "Load Maze";
            this.LoadMaze.UseVisualStyleBackColor = true;
            this.LoadMaze.Click += new System.EventHandler(this.LoadMaze_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(1161, 423);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // txtStartingSquare
            // 
            this.txtStartingSquare.Location = new System.Drawing.Point(745, 59);
            this.txtStartingSquare.Name = "txtStartingSquare";
            this.txtStartingSquare.Size = new System.Drawing.Size(76, 20);
            this.txtStartingSquare.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(638, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Starting square";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(638, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "End Square";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtEndSquare
            // 
            this.txtEndSquare.Location = new System.Drawing.Point(745, 88);
            this.txtEndSquare.Name = "txtEndSquare";
            this.txtEndSquare.Size = new System.Drawing.Size(76, 20);
            this.txtEndSquare.TabIndex = 13;
            // 
            // Prims
            // 
            this.Prims.Location = new System.Drawing.Point(1161, 453);
            this.Prims.Name = "Prims";
            this.Prims.Size = new System.Drawing.Size(75, 23);
            this.Prims.TabIndex = 14;
            this.Prims.Text = "Dijkstras";
            this.Prims.UseVisualStyleBackColor = true;
            this.Prims.Click += new System.EventHandler(this.Dijkstras_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 625);
            this.Controls.Add(this.Prims);
            this.Controls.Add(this.txtEndSquare);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtStartingSquare);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.LoadMaze);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateMaze);
            this.Controls.Add(this.imgBoxTree);
            this.Controls.Add(this.SolveMaze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SolveMaze;
        private Emgu.CV.UI.ImageBox imgBoxTree;
        private System.Windows.Forms.Button btnCreateMaze;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoadMaze;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox txtStartingSquare;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtEndSquare;
        private System.Windows.Forms.Button Prims;
    }
}

