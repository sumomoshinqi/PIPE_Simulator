using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace PIPE_Simulator
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public string filename = "";
        public string fn = "";
        public StreamReader sr;
        public string F_content = "", D_content = "", E_content = "", M_content = "", W_content = "";
        public int cycle = 0, instr = 0;
        public int interval = 1000;
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public Form1()
        {
            InitializeComponent();
            ((Control)dragBox).AllowDrop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            LockWindowUpdate(this.Handle);
            creditsBox.BringToFront();
            dragBox.BringToFront();
            cycleslabel.SendToBack();
            instrlabel.SendToBack();
            eaxlabel.SendToBack();
            ebxlabel.SendToBack();
            ecxlabel.SendToBack();
            edxlabel.SendToBack();
            edilabel.SendToBack();
            esilabel.SendToBack();
            ebplabel.SendToBack();
            esplabel.SendToBack();
            LockWindowUpdate(IntPtr.Zero);
        }

        //  drag a .yo file to start simulation.
        private void dragBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dragBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                filename = file.Substring(0, file.Length - 3);
                FileStream fs = new FileStream("filename.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(filename);
                sw.Close();
                fs.Close();
                int i;
                for (i = filename.Length - 1; ; i--)
                    if (filename[i] == '\\')
                        break;
                fn = filename.Substring(i + 1);
                //  call PIPE_Assembler.exe
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = "PIPE_Assembler.exe";
                process.StartInfo.Arguments = "--PIPE_Assembler";
                process.Start();
                MessageBox.Show("Simulation target is " + fn + ".", "Loading Success");
                sr = new StreamReader(filename + ".txt");
                LockWindowUpdate(this.Handle);
                dragBox.Visible = false;
                stateBox.Visible = true;
                runButton.Enabled = false;
                pauseButton.Enabled = true;
                stepButton.Enabled = false;
                resetButton.Enabled = false;
                stopButton.Enabled = true;
                creditsBox.Visible = false;
                W_icode.Visible = true;
                W_volE.Visible = true;
                W_volM.Visible = true;
                W_dstE.Visible = true;
                W_dstM.Visible = true;
                M_icode.Visible = true;
                M_Bch.Visible = true;
                M_volE.Visible = true;
                M_volA.Visible = true;
                M_dstE.Visible = true;
                M_dstM.Visible = true;
                M_Z.Visible = true;
                M_O.Visible = true;
                M_S.Visible = true;
                E_icode.Visible = true;
                E_iFun.Visible = true;
                E_volC.Visible = true;
                E_volA.Visible = true;
                E_volB.Visible = true;
                E_dstE.Visible = true;
                E_dstM.Visible = true;
                E_srcA.Visible = true;
                E_srcB.Visible = true;
                D_icode.Visible = true;
                D_iFun.Visible = true;
                D_rA.Visible = true;
                D_rB.Visible = true;
                D_volC.Visible = true;
                D_volP.Visible = true;
                F_predPC.Visible = true;
                F_state.Visible = true;
                D_state.Visible = true;
                E_state.Visible = true;
                M_state.Visible = true;
                W_state.Visible = true;
                asscodeD.Visible = true;
                asscodeE.Visible = true;
                asscodeF.Visible = true;
                asscodeM.Visible = true;
                asscodeW.Visible = true;
                assmemD.Visible = true;
                assmemE.Visible = true;
                assmemF.Visible = true;
                assmemM.Visible = true;
                assmemW.Visible = true;
                upperlineBox.Visible = true;
                memorytitleBox.Visible = true;
                menBox.BringToFront();
                menBox.Visible = true;
                rigBox.Visible = true;
                cycleslabel.BringToFront();
                instrlabel.BringToFront();
                eaxlabel.BringToFront();
                ebxlabel.BringToFront();
                ecxlabel.BringToFront();
                edxlabel.BringToFront();
                edilabel.BringToFront();
                esilabel.BringToFront();
                ebplabel.BringToFront();
                esplabel.BringToFront();
                cycleslabel.Visible = true;
                instrlabel.Visible = true;
                eaxlabel.Visible = true;
                ebxlabel.Visible = true;
                ecxlabel.Visible = true;
                edxlabel.Visible = true;
                edilabel.Visible = true;
                esilabel.Visible = true;
                ebplabel.Visible = true;
                esplabel.Visible = true;
                runButton.Enabled = true;
                pauseButton.Enabled = false;
                stepButton.Enabled = true;
                resetButton.Enabled = true;
                stopButton.Enabled = true;
                LockWindowUpdate(IntPtr.Zero);
            }
        }

        public void get_time_frequency()
        {
            string str = cpufqBox.Text;
            bool exists;
            if (exists = (cpufqBox.Text.Contains("1 "))) str = "1000";
            if (exists = (cpufqBox.Text.Contains("5 "))) str = "200";
            if (exists = (cpufqBox.Text.Contains("10 "))) str = "100";
            if (exists = (cpufqBox.Text.Contains("50 "))) str = "20";
            if (exists = (cpufqBox.Text.Contains("As"))) str = "1";
            int.TryParse(str, out interval);
            timer1.Interval = interval;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
            runButton.Enabled = false;
            pauseButton.Enabled = true;
            stepButton.Enabled = false;
            resetButton.Enabled = false;
            stopButton.Enabled = false;
            LockWindowUpdate(IntPtr.Zero);
            //  start current simulation.
            get_time_frequency();
            timer1.Start();
        }

        public string find(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(filename + ".txt");
            String cur_content = sr_tmp.ReadLine();
            while (!sr_tmp.EndOfStream)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            string str_tmp2;
            if (sr_tmp.EndOfStream)
            {
                str_tmp2 = ""; return str_tmp2;
            }
            string str_tmp;
            while (true)
            {
                bool exists = (cur_content.Contains(a));
                if (exists) break;
                else
                {
                    if (!sr_tmp.EndOfStream) cur_content = sr_tmp.ReadLine();
                    else { str_tmp = ""; return str_tmp; }
                }
            }
            int i;
            for (i = 0; ; i++) if (cur_content[i] == '=') break; i += 2;
            str_tmp = cur_content.Substring(i);
            return str_tmp;
        }

        public string find_in_reg(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_reg.txt");
            String cur_content = sr_tmp.ReadLine();
            while (true)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            string str_tmp;
            while (true)
            {
                bool exists = (cur_content.Contains(a));
                if (exists) break;
                else
                {
                    if (!sr_tmp.EndOfStream) cur_content = sr_tmp.ReadLine();
                    else { str_tmp = ""; return str_tmp; }
                }
            }
            int i;
            for (i = 0; ; i++) if (cur_content[i] == '=') break; i += 2;
            str_tmp = cur_content.Substring(i);
            return str_tmp;
        }

        public string find_in_mem(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_mem.txt");
            String cur_content = sr_tmp.ReadLine();
            while (true)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else
                {
                    if (!sr_tmp.EndOfStream)
                        cur_content = sr_tmp.ReadLine();
                    else
                        return "";
                }
            }
            string str_tmp;
            str_tmp = cur_content + "debug";
            return str_tmp;
        }

        public string find_loc_in_reg(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_reg.txt");
            String cur_content = sr_tmp.ReadLine();
            while (true)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            while (true)
            {
                bool exists = (cur_content.Contains(a));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            int i;
            for (i = 0; ; i++) if (cur_content[i] == '@') break; i += 2;
            string str_tmp = cur_content.Substring(i);
            return str_tmp;
        }

        public string find_in_asm(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(fn + ".asm");
            String cur_content = sr_tmp.ReadLine();
            string str_tmp;
            while (true)
            {
                bool exists = (cur_content.Contains(a));
                if (exists) break;
                else
                {
                    if (!sr_tmp.EndOfStream) cur_content = sr_tmp.ReadLine();
                    else { str_tmp = "nop"; return str_tmp; }
                }
            }
            int i;
            for (i = 0; ; i++) if (cur_content[i] == ':') break; i += 2;
            str_tmp = cur_content.Substring(i);
            return str_tmp;
        }

        public string find_in_reg2(int n, string a)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_reg.txt");
            String cur_content = sr_tmp.ReadLine();
            while (true)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            while (true)
            {
                bool exists = (cur_content.Contains(a));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            int i;
            for (i = 0; ; i++) if (cur_content[i] == ' ') break; i += 1;
            string str_tmp = cur_content.Substring(i, 3);
            return str_tmp;
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
            runButton.Enabled = false;
            pauseButton.Enabled = false;
            stepButton.Enabled = false;
            resetButton.Enabled = false;
            stopButton.Enabled = false;
            creditsBox.Visible = true;
            stateBox.Visible = false;
            W_icode.Visible = false;
            W_volE.Visible = false;
            W_volM.Visible = false;
            W_dstE.Visible = false;
            W_dstM.Visible = false;
            M_icode.Visible = false;
            M_Bch.Visible = false;
            M_volE.Visible = false;
            M_volA.Visible = false;
            M_dstE.Visible = false;
            M_dstM.Visible = false;
            M_Z.Visible = false;
            M_O.Visible = false;
            M_S.Visible = false;
            E_icode.Visible = false;
            E_iFun.Visible = false;
            E_volC.Visible = false;
            E_volA.Visible = false;
            E_volB.Visible = false;
            E_dstE.Visible = false;
            E_dstM.Visible = false;
            E_srcA.Visible = false;
            E_srcB.Visible = false;
            D_icode.Visible = false;
            D_iFun.Visible = false;
            D_rA.Visible = false;
            D_rB.Visible = false;
            D_volC.Visible = false;
            D_volP.Visible = false;
            F_predPC.Visible = false;
            F_state.Visible = false;
            D_state.Visible = false;
            E_state.Visible = false;
            M_state.Visible = false;
            W_state.Visible = false;
            asscodeD.Visible = false;
            asscodeE.Visible = false;
            asscodeF.Visible = false;
            asscodeM.Visible = false;
            asscodeW.Visible = false;
            assmemD.Visible = false;
            assmemE.Visible = false;
            assmemF.Visible = false;
            assmemM.Visible = false;
            assmemW.Visible = false;
            cycleslabel.Visible = false;
            instrlabel.Visible = false;
            eaxlabel.Visible = false;
            ebxlabel.Visible = false;
            ecxlabel.Visible = false;
            edxlabel.Visible = false;
            edilabel.Visible = false;
            esilabel.Visible = false;
            ebplabel.Visible = false;
            esplabel.Visible = false;
            cycleslabel.SendToBack();
            instrlabel.SendToBack();
            eaxlabel.SendToBack();
            ebxlabel.SendToBack();
            ecxlabel.SendToBack();
            edxlabel.SendToBack();
            edilabel.SendToBack();
            esilabel.SendToBack();
            ebplabel.SendToBack();
            esplabel.SendToBack();
            upperlineBox.Visible = false;
            rigBox.Visible = false;
            menBox.Visible = false;
            memorytitleBox.Visible = false;
            memorytitleBox.SendToBack();
            menBox.SendToBack();
            dragBox.BringToFront();
            dragBox.Visible = true;
            //  exit to index.
            eaxlabel.Text = "0x00000000";
            ebxlabel.Text = "0x00000000";
            ecxlabel.Text = "0x00000000";
            edxlabel.Text = "0x00000000";
            edilabel.Text = "0x00000000";
            esilabel.Text = "0x00000000";
            ebplabel.Text = "0x00000000";
            esplabel.Text = "0x00000000";
            cycleslabel.Text = "0";
            instrlabel.Text = "0";
            W_icode.Text = "0x0";
            W_volE.Text = "0x00000000";
            W_volM.Text = "0x00000000";
            W_dstE.Text = "0x8";
            W_dstM.Text = "0x8";
            M_icode.Text = "0x0";
            M_Bch.Text = "NULL";
            M_volE.Text = "0x00000000";
            M_volA.Text = "0x00000000";
            M_dstE.Text = "0x8";
            M_dstM.Text = "0x8";
            M_Z.Text = "0";
            M_O.Text = "0";
            M_S.Text = "0";
            E_icode.Text = "0x0";
            E_iFun.Text = "0x0";
            E_volC.Text = "0x00000000";
            E_volA.Text = "0x00000000";
            E_volB.Text = "0x00000000";
            E_dstE.Text = "0x8";
            E_dstM.Text = "0x8";
            E_srcA.Text = "0x8";
            E_srcB.Text = "0x8";
            D_icode.Text = "0x0";
            D_iFun.Text = "0x0";
            D_rA.Text = "0x8";
            D_rB.Text = "0x8";
            D_volC.Text = "0x00000000";
            D_volP.Text = "0x00000000";
            F_predPC.Text = "0x00000400";
            F_state.Text = "AOK";
            D_state.Text = "AOK";
            E_state.Text = "AOK";
            M_state.Text = "AOK";
            W_state.Text = "AOK";
            assmemF.Text = "0x00000000";
            assmemD.Text = "0x00000000";
            assmemE.Text = "0x00000000";
            assmemM.Text = "0x00000000";
            assmemW.Text = "0x00000000";
            asscodeF.Text = "";
            asscodeD.Text = "";
            asscodeE.Text = "";
            asscodeM.Text = "";
            asscodeW.Text = "";
            menBox.Items.Clear();
            //  reset
            cycle = instr = 0;
            timer1.Stop();
            LockWindowUpdate(IntPtr.Zero);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
            runButton.Enabled = true;
            pauseButton.Enabled = false;
            stepButton.Enabled = true;
            resetButton.Enabled = true;
            stopButton.Enabled = true;
            LockWindowUpdate(IntPtr.Zero);
            //  pause
            timer1.Stop();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            if (!sr.EndOfStream)
            {
                this.cycleslabel.Text = cycle.ToString();
                this.instrlabel.Text = instr.ToString();
                this.F_predPC.Text = find(cycle, "F_predPC");
                if (this.F_predPC.Text == "")
                {
                    F_predPC.Text = "0x00000400";
                    runButton.Enabled = false;
                    stepButton.Enabled = false;
                    resetButton.Enabled = true;
                    pauseButton.Enabled = false;
                    stopButton.Enabled = true;
                    return;
                }
                this.D_icode.Text = find(cycle, "D_icode");
                this.D_iFun.Text = find(cycle, "D_ifun");
                this.D_rA.Text = find(cycle, "D_rA");
                this.D_rB.Text = find(cycle, "D_rB");
                this.D_volC.Text = find(cycle, "D_valC");
                this.D_volP.Text = find(cycle, "D_valP");
                this.E_icode.Text = find(cycle, "E_icode");
                this.E_iFun.Text = find(cycle, "E_ifun");
                this.E_volC.Text = find(cycle, "E_valC");
                this.E_volA.Text = find(cycle, "E_valA");
                this.E_volB.Text = find(cycle, "E_valB");
                this.E_dstE.Text = find(cycle, "E_dstE");
                this.E_dstM.Text = find(cycle, "E_dstM");
                this.E_srcA.Text = find(cycle, "E_srcA");
                this.E_srcB.Text = find(cycle, "E_srcB");
                this.M_icode.Text = find(cycle, "M_icode");
                this.M_Bch.Text = find(cycle, "M_Bch");
                this.M_volE.Text = find(cycle, "M_valE");
                this.M_volA.Text = find(cycle, "M_valA");
                this.M_dstE.Text = find(cycle, "M_dstE");
                this.M_dstM.Text = find(cycle, "M_dstM");
                this.W_icode.Text = find(cycle, "W_icode");
                this.W_volE.Text = find(cycle, "W_valE");
                this.W_volM.Text = find(cycle, "W_valM");
                this.W_dstE.Text = find(cycle, "W_dstE");
                this.W_dstM.Text = find(cycle, "W_dstM");
                this.instrlabel.Text = find_instr(cycle);
                this.eaxlabel.Text = find_in_reg(cycle, "%eax");
                this.ebxlabel.Text = find_in_reg(cycle, "%ebx");
                this.ecxlabel.Text = find_in_reg(cycle, "%ecx");
                this.edxlabel.Text = find_in_reg(cycle, "%edx");
                this.edilabel.Text = find_in_reg(cycle, "%edi");
                this.esilabel.Text = find_in_reg(cycle, "%esi");
                this.ebplabel.Text = find_in_reg(cycle, "%ebp");
                this.esplabel.Text = find_in_reg(cycle, "%esp");
                this.M_Z.Text = find_in_reg(cycle, "ZF");
                this.M_O.Text = find_in_reg(cycle, "OF");
                this.M_S.Text = find_in_reg(cycle, "SF");
                this.assmemF.Text = find_loc_in_reg(cycle, "F");
                this.assmemD.Text = find_loc_in_reg(cycle, "D");
                this.assmemE.Text = find_loc_in_reg(cycle, "E");
                this.assmemM.Text = find_loc_in_reg(cycle, "M");
                this.assmemW.Text = find_loc_in_reg(cycle, "W");
                this.asscodeF.Text = find_in_asm(0, assmemF.Text);
                this.asscodeD.Text = find_in_asm(0, assmemD.Text);
                this.asscodeE.Text = find_in_asm(0, assmemE.Text);
                this.asscodeM.Text = find_in_asm(0, assmemM.Text);
                this.asscodeW.Text = find_in_asm(0, assmemW.Text);
                this.F_state.Text = find_in_reg2(cycle, "F");
                if (F_state.Text == "BUB")
                    F_state.ForeColor = Color.Red;
                else
                    if (F_state.Text == "STA")
                        F_state.ForeColor = Color.Blue;
                    else
                        F_state.ForeColor = Color.Black;
                this.D_state.Text = find_in_reg2(cycle, "D");
                if (D_state.Text == "BUB")
                    D_state.ForeColor = Color.Red;
                else
                    if (D_state.Text == "STA")
                        D_state.ForeColor = Color.Blue;
                    else
                        D_state.ForeColor = Color.Black;
                this.E_state.Text = find_in_reg2(cycle, "E");
                if (E_state.Text == "BUB")
                    E_state.ForeColor = Color.Red;
                else
                    if (E_state.Text == "STA")
                        E_state.ForeColor = Color.Blue;
                    else
                        E_state.ForeColor = Color.Black;
                this.M_state.Text = find_in_reg2(cycle, "M");
                if (M_state.Text == "BUB")
                    M_state.ForeColor = Color.Red;
                else
                    if (M_state.Text == "STA")
                        M_state.ForeColor = Color.Blue;
                    else
                        M_state.ForeColor = Color.Black;
                this.W_state.Text = find_in_reg2(cycle, "W");
                if (W_state.Text == "BUB")
                    W_state.ForeColor = Color.Red;
                else
                    if (W_state.Text == "STA")
                        W_state.ForeColor = Color.Blue;
                    else
                        W_state.ForeColor = Color.Black;
                if (add_line(cycle) != "") menBox.Items.Add(add_line(cycle));
                sr.ReadLine();
                cycle++;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            eaxlabel.Text = "0x00000000";
            ebxlabel.Text = "0x00000000";
            ecxlabel.Text = "0x00000000";
            edxlabel.Text = "0x00000000";
            edilabel.Text = "0x00000000";
            esilabel.Text = "0x00000000";
            ebplabel.Text = "0x00000000";
            esplabel.Text = "0x00000000";
            cycleslabel.Text = "0";
            instrlabel.Text = "0";
            W_icode.Text = "0x0";
            W_volE.Text = "0x00000000";
            W_volM.Text = "0x00000000";
            W_dstE.Text = "0x8";
            W_dstM.Text = "0x8";
            M_icode.Text = "0x0";
            M_Bch.Text = "NULL";
            M_volE.Text = "0x00000000";
            M_volA.Text = "0x00000000";
            M_dstE.Text = "0x8";
            M_dstM.Text = "0x8";
            M_Z.Text = "0";
            M_O.Text = "0";
            M_S.Text = "0";
            E_icode.Text = "0x0";
            E_iFun.Text = "0x0";
            E_volC.Text = "0x00000000";
            E_volA.Text = "0x00000000";
            E_volB.Text = "0x00000000";
            E_dstE.Text = "0x8";
            E_dstM.Text = "0x8";
            E_srcA.Text = "0x8";
            E_srcB.Text = "0x8";
            D_icode.Text = "0x0";
            D_iFun.Text = "0x0";
            D_rA.Text = "0x8";
            D_rB.Text = "0x8";
            D_volC.Text = "0x00000000";
            D_volP.Text = "0x00000000";
            F_predPC.Text = "0x00000400";
            F_state.Text = "AOK";
            D_state.Text = "AOK";
            E_state.Text = "AOK";
            M_state.Text = "AOK";
            W_state.Text = "AOK";
            assmemF.Text = "0x00000000";
            assmemD.Text = "0x00000000";
            assmemE.Text = "0x00000000";
            assmemM.Text = "0x00000000";
            assmemW.Text = "0x00000000";
            asscodeF.Text = "";
            asscodeD.Text = "";
            asscodeE.Text = "";
            asscodeM.Text = "";
            asscodeW.Text = "";
            menBox.Items.Clear();
            //  reset
            cycle = instr = 0;
            timer1.Stop();
            sr = new StreamReader(filename + ".txt");
            runButton.Enabled = true;
            stepButton.Enabled = true;
        }

        public string add_line(int n)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_mem.txt");
            String cur_content = sr_tmp.ReadLine();
            bool exists = false;
            string str_tmp = "";
            //while (true)
            while(!sr_tmp.EndOfStream)
            {
                string str = String.Concat("cycle ", n.ToString() + ":");
                exists = (cur_content.Contains(str));
                if (exists) break;
                else
                {
                    if (!sr_tmp.EndOfStream) cur_content = sr_tmp.ReadLine();
                    else return str_tmp;
                }
            }
            if (exists)
            {
                str_tmp = cur_content + " " + sr_tmp.ReadLine();
            }
            return str_tmp;
        }

        public string find_instr(int n)
        {
            StreamReader sr_tmp = new StreamReader(fn + "_reg.txt");
            String cur_content = sr_tmp.ReadLine();
            while (!sr_tmp.EndOfStream)
            {
                string str = String.Concat("Cycle_", n.ToString());
                bool exists = (cur_content.Contains(str));
                if (exists) break;
                else { cur_content = sr_tmp.ReadLine(); }
            }
            string str_tmp2;
            int i;
            for (i = cur_content.Length - 1; ; i--)
                if (cur_content[i] == '_')
                    break;
            str_tmp2 = cur_content.Substring(i + 1);
            return str_tmp2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!sr.EndOfStream)
            {
                this.cycleslabel.Text = cycle.ToString();
                this.F_predPC.Text = find(cycle, "F_predPC");
                if (this.F_predPC.Text == "")
                {
                    F_predPC.Text = "0x00000400";
                    runButton.Enabled = false;
                    stepButton.Enabled = false;
                    resetButton.Enabled = true;
                    pauseButton.Enabled = false;
                    stopButton.Enabled = true;
                    return;
                }
                this.D_icode.Text = find(cycle, "D_icode");
                this.D_iFun.Text = find(cycle, "D_ifun");
                this.D_rA.Text = find(cycle, "D_rA");
                this.D_rB.Text = find(cycle, "D_rB");
                this.D_volC.Text = find(cycle, "D_valC");
                this.D_volP.Text = find(cycle, "D_valP");
                this.E_icode.Text = find(cycle, "E_icode");
                this.E_iFun.Text = find(cycle, "E_ifun");
                this.E_volC.Text = find(cycle, "E_valC");
                this.E_volA.Text = find(cycle, "E_valA");
                this.E_volB.Text = find(cycle, "E_valB");
                this.E_dstE.Text = find(cycle, "E_dstE");
                this.E_dstM.Text = find(cycle, "E_dstM");
                this.E_srcA.Text = find(cycle, "E_srcA");
                this.E_srcB.Text = find(cycle, "E_srcB");
                this.M_icode.Text = find(cycle, "M_icode");
                this.M_Bch.Text = find(cycle, "M_Bch");
                this.M_volE.Text = find(cycle, "M_valE");
                this.M_volA.Text = find(cycle, "M_valA");
                this.M_dstE.Text = find(cycle, "M_dstE");
                this.M_dstM.Text = find(cycle, "M_dstM");
                this.W_icode.Text = find(cycle, "W_icode");
                this.W_volE.Text = find(cycle, "W_valE");
                this.W_volM.Text = find(cycle, "W_valM");
                this.W_dstE.Text = find(cycle, "W_dstE");
                this.W_dstM.Text = find(cycle, "W_dstM");
                this.instrlabel.Text = find_instr(cycle);
                this.eaxlabel.Text = find_in_reg(cycle, "%eax");
                this.ebxlabel.Text = find_in_reg(cycle, "%ebx");
                this.ecxlabel.Text = find_in_reg(cycle, "%ecx");
                this.edxlabel.Text = find_in_reg(cycle, "%edx");
                this.edilabel.Text = find_in_reg(cycle, "%edi");
                this.esilabel.Text = find_in_reg(cycle, "%esi");
                this.ebplabel.Text = find_in_reg(cycle, "%ebp");
                this.esplabel.Text = find_in_reg(cycle, "%esp");
                this.M_Z.Text = find_in_reg(cycle, "ZF");
                this.M_O.Text = find_in_reg(cycle, "OF");
                this.M_S.Text = find_in_reg(cycle, "SF");
                this.assmemF.Text = find_loc_in_reg(cycle, "F");
                this.assmemD.Text = find_loc_in_reg(cycle, "D");
                this.assmemE.Text = find_loc_in_reg(cycle, "E");
                this.assmemM.Text = find_loc_in_reg(cycle, "M");
                this.assmemW.Text = find_loc_in_reg(cycle, "W");
                this.asscodeF.Text = find_in_asm(0, assmemF.Text);
                this.asscodeD.Text = find_in_asm(0, assmemD.Text);
                this.asscodeE.Text = find_in_asm(0, assmemE.Text);
                this.asscodeM.Text = find_in_asm(0, assmemM.Text);
                this.asscodeW.Text = find_in_asm(0, assmemW.Text);
                this.F_state.Text = find_in_reg2(cycle, "F");
                if (F_state.Text == "BUB")
                    F_state.ForeColor = Color.Red;
                else
                    if (F_state.Text == "STA")
                        F_state.ForeColor = Color.Blue;
                    else
                        F_state.ForeColor = Color.Black;
                this.D_state.Text = find_in_reg2(cycle, "D");
                if (D_state.Text == "BUB")
                    D_state.ForeColor = Color.Red;
                else
                    if (D_state.Text == "STA")
                        D_state.ForeColor = Color.Blue;
                    else
                        D_state.ForeColor = Color.Black;
                this.E_state.Text = find_in_reg2(cycle, "E");
                if (E_state.Text == "BUB")
                    E_state.ForeColor = Color.Red;
                else
                    if (E_state.Text == "STA")
                        E_state.ForeColor = Color.Blue;
                    else
                        E_state.ForeColor = Color.Black;
                this.M_state.Text = find_in_reg2(cycle, "M");
                if (M_state.Text == "BUB")
                    M_state.ForeColor = Color.Red;
                else
                    if (M_state.Text == "STA")
                        M_state.ForeColor = Color.Blue;
                    else
                        M_state.ForeColor = Color.Black;
                this.W_state.Text = find_in_reg2(cycle, "W");
                if (W_state.Text == "BUB")
                    W_state.ForeColor = Color.Red;
                else
                    if (W_state.Text == "STA")
                        W_state.ForeColor = Color.Blue;
                    else
                        W_state.ForeColor = Color.Black;
                if (add_line(cycle) != "") menBox.Items.Add(add_line(cycle));
                sr.ReadLine();
                cycle++;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            //  close window and exit.
        }
    }
}