namespace WordPadCopyCat
{
    partial class ColoursForm
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
            this.btn_black = new System.Windows.Forms.Button();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            this.btn_blue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_black
            // 
            this.btn_black.BackColor = System.Drawing.Color.Black;
            this.btn_black.Location = new System.Drawing.Point(16, 9);
            this.btn_black.Name = "btn_black";
            this.btn_black.Size = new System.Drawing.Size(81, 77);
            this.btn_black.TabIndex = 0;
            this.btn_black.UseVisualStyleBackColor = false;
            this.btn_black.Click += new System.EventHandler(this.btn_black_Click);
            // 
            // btn_red
            // 
            this.btn_red.BackColor = System.Drawing.Color.Red;
            this.btn_red.Location = new System.Drawing.Point(103, 9);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(81, 77);
            this.btn_red.TabIndex = 0;
            this.btn_red.UseVisualStyleBackColor = false;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_green
            // 
            this.btn_green.BackColor = System.Drawing.Color.Lime;
            this.btn_green.Location = new System.Drawing.Point(190, 9);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(81, 77);
            this.btn_green.TabIndex = 0;
            this.btn_green.UseVisualStyleBackColor = false;
            this.btn_green.Click += new System.EventHandler(this.btn_green_Click);
            // 
            // btn_blue
            // 
            this.btn_blue.BackColor = System.Drawing.Color.Blue;
            this.btn_blue.Location = new System.Drawing.Point(277, 9);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(81, 77);
            this.btn_blue.TabIndex = 0;
            this.btn_blue.UseVisualStyleBackColor = false;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // Colours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 97);
            this.Controls.Add(this.btn_blue);
            this.Controls.Add(this.btn_green);
            this.Controls.Add(this.btn_red);
            this.Controls.Add(this.btn_black);
            this.Name = "Colours";
            this.Text = "Colours";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_black;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_green;
        private System.Windows.Forms.Button btn_blue;
    }
}