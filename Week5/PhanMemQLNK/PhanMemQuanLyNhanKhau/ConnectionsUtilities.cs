using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyNhanKhau
{
    class ConnectionsUtilities
    {
        // trong trường hợp ko cần lấy có thể xem trong file app.config
        // nhanh hơn !!!
        //private static string connectionStringName = "HospitalVer2Entities";

        // sử dụng func này cho dynamic connection
        public static void ChangeDatabase(
            SqlConnectionStringBuilder sqlCnxStringBuilder,
            DbContext source,
            string initialCatalog = "",                     // tên Database
            string dataSource = "",                         // tên Server
            string userId = "",                             // username
            string password = "",                           // mật khẩu
            bool integratedSecuity = true,                  // bảo mật kết nối - mặc định true
            string configConnectionStringName = "")
        /*
         * các thông số truyền vào chuỗi kết nối */
        {
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                // lấy tên của chuỗi kết nối được cấu hình trong file xml app.config
                // ở attribute "name"
                /*var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;*/

                // trong trường hợp ko cần lấy có thể xem trong file app.config
                // nhanh hơn !!!
                //var configNameEf = "HospitalVer2Entities";

                // dda a reference to System.Configuration
                // chuyển thành đối tượng EntityConnectionStringBuilder
                /*var entityCnxStringBuilder = new EntityConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings[connectionStringName].ConnectionString);

                // chuyển thành đối tượng SqlConnectionStringBuilder để truy cập
                // các property
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);*/

                // truyền vào các thông tin cho chuỗi kết nối mới
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                // now flip the properties that were changed
                // cập nhật chuỗi kết nối mới
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception)
            {
                // set log item if required

            }
        }

        // function sử dụng trong trường hợp đã exclude sensitive info
        // tức trong chuỗi connection string ko có passwd thì ta sẽ thêm vào
        public static void setPassword(
            SqlConnectionStringBuilder sqlCnxStringBuilder,
            DbContext source,
            string password)
        {
            sqlCnxStringBuilder.Password = password;

            // cập nhật chuỗi kết nối mới
            source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
        }
    }
}
