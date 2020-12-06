using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanHangSieuTHi.Class;
using System.Windows.Forms;

namespace BanHangSieuTHi
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int check;
            check = comboBox1.SelectedIndex;
            if(check == 0)
            {
                
                sqlQuery truyVanDL = new sqlQuery();
                DataTable dt = truyVanDL.LayDuLieu("select c.mahang,h.tenhang,l.diengiai,n.soluongnhap,c.soluong,h.soluongsp from LoaiHang as l,ChiTietXuat as c,HangHoa as h,ChiTietNhap as n where c.SoLuong > 5 and h.mahang=c.mahang  and n.mahang=c.mahang and c.maloai=l.maloai");
                listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    item.SubItems.Add(dt.Rows[i][3].ToString());
                    item.SubItems.Add(dt.Rows[i][4].ToString());
                    item.SubItems.Add(dt.Rows[i][5].ToString());
                    listView1.Items.Add(item);
                }
            }else if (check==1)
            {
                listView1.Items.Clear();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            sqlQuery truyVanDL = new sqlQuery();
            DataTable dt = truyVanDL.LayDuLieu("Select diengiai from LOAIHANG");
            DataTable dt1 = truyVanDL.LayDuLieu("Select tenNCC from NHACUNGCAP");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbLoaiHang.Items.Add(dt.Rows[i][0].ToString());            
            }
            for (int j=0; j < dt1.Rows.Count; j++)
            {
                cbNhaCC.Items.Add(dt1.Rows[j][0].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }
            
        }
    }

