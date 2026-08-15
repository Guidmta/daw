using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeelmtaLauncher
{
    public class MainForm : Form
    {
        private Panel topBar;
        private Label titleLabel;
        private Button closeButton;
        private Label mainTitle;
        private Label versionLabel;
        private Label descLabel;
        private Button startButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Ablak beállításai (Kék háttér, egyedi ablak)
            this.Size = new Size(900, 580);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(11, 19, 43); // Kék háttér (#0b1329)

            // Felső címsor sáv
            topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(28, 37, 65)
            };
            
            // Ablak mozgatása egérrel
            topBar.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left) {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            titleLabel = new Label
            {
                Text = "Seelmta Launcher",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };

            // Bezárás gomb (X)
            closeButton = new Button
            {
                Text = "✕",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                Location = new Point(860, 0),
                Cursor = Cursors.Hand
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
            closeButton.Click += (s, e) => Application.Exit();

            topBar.Controls.Add(titleLabel);
            topBar.Controls.Add(closeButton);

            // Főcím: Seelmta
            mainTitle = new Label
            {
                Text = "Seelmta",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 42, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(800, 80),
                Location = new Point(50, 130),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Verzió jelvény
            versionLabel = new Label
            {
                Text = "v1.0.0",
                ForeColor = Color.FromArgb(147, 197, 253),
                BackColor = Color.FromArgb(30, 58, 138),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(100, 30),
                Location = new Point(400, 220),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Leírás
            descLabel = new Label
            {
                Text = "Légy részese a Seelmta legújabb és legizgalmasabb RolePlay közösségének!\n\nVágj bele a második életedbe, itt minden lehetséges!",
                ForeColor = Color.FromArgb(203, 213, 225),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(700, 80),
                Location = new Point(100, 270),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Kék indítás gomb
            startButton = new Button
            {
                Text = "►  Seelmta indítása",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(37, 99, 235), // Élénkkék
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Size = new Size(280, 55),
                Location = new Point(310, 380),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);

            // Fejlesztés alatt üzenet gombra kattintáskor
            startButton.Click += (s, e) =>
            {
                MessageBox.Show("Fejlesztés alatt!", "Seelmta Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Elemek hozzáadása
            this.Controls.Add(topBar);
            this.Controls.Add(mainTitle);
            this.Controls.Add(versionLabel);
            this.Controls.Add(descLabel);
            this.Controls.Add(startButton);
        }

        // Windows API az ablak mozgatásához
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}