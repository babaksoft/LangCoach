namespace BabakSoft.LangCoach.Win
{
    partial class MainWindow
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
            mainMenu = new MenuStrip();
            menuAdmin = new ToolStripMenuItem();
            menuAdminWords = new ToolStripMenuItem();
            menuAdminVerbs = new ToolStripMenuItem();
            menuAdminImport = new ToolStripMenuItem();
            menuAdminBackup = new ToolStripMenuItem();
            menuLearner = new ToolStripMenuItem();
            menuLearnerReview = new ToolStripMenuItem();
            menuLearnerConjugations = new ToolStripMenuItem();
            menuLearnerQuiz = new ToolStripMenuItem();
            menuLearnerNotes = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuHelpAbout = new ToolStripMenuItem();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { menuAdmin, menuLearner, menuHelp });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(942, 28);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // menuAdmin
            // 
            menuAdmin.DropDownItems.AddRange(new ToolStripItem[] { menuAdminWords, menuAdminVerbs, menuAdminImport, menuAdminBackup });
            menuAdmin.Name = "menuAdmin";
            menuAdmin.Size = new Size(67, 24);
            menuAdmin.Text = "&Admin";
            // 
            // menuAdminWords
            // 
            menuAdminWords.Name = "menuAdminWords";
            menuAdminWords.ShortcutKeys = Keys.Control | Keys.W;
            menuAdminWords.Size = new Size(272, 26);
            menuAdminWords.Text = "&Words and Phrases";
            menuAdminWords.Click += AdminWords_Click;
            // 
            // menuAdminVerbs
            // 
            menuAdminVerbs.Name = "menuAdminVerbs";
            menuAdminVerbs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.V;
            menuAdminVerbs.Size = new Size(272, 26);
            menuAdminVerbs.Text = "&Verbs";
            menuAdminVerbs.Click += AdminVerbs_Click;
            // 
            // menuAdminImport
            // 
            menuAdminImport.Name = "menuAdminImport";
            menuAdminImport.ShortcutKeys = Keys.Control | Keys.I;
            menuAdminImport.Size = new Size(272, 26);
            menuAdminImport.Text = "&Import from CSV";
            menuAdminImport.Click += AdminImport_Click;
            // 
            // menuAdminBackup
            // 
            menuAdminBackup.Name = "menuAdminBackup";
            menuAdminBackup.ShortcutKeys = Keys.Control | Keys.B;
            menuAdminBackup.Size = new Size(272, 26);
            menuAdminBackup.Text = "&Backup Data Files";
            menuAdminBackup.Click += AdminBackup_Click;
            // 
            // menuLearner
            // 
            menuLearner.DropDownItems.AddRange(new ToolStripItem[] { menuLearnerReview, menuLearnerConjugations, menuLearnerQuiz, menuLearnerNotes });
            menuLearner.Name = "menuLearner";
            menuLearner.Size = new Size(72, 24);
            menuLearner.Text = "&Learner";
            // 
            // menuLearnerReview
            // 
            menuLearnerReview.Name = "menuLearnerReview";
            menuLearnerReview.ShortcutKeys = Keys.Control | Keys.T;
            menuLearnerReview.Size = new Size(304, 26);
            menuLearnerReview.Text = "Review by &Topic";
            menuLearnerReview.Click += LearnerReview_Click;
            // 
            // menuLearnerConjugations
            // 
            menuLearnerConjugations.Name = "menuLearnerConjugations";
            menuLearnerConjugations.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            menuLearnerConjugations.Size = new Size(304, 26);
            menuLearnerConjugations.Text = "Verb &Conjugations";
            menuLearnerConjugations.Click += LearnerConjugations_Click;
            // 
            // menuLearnerQuiz
            // 
            menuLearnerQuiz.Name = "menuLearnerQuiz";
            menuLearnerQuiz.ShortcutKeys = Keys.Control | Keys.Q;
            menuLearnerQuiz.Size = new Size(304, 26);
            menuLearnerQuiz.Text = "Take A &Quiz";
            menuLearnerQuiz.Click += LearnerQuiz_Click;
            // 
            // menuLearnerNotes
            // 
            menuLearnerNotes.Name = "menuLearnerNotes";
            menuLearnerNotes.ShortcutKeys = Keys.Control | Keys.N;
            menuLearnerNotes.Size = new Size(304, 26);
            menuLearnerNotes.Text = "My &Notes";
            menuLearnerNotes.Click += LearnerNotes_Click;
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuHelpAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(55, 24);
            menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            menuHelpAbout.Name = "menuHelpAbout";
            menuHelpAbout.ShortcutKeys = Keys.F1;
            menuHelpAbout.Size = new Size(280, 26);
            menuHelpAbout.Text = "&About Language Coach...";
            menuHelpAbout.Click += HelpAbout_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 643);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lanuage Coach (French)";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem menuAdmin;
        private ToolStripMenuItem menuAdminWords;
        private ToolStripMenuItem menuAdminVerbs;
        private ToolStripMenuItem menuAdminImport;
        private ToolStripMenuItem menuAdminBackup;
        private ToolStripMenuItem menuLearner;
        private ToolStripMenuItem menuLearnerReview;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuLearnerConjugations;
        private ToolStripMenuItem menuLearnerQuiz;
        private ToolStripMenuItem menuLearnerNotes;
        private ToolStripMenuItem menuHelpAbout;
    }
}
