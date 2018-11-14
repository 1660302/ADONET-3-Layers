using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONET_3_Layers_KetNoi;

namespace ADONET_3_Layers_XuLy
{
    public class XuLy
    {
        public DataTable LayDSKhachHang()
        {
            XLyHelper helper = new XLyHelper();
            DataTable dt = helper.LayDSKhachHang();


            return dt;

        }
    }
}
