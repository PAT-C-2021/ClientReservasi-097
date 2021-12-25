using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_20190140097
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();

            TampilData();
            btEdit.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string IDPemesanan = tbID.Text;
            string NamaCustomer = tbNama.Text;
            string NoTelepon = tbNoTlp.Text;
            int JumlahPemesanan = int.Parse(tbJumlah.Text);
            string IDLokasi = tbIDLokasi.Text;

            var a = service.pemesanan(IDPemesanan, NamaCustomer, NoTelepon, JumlahPemesanan, IDLokasi);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            string IDPemesanan = tbID.Text;
            string NamaCustomer = tbNama.Text;
            string NoTelepon = tbNoTlp.Text;

            var a = service.editPemesanan(IDPemesanan, NamaCustomer, NoTelepon);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string IDPemesanan = tbID.Text;

            var a = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        public void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
        }

        public void Clear()
        {
            tbID.Clear();
            tbNama.Clear();
            tbNoTlp.Clear();
            tbJumlah.Clear();
            tbIDLokasi.Clear();

            tbJumlah.Enabled = true;
            tbIDLokasi.Enabled = true;

            btSimpan.Enabled = true;
            btEdit.Enabled = false;
            btHapus.Enabled = false;

            tbID.Enabled = true;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dtPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
            tbNama.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            tbNoTlp.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);
            tbJumlah.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            tbIDLokasi.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);

            tbJumlah.Enabled = false;
            tbIDLokasi.Enabled = false;

            btEdit.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
            tbID.Enabled = false;
        }
    }
}
