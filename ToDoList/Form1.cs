using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private BindingList<ListTugas> tugas = new BindingList<ListTugas>();

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void LoadData()
        {

            dgvData.DataSource = tugas.
                Select((lits) => new
                {
                    Tugas = lits.Tugas,
                    Selesai = lits.Selesai,

                }).ToList();
        }

   

        private void btnTambah_Click(object sender, EventArgs e)
        {
            


            var newlist = new ListTugas();
            newlist.Tugas = textBox1.Text.Trim();
            newlist.Selesai = false;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tugas tidak boleh kosong");
                textBox1.Focus();
                return;
            }

            if(tugas.Any(x => x.Tugas.Equals(newlist.Tugas, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tugas Sudah Ada(Duplicate)");
                textBox1.Focus();
                textBox1.Clear();
                return;
            }

            tugas.Add(newlist);
            LoadData();
            MessageBox.Show("Tugas Telah Ditambahkan");
            textBox1.Clear();
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Plilih Tugas Dahulu");
                return;
            }

            int index = dgvData.CurrentRow.Index;

            tugas[index].Selesai =
                !tugas[index].Selesai;
            LoadData();


        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(dgvData.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang ingin dihapus");
                return;
            }

            int index = dgvData.CurrentRow.Index;
            string namaT = tugas[index].Tugas;

            DialogResult result = MessageBox.Show($"Apakah Yakin Ingin Menghapus Data '{namaT}' ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            tugas.RemoveAt(index);

            LoadData();

            MessageBox.Show("Data Berhasil Dihapus");
        }
    }
}
public class ListTugas
{
    public string Tugas { get; set; }
    public bool Selesai { get; set; }

}