using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Supporter

namespace ESNLibrary
{
    public class Supporter
    {
        public Supporter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public System.Data.DataTable LinqToDataTable<T>(System.Collections.Generic.IEnumerable<T> varlist)
        {
            try
            {
                System.Data.DataTable dtReturn = new System.Data.DataTable();
                System.Reflection.PropertyInfo[] oProps = null;
                if (varlist == null) return dtReturn;
                foreach (T rec in varlist)
                {
                    if (oProps == null)
                    {
                        oProps = ((Type)rec.GetType()).GetProperties();
                        foreach (System.Reflection.PropertyInfo pi in oProps)
                        {
                            Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                            == typeof(Nullable<>)))
                            {
                                colType = colType.GetGenericArguments()[0];
                            }
                            dtReturn.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
                        }
                    }
                    System.Data.DataRow dr = dtReturn.NewRow();
                    foreach (System.Reflection.PropertyInfo pi in oProps)
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value :
                        pi.GetValue(rec, null);
                    }
                    dtReturn.Rows.Add(dr);
                }
                return dtReturn;
            }
            catch (Exception ex) { return null; }
        }



        public DataTable ToDataTableAsList<T>(IList<T> data)
        {
            try
            {
                DataTable dt = new DataTable();
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                for (int i = 0; i < props.Count; i++)
                {
                    dt.Columns.Add(props[i].Name);
                }
                foreach (T item in data)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[i] = props[i].GetValue(item);//get current value of the property on a component
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        public ArrayList GetYear()
        {
            ArrayList listYear = new ArrayList();
            for (int i = 2012; i >= 1900; i--)
            {
                listYear.Add(i);
            }
            return listYear;
        }

        public ArrayList GetMonth()
        {
            ArrayList listMonth = new ArrayList();
            for (int i = 1; i <= 12; i++)
            {
                listMonth.Add(i);
            }
            return listMonth;
        }

        public ArrayList BindDays(int year, int month)
        {
            int i;
            ArrayList listDay = new ArrayList();
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    for (i = 1; i <= 31; i++)
                    {
                        listDay.Add(i);
                    }
                    break;
                case 2:
                    if (CheckLeap(year))
                    {
                        for (i = 1; i <= 29; i++)
                        {
                            listDay.Add(i);
                        }
                    }
                    else
                    {
                        for (i = 1; i <= 28; i++)
                        {
                            listDay.Add(i);
                        }
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    for (i = 1; i <= 30; i++)
                    {
                        listDay.Add(i);
                    }
                    break;
            }
            return listDay;
        }

        public bool CheckLeap(int year)
        {
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //flag 0 = gui thu xac nhan tai khoan, 1 = gui thu cap mat khau moi
        public bool SendEmail(string email, string codeActive, int flag)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("eventsocialnetwork@gmail.com");
            message.To.Add(new MailAddress(email));
            message.CC.Add(new MailAddress("eventsocialnetwork@gmail.com"));
            if (flag == 0)
            {
                message.Subject = "Email xác nhận đăng ký mạng xã hội sự kiện ESN ";
                message.Body = "Vui lòng nhấn vào đường dẫn dưới đây để xác nhận đăng ký \n";
                message.Body += ConfigurationSettings.AppSettings["Confirm_URL"] + "?id=" +
                                MD5Encrypt(email) + "&code=" + codeActive + "\n" +
                                "Mã xác nhận: " + codeActive;
            }
            else
            {
                message.Subject = "Email cung cấp mật khẩu mới ";
                message.Body = "Mật khẩu mới của bạn như sau: " + codeActive + "\n" + "Bạn nên đổi mật khẩu trong lần truy cập sắp tới.";
            }
            try
            {
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                //khai báo tài khoản và mật khẩu gửi mail
                NetworkCredential credentials = new NetworkCredential("eventsocialnetwork@gmail.com", "@aptech32d2");
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;
                client.Send(message); //thực hiện gửi mail
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi " + ex.ToString());
                return false;
            }
        }

        public bool CheckInfo(string info, string regex)
        {
            bool rs = true;
            Regex myRegex = new Regex(regex);
            if (string.IsNullOrEmpty(info))
            {
                rs = false;
            }
            else
            {
                rs = myRegex.IsMatch(info);
            }
            return rs;
        }

        public string SetAvatar(string path)
        {
            if (path.Contains("http"))
            {
                return path;
            }
            return @"Images/Avatar/" + path;
        }


        public static string MD5Encrypt(string strPlainText)
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(strPlainText);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }

    }
}