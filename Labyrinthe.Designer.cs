
namespace TP1_INF1008
{
    partial class Labyrinthe
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_infoDimension = new System.Windows.Forms.Label();
            this.lbl_longueur = new System.Windows.Forms.Label();
            this.lbl_largeur = new System.Windows.Forms.Label();
            this.txtBox_Longueur = new System.Windows.Forms.TextBox();
            this.txtBox_Largeur = new System.Windows.Forms.TextBox();
            this.btn_generer = new System.Windows.Forms.Button();
            this.lbl_operation = new System.Windows.Forms.Label();
            this.lbl_max = new System.Windows.Forms.Label();
            this.txtBox_max = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_infoDimension
            // 
            this.lbl_infoDimension.AutoSize = true;
            this.lbl_infoDimension.Location = new System.Drawing.Point(11, 395);
            this.lbl_infoDimension.Name = "lbl_infoDimension";
            this.lbl_infoDimension.Size = new System.Drawing.Size(114, 13);
            this.lbl_infoDimension.TabIndex = 0;
            this.lbl_infoDimension.Text = "information dimension :";
            // 
            // lbl_longueur
            // 
            this.lbl_longueur.AutoSize = true;
            this.lbl_longueur.Location = new System.Drawing.Point(588, 366);
            this.lbl_longueur.Name = "lbl_longueur";
            this.lbl_longueur.Size = new System.Drawing.Size(94, 13);
            this.lbl_longueur.TabIndex = 1;
            this.lbl_longueur.Text = "Entrer la Longueur";
            // 
            // lbl_largeur
            // 
            this.lbl_largeur.AutoSize = true;
            this.lbl_largeur.Location = new System.Drawing.Point(588, 395);
            this.lbl_largeur.Name = "lbl_largeur";
            this.lbl_largeur.Size = new System.Drawing.Size(85, 13);
            this.lbl_largeur.TabIndex = 2;
            this.lbl_largeur.Text = "Entrer la Largeur";
            // 
            // txtBox_Longueur
            // 
            this.txtBox_Longueur.Location = new System.Drawing.Point(688, 366);
            this.txtBox_Longueur.Name = "txtBox_Longueur";
            this.txtBox_Longueur.Size = new System.Drawing.Size(100, 20);
            this.txtBox_Longueur.TabIndex = 3;
            // 
            // txtBox_Largeur
            // 
            this.txtBox_Largeur.Location = new System.Drawing.Point(688, 392);
            this.txtBox_Largeur.Name = "txtBox_Largeur";
            this.txtBox_Largeur.Size = new System.Drawing.Size(100, 20);
            this.txtBox_Largeur.TabIndex = 4;
            // 
            // btn_generer
            // 
            this.btn_generer.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_generer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_generer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generer.ForeColor = System.Drawing.Color.White;
            this.btn_generer.Location = new System.Drawing.Point(361, 404);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(75, 23);
            this.btn_generer.TabIndex = 5;
            this.btn_generer.Text = "Générer";
            this.btn_generer.UseVisualStyleBackColor = false;
            this.btn_generer.Click += new System.EventHandler(this.btn_generer_Click);
            // 
            // lbl_operation
            // 
            this.lbl_operation.AutoSize = true;
            this.lbl_operation.Location = new System.Drawing.Point(11, 426);
            this.lbl_operation.Name = "lbl_operation";
            this.lbl_operation.Size = new System.Drawing.Size(105, 13);
            this.lbl_operation.TabIndex = 6;
            this.lbl_operation.Text = "Nombre d\'opération :";
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Location = new System.Drawing.Point(620, 426);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(62, 13);
            this.lbl_max.TabIndex = 8;
            this.lbl_max.Text = "Poids Max :";
            // 
            // txtBox_max
            // 
            this.txtBox_max.Location = new System.Drawing.Point(688, 423);
            this.txtBox_max.Name = "txtBox_max";
            this.txtBox_max.Size = new System.Drawing.Size(100, 20);
            this.txtBox_max.TabIndex = 10;
            // 
            // Labyrinthe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBox_max);
            this.Controls.Add(this.lbl_max);
            this.Controls.Add(this.lbl_operation);
            this.Controls.Add(this.btn_generer);
            this.Controls.Add(this.txtBox_Largeur);
            this.Controls.Add(this.txtBox_Longueur);
            this.Controls.Add(this.lbl_largeur);
            this.Controls.Add(this.lbl_longueur);
            this.Controls.Add(this.lbl_infoDimension);
            this.Name = "Labyrinthe";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_infoDimension;
        private System.Windows.Forms.Label lbl_longueur;
        private System.Windows.Forms.Label lbl_largeur;
        private System.Windows.Forms.TextBox txtBox_Longueur;
        private System.Windows.Forms.TextBox txtBox_Largeur;
        private System.Windows.Forms.Button btn_generer;
        private System.Windows.Forms.Label lbl_operation;
        private System.Windows.Forms.Label lbl_max;
        private System.Windows.Forms.TextBox txtBox_max;
    }
}

