using bai_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // load data khi chạy
            displayAll();
        }
        Utils data = new Utils();

        private void add_btn(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.id = ma_input.Text.Trim();
            nv.hoTen = ten_input.Text.Trim();
            nv.luong = float.Parse(luong_input.Text.Trim());
            nv.tuoi = tuoi_input.Text.Trim();
            nv.xa = xa_input.Text.Trim();
            nv.huyen = huyen_input.Text.Trim();
            nv.tinh = tinh_input.Text.Trim();
            nv.soDienThoai = sodienthoai_input.Text.Trim();

            if (data.checkID(nv.id))
                MessageBox.Show(null, "id " + nv.id + " đã tồn tại trong hệ thống", "Thông báo");
            else
            {
                data.addNhanVien(nv);
                clearInput();

                // view all
                displayAll();
            }

        }

        private void display(List<NhanVien> x)
        {
            view.DataSource = x;
            setCountElemet(x.Count);
        }

        private void displayAll()
        {
            List<NhanVien> tmp = data.getAllDatas();
            display(tmp);
        }
        private void setCountElemet(int n)
        {
            count_label.Text = n.ToString();
        }

        public void clearInput()
        {
            ma_input.Text = "";
            ten_input.Text = "";
            tuoi_input.Text = "";
            luong_input.Text = "";
            xa_input.Text = "";
            huyen_input.Text = "";
            tinh_input.Text = "";
            sodienthoai_input.Text = "";
            ma_input.Focus();
        }


        private void edit_btn(object sender, EventArgs e)
        {
            string id = ma_input.Text.Trim();
            if (data.checkID(id))
            {
                NhanVien nv = new NhanVien();
                nv.id = ma_input.Text.Trim();
                nv.hoTen = ten_input.Text.Trim();
                nv.luong = float.Parse(luong_input.Text.Trim());
                nv.tuoi = tuoi_input.Text.Trim();
                nv.xa = xa_input.Text.Trim();
                nv.huyen = huyen_input.Text.Trim();
                nv.tinh = tinh_input.Text.Trim();
                nv.soDienThoai = sodienthoai_input.Text.Trim();

                data.edit(nv);
                MessageBox.Show(null, "Sửa ID: " + id + " Thành công", "Thông báo");

                displayAll();
            }
            else
            {
                MessageBox.Show(null, "ID: " + id + " không tồn tại trong hệ thống", "Thông báo");
            }
        }

        private void Delete_btn(object sender, EventArgs e)
        {
            string id = ma_input.Text.Trim();
            if (data.checkID(id))
            {
                int x = (int)MessageBox.Show(null, "Xác nhận xóa ID: " + id, "Thông báo", MessageBoxButtons.OKCancel);

                if (x == 1)
                {
                    data.delete(id);
                    MessageBox.Show(null, "Xóa ID: " + id + " Thành công", "Thông báo");
                    displayAll();
                }
            }
            else
            {
                MessageBox.Show(null, "ID: " + id + " không tồn tại trong hệ thống", "Thông báo");
            }
        }

        private void exit_btn(object sender, EventArgs e)
        {
            Close();
        }

        private void view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien nv = (NhanVien)view.CurrentRow.DataBoundItem;
            ma_input.Text = nv.id;
            ten_input.Text = nv.hoTen;
            tuoi_input.Text = nv.tuoi;
            luong_input.Text = nv.luong.ToString();
            xa_input.Text = nv.xa;
            huyen_input.Text = nv.huyen;
            tinh_input.Text = nv.tinh;
            sodienthoai_input.Text = nv.soDienThoai;
        }

        private void search_btn(object sender, EventArgs e)
        {
            string id = ma_input.Text.Trim();
            if (data.checkID(id))
            {
                List<NhanVien> a = data.searchById(id);
                display(a);
            }
            else
            {
                MessageBox.Show(null, "ID: " + id + " không tồn tại trong hệ thống", "Thông báo");
            }
        }

        private void searchByTinh_btn(object sender, EventArgs e)
        {
            string tinh = tinh_input.Text.Trim();
            List<NhanVien> a = data.searchByTinh(tinh);
            display(a);
        }

        private void searchByLuong_btn(object sender, EventArgs e)
        {
            int luong = 1000;
            List<NhanVien> a = data.searchByLuong(luong);
            display(a);
        }
        private void viewAll_btn(object sender, EventArgs e)
        {
            displayAll();
        }
    }
}
