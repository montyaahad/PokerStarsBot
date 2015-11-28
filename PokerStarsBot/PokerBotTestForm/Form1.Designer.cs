namespace PokerBotTestForm
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
            this.btnScreenCapture = new System.Windows.Forms.Button();
            this.btnHandCardCapture = new System.Windows.Forms.Button();
            this.btnCommunityCardCapture = new System.Windows.Forms.Button();
            this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
            this.btnHandCards = new System.Windows.Forms.Button();
            this.btnCommCards = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScreenCapture
            // 
            this.btnScreenCapture.Location = new System.Drawing.Point(13, 13);
            this.btnScreenCapture.Name = "btnScreenCapture";
            this.btnScreenCapture.Size = new System.Drawing.Size(153, 23);
            this.btnScreenCapture.TabIndex = 0;
            this.btnScreenCapture.Text = "Poker Screen capture";
            this.btnScreenCapture.UseVisualStyleBackColor = true;
            this.btnScreenCapture.Click += new System.EventHandler(this.btnScreenCapture_Click);
            // 
            // btnHandCardCapture
            // 
            this.btnHandCardCapture.Location = new System.Drawing.Point(187, 13);
            this.btnHandCardCapture.Name = "btnHandCardCapture";
            this.btnHandCardCapture.Size = new System.Drawing.Size(148, 23);
            this.btnHandCardCapture.TabIndex = 1;
            this.btnHandCardCapture.Text = "Hand Card Image";
            this.btnHandCardCapture.UseVisualStyleBackColor = true;
            this.btnHandCardCapture.Click += new System.EventHandler(this.btnHandCardCapture_Click);
            // 
            // btnCommunityCardCapture
            // 
            this.btnCommunityCardCapture.Location = new System.Drawing.Point(352, 13);
            this.btnCommunityCardCapture.Name = "btnCommunityCardCapture";
            this.btnCommunityCardCapture.Size = new System.Drawing.Size(158, 23);
            this.btnCommunityCardCapture.TabIndex = 2;
            this.btnCommunityCardCapture.Text = "Community Card Image";
            this.btnCommunityCardCapture.UseVisualStyleBackColor = true;
            this.btnCommunityCardCapture.Click += new System.EventHandler(this.btnCommunityCardCapture_Click);
            // 
            // pictureBoxScreen
            // 
            this.pictureBoxScreen.Location = new System.Drawing.Point(13, 55);
            this.pictureBoxScreen.Name = "pictureBoxScreen";
            this.pictureBoxScreen.Size = new System.Drawing.Size(847, 416);
            this.pictureBoxScreen.TabIndex = 3;
            this.pictureBoxScreen.TabStop = false;
            // 
            // btnHandCards
            // 
            this.btnHandCards.Location = new System.Drawing.Point(527, 13);
            this.btnHandCards.Name = "btnHandCards";
            this.btnHandCards.Size = new System.Drawing.Size(75, 23);
            this.btnHandCards.TabIndex = 4;
            this.btnHandCards.Text = "Hand Cards";
            this.btnHandCards.UseVisualStyleBackColor = true;
            this.btnHandCards.Click += new System.EventHandler(this.btnHandCards_Click);
            // 
            // btnCommCards
            // 
            this.btnCommCards.Location = new System.Drawing.Point(623, 13);
            this.btnCommCards.Name = "btnCommCards";
            this.btnCommCards.Size = new System.Drawing.Size(110, 23);
            this.btnCommCards.TabIndex = 5;
            this.btnCommCards.Text = "Community Cards";
            this.btnCommCards.UseVisualStyleBackColor = true;
            this.btnCommCards.Click += new System.EventHandler(this.btnCommCards_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 483);
            this.Controls.Add(this.btnCommCards);
            this.Controls.Add(this.btnHandCards);
            this.Controls.Add(this.pictureBoxScreen);
            this.Controls.Add(this.btnCommunityCardCapture);
            this.Controls.Add(this.btnHandCardCapture);
            this.Controls.Add(this.btnScreenCapture);
            this.Name = "Form1";
            this.Text = "PokerStars Bot Test Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenCapture;
        private System.Windows.Forms.Button btnHandCardCapture;
        private System.Windows.Forms.Button btnCommunityCardCapture;
        private System.Windows.Forms.PictureBox pictureBoxScreen;
        private System.Windows.Forms.Button btnHandCards;
        private System.Windows.Forms.Button btnCommCards;
    }
}

