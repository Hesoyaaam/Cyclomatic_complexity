using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FITUR
{
    public partial class Form1 : Form
    {
        private string uploadedFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            // Set filter untuk file C dan C++
            openfile.Filter = "Java Files (*.java)|*.java|C++ Files ( *.cpp)|*.cpp|C# Files (*.cs)|*.cs|PHP Files (*.php)|*.php";

            DialogResult result = openfile.ShowDialog();

            if (result == DialogResult.OK)
            {
                uploadedFilePath = openfile.FileName;
                txtdirectory.Text = openfile.FileName;
            }
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uploadedFilePath) && File.Exists(uploadedFilePath))
            {
                try
                {
                    //Memanggil hitung KompleksitasSiklomata
                    KompleksitasSiklomata(uploadedFilePath);
                    //Menampilkan kode yang diupload
                    txtOutput2.Text = uploadedFilePath;

                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"File not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KompleksitasSiklomata(string filePath)
        {
            if (File.Exists(filePath))
            {
                string code = File.ReadAllText(filePath);

                // Hitung jumlah tepi
                int jumlahTepi = HitungTepi(code);

                // Hitung jumlah simpul
                int jumlahSimpul = HitungNode(code);

                // Hitung jumlah Komponen
                int jumlahKomponen = HitungKomponenTerhubung(code);

                // Hitung metrik tambahan sesuai kebutuhan (contoh: panjang rata-rata baris kode)
                double komplesitasSiklomata = jumlahTepi - jumlahSimpul + 2 * jumlahKomponen;

                // Menampilkan metrik di TextBox
                string metrikMessage = $"FileName: {Path.GetFileName(filePath)}\r\n\n" +
                                       $"Total Edges: {jumlahTepi}\r\n" +
                                       $"Total Nodes: {jumlahSimpul}\r\n" +
                                       $"Total Number of Connected Components: {jumlahKomponen}\r\n" +
                                       $"Cyclomatic Complexity (V(G) = E - N + 2P) = {komplesitasSiklomata}\r\n";

                txtOutput.Text = metrikMessage;
                uploadedFilePath = code;
                txtOutput2.Text = filePath;
            }
            else
            {
                MessageBox.Show("File not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static int HitungTepi(string code)
        {
            // Implementasi kompleksitas siklomatik di sini (gunakan metode sebelumnya atau metode lainnya)
            int edgeCount = 0;
            string[] lines = code.Split('\n');

            bool isInIfBlock = false;
            bool isInSwitchBlock = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("if") || trimmedLine.StartsWith("else") || trimmedLine.StartsWith("else if") || trimmedLine.StartsWith("while") ||
                    trimmedLine.StartsWith("for") || trimmedLine.StartsWith("case") || trimmedLine.StartsWith("catch") ||
                    trimmedLine.StartsWith("switch") || trimmedLine.StartsWith("try") || trimmedLine.StartsWith("&&") || trimmedLine.StartsWith("||"))
                {
                    edgeCount++;

                    // Set isInIfBlock ke true ketika memasuki blok "if"
                    if (trimmedLine.StartsWith("if"))
                    {
                        isInIfBlock = true;
                    }
                    // Tambahkan tepi tambahan untuk setiap "else" setelah "if"
                    else if (trimmedLine.StartsWith("else") && isInIfBlock)
                    {
                        edgeCount++;
                    }

                    // Set isInSwitchBlock ke true ketika memasuki blok "switch"
                    if (trimmedLine.StartsWith("switch"))
                    {
                        isInSwitchBlock = true;
                    }
                    // Tambahkan tepi tambahan untuk setiap "case" dalam "switch"
                    else if (trimmedLine.StartsWith("case") && isInSwitchBlock)
                    {
                        edgeCount++;
                    }
                }

                // Set isInIfBlock ke false ketika keluar dari blok "if"
                if (isInIfBlock && trimmedLine.EndsWith("}"))
                {
                    isInIfBlock = false;
                }

                // Set isInSwitchBlock ke false ketika keluar dari blok "switch"
                if (isInSwitchBlock && trimmedLine.EndsWith("}"))
                {
                    isInSwitchBlock = false;
                }
            }
            return edgeCount + 1;
        }

        private int HitungNode(string code)
        {
            // Implementasi kompleksitas siklomatik di sini (gunakan metode sebelumnya atau metode lainnya)
            int nodeCount = 0;
            string[] lines = code.Split('\n');

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("if") || trimmedLine.StartsWith("else") || trimmedLine.StartsWith("else if") || trimmedLine.StartsWith("while") ||
                    trimmedLine.StartsWith("for") || trimmedLine.StartsWith("foreach") || trimmedLine.StartsWith("case") || trimmedLine.StartsWith("catch") ||
                    trimmedLine.StartsWith("switch") || trimmedLine.StartsWith("try") || trimmedLine.Contains("main("))
                {
                    nodeCount++;
                }
            }
            return nodeCount + 1;
        }

        private int HitungKomponenTerhubung(string code)
        {
            int komponenterhubung = 0;

            // Membuat graf kontrol aliran dari kode sumber
            Dictionary<string, List<string>> kontrolAliranGraf = BuatGrafKontrolAliran(code);

            // Menyimpan node yang sudah dikunjungi
            HashSet<string> simpulDikunjungi = new HashSet<string>();

            foreach (var node in kontrolAliranGraf.Keys)
            {
                // Jika node belum dikunjungi, menambahkan komponen terhubung baru
                if (!simpulDikunjungi.Contains(node))
                {
                    penelusuran(node, kontrolAliranGraf, simpulDikunjungi);
                    komponenterhubung++;
                }
            }

            return komponenterhubung;
        }

        private Dictionary<string, List<string>> BuatGrafKontrolAliran(string code)
        {
            Dictionary<string, List<string>> kontrolAliranGraf = new Dictionary<string, List<string>>();
            string[] lines = code.Split('\n');

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                string currentNode = null;

                // Tambahkan node ke graf jika baris kode adalah percabangan atau loop
                if (trimmedLine.StartsWith("if") || trimmedLine.StartsWith("else") || trimmedLine.StartsWith("else if") || trimmedLine.StartsWith("while") ||
                    trimmedLine.StartsWith("for") || trimmedLine.StartsWith("foreach") || trimmedLine.StartsWith("case") || trimmedLine.StartsWith("catch") ||
                    trimmedLine.StartsWith("switch") || trimmedLine.StartsWith("try") || trimmedLine.Contains("main("))
                {
                    // Gunakan percabangan atau loop sebagai node
                    currentNode = trimmedLine;
                    kontrolAliranGraf[currentNode] = new List<string>();
                }

                // Menambahkan sisi ke graf jika terdapat keterhubungan antar node
                if (currentNode != null)
                {
                    foreach (var node in kontrolAliranGraf.Keys)
                    {
                        if (node != currentNode && trimmedLine.Contains(node))
                        {
                            kontrolAliranGraf[currentNode].Add(node);
                        }
                    }
                }
            }

            return kontrolAliranGraf;
        }
        // Konsep ini untuk menelusuri graf kontrol aliran dari kode sumber
        // Mengecek apakah apakah setiap simpul telah dikunjungi dan melanjutkan untuk menjelajahi setiap tetangga yang belum dikunjungi
        private void penelusuran(string node, Dictionary<string, List<string>> graph, HashSet<string> simpulDikunjungi)
        {
            simpulDikunjungi.Add(node);

            foreach (var simpultetangga in graph[node])
            {
                if (!simpulDikunjungi.Contains(simpultetangga))
                {
                    penelusuran(simpultetangga, graph, simpulDikunjungi);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessage = "This testing tool is used to show the complexity of the program.\n" +
                                 "You can upload files in these programming languages: C++, C#, Java, PHP.\n" +
                                 "if less than 10 is low, 10 - 20 is medium, dan more than 20 is high.\n\n" +

                                 "1. Click 'Upload File' to select a source code file.\n" +
                                 "2. Click 'Run' to calculate the metrics.\n" +
                                 "Metrics:\n" +
                                 "- Total Edges (E) \n" +
                                 "- Total Nodes (N) \n" +
                                 "- Total Number of Connected Components (P) \n" +
                                 "- McCabe Cyclomatic Complexity ((V(G) = E - N + 2P)).\n" +
                                 "'If less than 10 is low, 10 - 20 is medium, more than 20 is complex'\n" +
                                 "3. Click 'Export CSV' to save data in a CSV file\n" +
                                 "4. Click 'Clear' to clear all data in this feature";

            MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtdirectory.Clear();
            txtOutput.Clear();
            txtOutput2.Clear();
            uploadedFilePath = string.Empty;
            // Clear any other relevant controls as needed
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutput.Text))
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                    saveFileDialog.Title = "Save Metrics to CSV";
                    saveFileDialog.DefaultExt = "csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string csvFilePath = Path.Combine(saveFileDialog.InitialDirectory, saveFileDialog.FileName);

                        string firstMessage = "Cyclomatic Complexitys\n";
                        string endMessage = "\n Shepperd, M. (1988). Critique of Cyclomatic Complexity As a Software Metric. Software Engineering Journal, 3(2), 30–36. https://doi.org/10.1049/sej.1988.0003\r\n\r\n"; 
                        string contentToWrite = firstMessage + txtOutput.Text + endMessage;

                        // Write the combined content to the selected CSV file
                        File.WriteAllText(csvFilePath, contentToWrite);

                        MessageBox.Show("Metrics saved to CSV file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No metrics to export", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInfo1_Click(object sender, EventArgs e)
        {
            string Info1Message = "Cyclomatic complexity is software metric that provides a quantitative measure of the logical complexity of a program (Pressman2001)";

            MessageBox.Show(Info1Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInfo2_Click(object sender, EventArgs e)
        {
            string Info2Message = "to calculate cyclomatic complexity is as follows: \r\n\r\n" +
                "McCabe Cyclomatic Complexity ((V(G) = E - N + 2P)) and to calculate each matrix is as follows:\r\n\n" +           
                "1. Counting the number of edges, you can count all the arrows or lines that connect the vertices in a control flow graph.\n" +
                "2. Counting A node in a control flow graph represents a point in the program at which execution can begin or end.\n" +
                "3. Calculating Connected Components is a group of nodes in a graph that are connected to each other, but not connected to nodes outside the group.";

            MessageBox.Show(Info2Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
