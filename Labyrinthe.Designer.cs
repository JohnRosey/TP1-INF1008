﻿
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
            this.lbl_operation_init = new System.Windows.Forms.Label();
            this.lbl_max = new System.Windows.Forms.Label();
            this.txtBox_max = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDraggable = new System.Windows.Forms.Panel();
            this.lbl_operation_prim = new System.Windows.Forms.Label();
            this.lbl_operation_total = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_infoDimension
            // 
            this.lbl_infoDimension.AutoSize = true;
            this.lbl_infoDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_infoDimension.Location = new System.Drawing.Point(23, 217);
            this.lbl_infoDimension.Name = "lbl_infoDimension";
            this.lbl_infoDimension.Size = new System.Drawing.Size(172, 20);
            this.lbl_infoDimension.TabIndex = 0;
            this.lbl_infoDimension.Text = "information dimension :";
            // 
            // lbl_longueur
            // 
            this.lbl_longueur.AutoSize = true;
            this.lbl_longueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_longueur.Location = new System.Drawing.Point(43, 44);
            this.lbl_longueur.Name = "lbl_longueur";
            this.lbl_longueur.Size = new System.Drawing.Size(141, 20);
            this.lbl_longueur.TabIndex = 1;
            this.lbl_longueur.Text = "Entrer la Longueur";
            // 
            // lbl_largeur
            // 
            this.lbl_largeur.AutoSize = true;
            this.lbl_largeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_largeur.Location = new System.Drawing.Point(43, 95);
            this.lbl_largeur.Name = "lbl_largeur";
            this.lbl_largeur.Size = new System.Drawing.Size(128, 20);
            this.lbl_largeur.TabIndex = 2;
            this.lbl_largeur.Text = "Entrer la Largeur";
            // 
            // txtBox_Longueur
            // 
            this.txtBox_Longueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Longueur.Location = new System.Drawing.Point(204, 41);
            this.txtBox_Longueur.Name = "txtBox_Longueur";
            this.txtBox_Longueur.Size = new System.Drawing.Size(100, 26);
            this.txtBox_Longueur.TabIndex = 3;
            // 
            // txtBox_Largeur
            // 
            this.txtBox_Largeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Largeur.Location = new System.Drawing.Point(204, 89);
            this.txtBox_Largeur.Name = "txtBox_Largeur";
            this.txtBox_Largeur.Size = new System.Drawing.Size(100, 26);
            this.txtBox_Largeur.TabIndex = 4;
            // 
            // btn_generer
            // 
            this.btn_generer.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_generer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_generer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generer.ForeColor = System.Drawing.Color.White;
            this.btn_generer.Location = new System.Drawing.Point(378, 132);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(102, 36);
            this.btn_generer.TabIndex = 5;
            this.btn_generer.Text = "Générer";
            this.btn_generer.UseVisualStyleBackColor = false;
            this.btn_generer.Click += new System.EventHandler(this.btn_generer_Click);
            // 
            // lbl_operation_init
            // 
            this.lbl_operation_init.AutoSize = true;
            this.lbl_operation_init.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operation_init.Location = new System.Drawing.Point(23, 248);
            this.lbl_operation_init.Name = "lbl_operation_init";
            this.lbl_operation_init.Size = new System.Drawing.Size(243, 20);
            this.lbl_operation_init.TabIndex = 6;
            this.lbl_operation_init.Text = "Nombre d\'opération Initialisation :";
            // 
            // lbl_max
            // 
            this.lbl_max.AutoSize = true;
            this.lbl_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_max.Location = new System.Drawing.Point(84, 148);
            this.lbl_max.Name = "lbl_max";
            this.lbl_max.Size = new System.Drawing.Size(89, 20);
            this.lbl_max.TabIndex = 8;
            this.lbl_max.Text = "Poids Max :";
            // 
            // txtBox_max
            // 
            this.txtBox_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_max.Location = new System.Drawing.Point(204, 142);
            this.txtBox_max.Name = "txtBox_max";
            this.txtBox_max.Size = new System.Drawing.Size(100, 26);
            this.txtBox_max.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(539, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelDraggable
            // 
            this.panelDraggable.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelDraggable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDraggable.Location = new System.Drawing.Point(0, 0);
            this.panelDraggable.Name = "panelDraggable";
            this.panelDraggable.Size = new System.Drawing.Size(587, 15);
            this.panelDraggable.TabIndex = 12;
            this.panelDraggable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PannelDraggable_MouseDown);
            // 
            // lbl_operation_prim
            // 
            this.lbl_operation_prim.AutoSize = true;
            this.lbl_operation_prim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operation_prim.Location = new System.Drawing.Point(23, 278);
            this.lbl_operation_prim.Name = "lbl_operation_prim";
            this.lbl_operation_prim.Size = new System.Drawing.Size(191, 20);
            this.lbl_operation_prim.TabIndex = 13;
            this.lbl_operation_prim.Text = "Nombre d\'opération Prim :";
            // 
            // lbl_operation_total
            // 
            this.lbl_operation_total.AutoSize = true;
            this.lbl_operation_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operation_total.Location = new System.Drawing.Point(23, 310);
            this.lbl_operation_total.Name = "lbl_operation_total";
            this.lbl_operation_total.Size = new System.Drawing.Size(195, 20);
            this.lbl_operation_total.TabIndex = 14;
            this.lbl_operation_total.Text = "Nombre d\'opération Total :";
            // 
            // Labyrinthe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(587, 350);
            this.Controls.Add(this.lbl_operation_total);
            this.Controls.Add(this.lbl_operation_prim);
            this.Controls.Add(this.panelDraggable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_max);
            this.Controls.Add(this.lbl_max);
            this.Controls.Add(this.lbl_operation_init);
            this.Controls.Add(this.btn_generer);
            this.Controls.Add(this.txtBox_Largeur);
            this.Controls.Add(this.txtBox_Longueur);
            this.Controls.Add(this.lbl_largeur);
            this.Controls.Add(this.lbl_longueur);
            this.Controls.Add(this.lbl_infoDimension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Labyrinthe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lbl_operation_init;
        private System.Windows.Forms.Label lbl_max;
        private System.Windows.Forms.TextBox txtBox_max;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDraggable;
        private System.Windows.Forms.Label lbl_operation_prim;
        private System.Windows.Forms.Label lbl_operation_total;
    }
}

