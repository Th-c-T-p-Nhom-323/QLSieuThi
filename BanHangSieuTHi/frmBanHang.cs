using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHangSieuTHi.Class;
using System.Collections;

namespace BanHangSieuTHi
{
    public partial class frmBanHang : Form
    {
        SqlCommand cmd;
        sqlQuery truyVanDL = new sqlQuery();
        public frmBanHang()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EJJ3P12;Initial Catalog=QLBanHangSieuThi;Integrated Security=True");

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            
            loadDBSdtKhachHang();
            loadDBComBoxHangHoa();
            loadDBComBoxNhanVien();
        }

        public void loadDBSdtKhachHang()
        {
            DataTable sdt = truyVanDL.LayDuLieu("select * from KHACHHANG ");

            cmbSdtKH.DataSource = sdt;

            cmbSdtKH.DisplayMember = "SdtKH".ToString().Trim();
            cmbSdtKH.SelectedIndex = -1;
        }

        private void cmbSdtKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM KHACHHANG WHERE SdtKH = '" + cmbSdtKH.Text.Trim() + "'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string tenKH = (string)dr["TenKH"].ToString();
                txtTenKH.Text = tenKH;

                string maKH = (string)dr["MaKH"].ToString();
                txtMaKH.Text = maKH;

                string diachi = (string)dr["DiaChiKH"].ToString();
                txtDiaChi.Text = diachi;
            }
            con.Close();
        }

        public void loadDBComBoxHangHoa()
        {           
            DataTable SP = truyVanDL.LayDuLieu("select TenHang from HANGHOA");
            cmbSanPham.DataSource = SP;
            cmbSanPham.DisplayMember = "TenHang".ToString().Trim();
            cmbSanPham.SelectedIndex = -1;
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = "1";
            cmd = new SqlCommand("SELECT MaLoai,MaHang,GiaDeNghi FROM HANGHOA WHERE TenHang = N'" + cmbSanPham.Text.Trim() + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string maLoai = (string)dr["MaLoai"].ToString();
                txtMaLoai.Text = maLoai;

                string maHang = (string)dr["MaHang"].ToString();
                txtMaHang.Text = maHang;

                string donGia = (string)dr["GiaDeNghi"].ToString();
                txtDonGia.Text = donGia;
            }
            con.Close();
        }


        public void loadDBComBoxNhanVien()
        {
            sqlQuery truyvanDL = new sqlQuery();
            DataTable NV = truyvanDL.LayDuLieu("select MaNV from NHANVIEN");
            cmbNhanVien.DataSource = NV;
            cmbNhanVien.DisplayMember = "MaNV";
        }

        public void LoadDatagridView()
        {
            DataTable dt = truyVanDL.LayDuLieu("select * from CHITIETXUAT where SoHDX= '" + txtMaHD.Text.Trim() + "' ");
            dgvSanPham.DataSource = dt;
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
