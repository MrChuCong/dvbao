namespace FAD
{
    partial class FormFAD
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.faPlotter = new Core.FAPlotter();
            this.property = new System.Windows.Forms.PropertyGrid();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.faPlotter);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.property);
            this.splitContainer.Size = new System.Drawing.Size(904, 562);
            this.splitContainer.SplitterDistance = 624;
            this.splitContainer.TabIndex = 0;
            // 
            // faPlotter
            // 
            this.faPlotter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faPlotter.Location = new System.Drawing.Point(0, 0);
            this.faPlotter.Name = "faPlotter";
            this.faPlotter.Size = new System.Drawing.Size(624, 562);
            this.faPlotter.TabIndex = 0;
            // 
            // property
            // 
            this.property.Dock = System.Windows.Forms.DockStyle.Fill;
            this.property.Location = new System.Drawing.Point(0, 0);
            this.property.Name = "property";
            this.property.Size = new System.Drawing.Size(276, 562);
            this.property.TabIndex = 0;
            this.property.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.property_PropertyValueChanged);
            // 
            // FormFAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 562);
            this.Controls.Add(this.splitContainer);
            this.Name = "FormFAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finite Automata Demonstration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFAD_FormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private Core.FAPlotter faPlotter;
        private System.Windows.Forms.PropertyGrid property;
    }
}

