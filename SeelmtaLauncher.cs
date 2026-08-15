using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeelmtaLauncher
{
    public class MainForm : Form
    {
        private Panel sidebarPanel;
        private Button homeButton;
        private Button storeButton;
        private Button webButton;
        private Button settingsButton;
        
        private Label mainTitle;
        private Label versionBadge;
        private Label descLabel;
        private Button startButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Ablak alapbeállításai (Sötét, modern stílus)
            this.Size = new Size(1000, 650);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 18); // Sötét háttér
            this.Text = "Seelmta Launcher";

            // Bal oldalsáv (Panel)
            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 70,
                BackColor = Color.FromArgb(24, 24, 24)
            };

            // Oldalsó gombok (ikonok helyett szimbólumok)
            homeButton = CreateSidebarButton("🏠", 20);
            storeButton = CreateSidebarButton("💎", 85);
            webButton = CreateSidebarButton("🌐", 150);
            settingsButton = CreateSidebarButton("⚙️", 570);

            sidebarPanel.Controls.Add(homeButton);
            sidebarPanel.Controls.Add(storeButton);
            sidebarPanel.Controls.Add(webButton);
            sidebarPanel.Controls.Add(settingsButton);

            // Főcím: Seelmta
            mainTitle = new Label
            {
                Text = "Seelmta",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 38, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(600, 70),
                Location = new Point(250, 150),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Verzió jelvény (v1.3.8)
            versionBadge = new Label
            {
                Text = "✔  v1.3.8",
                ForeColor = Color.FromArgb(74, 222, 128),
                BackColor = Color.FromArgb(20, 40, 30),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Size = new Size(90, 28),
                Location = new Point(505, 235),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Leírás szöveg
            descLabel = new Label
            {
                Text = "Légy részese Magyarország legnagyobb és legismertebb gazdag RolePlay\nközösségének!\n\nVágj bele a második életedbe, itt minden lehetséges!",
                ForeColor = Color.FromArgb(156, 163, 175),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(700, 70),
                Location = new Point(200, 290),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Zöld Indítás gomb (Amikor rákatintanak, szándékosan SEMMI sem történik)
            startButton = new Button
            {
                Text = "▶  Seelmta indítása",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(16, 125, 78), // Zöld szín a kép alapján
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(260, 50),
                Location = new Point(420, 390),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            startButton.FlatAppearance.BorderSize = 0;

            // ITT VAN MEGADVA: Amikor rákattintanak, szándékosan semmi sem történik
            startButton.Click += (s, e) =>
            {
                // Szándékosan üresen hagyva, hogy ne csináljon semmit
            };

            // Vezérlők hozzáadása az ablakhoz
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(mainTitle);
            this.Controls.Add(versionBadge);
            this.Controls.Add(descLabel);
            this.Controls.Add(startButton);
        }

        private Button CreateSidebarButton(string text, int topPosition)
        {
            Button btn = new Button
            {
                Text = text,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(50, 50),
                Location = new Point(10, topPosition),
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 14)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
