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
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Register()
        {
            InitializeComponent();
            TampilData();
            tbID.Visible = false;
            btEdit.Enabled = false;
            btHapus.Enabled = false;
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string kategori = cbKategori.Text;
            string a = service.Register(username, password, kategori);

            if(tbUsername.Text == "" || tbPassword.Text == "" || cbKategori.Text == "")
            {
                MessageBox.Show("Harap Isi Semua Data");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                Clear();
                TampilData();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string kategori = cbKategori.Text;
            int id = Convert.ToInt32(tbID.Text);
            string a = service.UpdateRegister(username, password, kategori, id);

            if (tbUsername.Text == "" || tbPassword.Text == "" || cbKategori.Text == "")
            {
                MessageBox.Show("Harap Isi Semua Data");
            }
            else
            {
                MessageBox.Show(a);
                Refresh();
                Clear();
                TampilData();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void TampilData()
        {
            var list = service.DataRegist();
            dtRegister.DataSource = list;
        }

        public void Clear()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            cbKategori.SelectedItem = null;

            btSimpan.Enabled = true;
            btEdit.Enabled = false;
            btHapus.Enabled = false;
        }

        private void dtRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[0].Value);
            tbUsername.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[1].Value);
            tbPassword.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[2].Value);
            cbKategori.Text = Convert.ToString(dtRegister.Rows[e.RowIndex].Cells[3].Value);

            btEdit.Enabled = true;
            btHapus.Enabled = true;

            btSimpan.Enabled = false;
        }

        private void btHapus_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;

            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
