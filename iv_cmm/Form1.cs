using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MemoryEdit;

namespace iv_cmm
{
    public partial class Form1 : Form
    {
        const string modinfo_file = "modinfo.txt";

        string[] tmp;

        uint pointer1 = 0x0;
        uint pointer2 = 0x0;
        uint pointer3 = 0x0;

        string folder = null;

        StreamReader sr;
        Memory mem;
        ASCIIEncoding encoder = new ASCIIEncoding();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("mods"))
            {
                tmp = Directory.GetDirectories("mods");
                lb_mod.Items.Clear();

                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = tmp[i].Substring(tmp[i].IndexOf("\\") + 1);
                    if (tmp[i].Length <= 8) lb_mod.Items.Add(tmp[i]);
                }
                tmp = null;
                if (lb_mod.Items.Count == 0)
                    MessageBox.Show("No mods installed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mods directory missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void lb_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_start.Enabled = lb_mod.SelectedIndex != -1;
            bt_info.Enabled = bt_start.Enabled;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (File.Exists("GTAIV.exe") && File.Exists("LaunchGTAIV.exe"))
            {
                folder = "MODS/" + lb_mod.Items[lb_mod.SelectedIndex] + "/";
                Process.Start("LaunchGTAIV.exe");
                this.WindowState = FormWindowState.Minimized;

            retry:
                if (!Memory.IsProcessOpen("GTAIV"))
                {
                    System.Threading.Thread.Sleep(2000);
                    goto retry;
                }

                mem = new Memory("GTAIV", 0x001F0FFF);

                pointer1 = (uint)mem.Read(mem.base_addr + 0x00C848A4) + 0x118; //gta.dat
                pointer2 = (uint)mem.Read(mem.base_addr + 0x00B2204C) + 0x160; //default.dat
                pointer3 = (uint)mem.Read(mem.base_addr + 0x007EA86C) + 0x1C; //carcols.dat

                mem.SetProtection(pointer1, 0x100, Memory.Protection.PAGE_READWRITE);
                mem.SetProtection(pointer2, 0x100, Memory.Protection.PAGE_READWRITE);
                mem.SetProtection(pointer3, 0x100, Memory.Protection.PAGE_READWRITE);

                //Zero out block
                byte[] Buffer;

                if (File.Exists(folder + "gta.dat"))
                {
                    Buffer = BitConverter.GetBytes(0);
                    mem.WriteByte(pointer1, Buffer, 0x17);
                    //ASCII Dump
                    Buffer = encoder.GetBytes(folder + "gta.dat");
                    mem.WriteString(pointer1, Buffer, Buffer.Length);
                }
                if (File.Exists(folder + "default.dat"))
                {
                    Buffer = BitConverter.GetBytes(0);
                    mem.WriteByte(pointer2, Buffer, 0x1B);
                    //ASCII Dump
                    Buffer = encoder.GetBytes(folder + "default.dat");
                    mem.WriteString(pointer2, Buffer, Buffer.Length);
                }
                if (File.Exists(folder + "carcols.dat"))
                {
                    Buffer = BitConverter.GetBytes(0);
                    mem.WriteByte(pointer3, Buffer, 0x1B);
                    //ASCII Dump
                    Buffer = encoder.GetBytes(folder + "carcols.dat");
                    mem.WriteString(pointer3, Buffer, Buffer.Length);
                }
                Application.Exit();
            }
            else MessageBox.Show("GTA:IV not found!","Error",
                MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void bt_info_Click(object sender, EventArgs e)
        {
            folder = "MODS\\" + lb_mod.Items[lb_mod.SelectedIndex] + "\\";
            if (File.Exists(folder + modinfo_file))
            {
                sr = new StreamReader(folder + modinfo_file);
                MessageBox.Show(sr.ReadToEnd(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sr.Close();
            }
            else MessageBox.Show("This mod doesn't have an information file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}