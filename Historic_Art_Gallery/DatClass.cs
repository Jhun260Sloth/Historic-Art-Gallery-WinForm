using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace Historic_Art_Gallery
{

    class DatClass
    {
        DataTable ArtGal;
        SqlDataAdapter SqlDA;
        SqlCommand connectadd;
        SqlConnection connectionz;
        string connect;

        public DatClass()
        {
            connect = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ACER\Documents\Visual Studio 2013\Projects\Historic_Art_Gallery\Historic_Art_Gallery\Accounts.mdf;Integrated Security=True";
            connectionz = new SqlConnection(connect);
            connectionz.Open();

           
        }

        public int addregis (string sqladd)
        {
            connectadd = new SqlCommand(sqladd, connectionz);
            return connectadd.ExecuteNonQuery();
        }

        public DataTable GalleryAcc(string sql)
        {
            ArtGal = new DataTable();
            SqlDA = new SqlDataAdapter(sql, connectionz);
            SqlDA.Fill(ArtGal);
            SqlDA.Dispose();
            return ArtGal;
        }
    }


}
