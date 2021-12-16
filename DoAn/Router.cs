using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class Router
    {
        private string id;
        private string dsx;
        private int ysx;
        private int tocdo;
        private long gia;
        public string getid()
        {
            return id;
        }
        public string getdsx()
        {
            return dsx;
        }
        public int getysx()
        {
            return ysx;
        }
        public int gettocdo()
        {
            return tocdo;
        }
        public long getgia()
        {
            return gia;
        }
        public Router(string id1, string dsx1, int ysx1, int tocdo1, long gia1)
        {
            this.id = id1;
            this.dsx = dsx1;
            this.ysx = ysx1;
            this.tocdo = tocdo1;
            this.gia = gia1;
        }
        public override string ToString()
        {
            return "Router(" + id + ", " + dsx + ", " + ysx + ", " + tocdo + "Mps" + ", " + gia + " đồng)";
        }
    }
}
