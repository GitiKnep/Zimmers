
namespace MyZimmer.GUI
{
    partial class MainPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTenant = new System.Windows.Forms.Button();
            this.btnRenting = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Guttman Yad", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(45, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "שלום וברכה, אנא בחר בסוג משתמש";
            // 
            // btnTenant
            // 
            this.btnTenant.BackColor = System.Drawing.Color.White;
            this.btnTenant.Font = new System.Drawing.Font("Guttman-Aram", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnTenant.ForeColor = System.Drawing.Color.Green;
            this.btnTenant.Location = new System.Drawing.Point(332, 141);
            this.btnTenant.Name = "btnTenant";
            this.btnTenant.Size = new System.Drawing.Size(148, 90);
            this.btnTenant.TabIndex = 2;
            this.btnTenant.Text = "שוכר";
            this.btnTenant.UseVisualStyleBackColor = false;
            this.btnTenant.Click += new System.EventHandler(this.btnTenant_Click);
            // 
            // btnRenting
            // 
            this.btnRenting.BackColor = System.Drawing.Color.White;
            this.btnRenting.Font = new System.Drawing.Font("Guttman-Aram", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRenting.ForeColor = System.Drawing.Color.Green;
            this.btnRenting.Location = new System.Drawing.Point(127, 141);
            this.btnRenting.Name = "btnRenting";
            this.btnRenting.Size = new System.Drawing.Size(148, 90);
            this.btnRenting.TabIndex = 3;
            this.btnRenting.Text = "משכיר";
            this.btnRenting.UseVisualStyleBackColor = false;
            this.btnRenting.Click += new System.EventHandler(this.btnRenting_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MyZimmer.Properties.Resources.vao1;
            this.pictureBox1.Location = new System.Drawing.Point(144, 305);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 77);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Guttman-Aram", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(235, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "...קצת עלינו";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(611, 394);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRenting);
            this.Controls.Add(this.btnTenant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTenant;
        private System.Windows.Forms.Button btnRenting;
        private System.Windows.Forms.Button button1;
    }
}