namespace GameEngineUI.Window
{
    partial class GameWindow
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
            this.gameRenderer1 = new GameEngineUI.Renderer.GameRenderer();
            this.SuspendLayout();
            // 
            // gameRenderer1
            // 
            this.gameRenderer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameRenderer1.Location = new System.Drawing.Point(0, 0);
            this.gameRenderer1.Name = "gameRenderer1";
            this.gameRenderer1.Size = new System.Drawing.Size(800, 450);
            this.gameRenderer1.TabIndex = 0;
            this.gameRenderer1.Text = "gameRenderer1";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gameRenderer1);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Renderer.GameRenderer gameRenderer1;
    }
}