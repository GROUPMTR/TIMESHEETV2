using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace TIME_SHEET_SERVICE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_KONTROL_Click(object sender, EventArgs e)
        {
            if (timer_week.Enabled)
            {
                timer_week.Enabled = false;
                BTN_KONTROL.Text = "Haftalık Direktör Onay Mail Gönder Auto Off ";
            }
            else
            {
                timer_week.Enabled = true;
                BTN_KONTROL.Text = "Haftalık Direktör Onay Mail Gönder Auto On ";
            } 

            //string ROW_LINE_ADD = TEXT_DIRECTOR_ONAY_MAILI_LINE.Text;

                
       }


        private void AUTO_WEEK_ONAY()
        {
            //string ROW_LINE_ADD = TEXT_DIRECTOR_ONAY_MAILI_LINE.Text;

            DateTime myDTStart = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            DateTime myDTEnd = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            myDTStart = myDTStart.AddDays(-7);
            myDTEnd = myDTEnd.AddDays(-3);
            DayOfWeek todays = Convert.ToDateTime(myDTStart).DayOfWeek;
            if (todays == DayOfWeek.Monday)
            {

            //mesaj.Append(richTextBox_HEADER.Text.Replace("Dönem,","Dönem: "+myDTStart.ToString("dd.MM.yyyy").ToString() +"-"+ myDTEnd.ToString("dd.MM.yyyy").ToString())); 


            SqlConnection ConUser = new SqlConnection("Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94");
            ConUser.Open();

            SqlConnection ConUserLine = new SqlConnection("Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94");
            ConUserLine.Open();
            string TEXT_DIRECTOR_ONAY_MAILI_TXT = "";
            using (SqlConnection myConnection = new SqlConnection("Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94"))
            {
                myConnection.Open();
                string DIRECTOR_ADI = "";
                using (SqlCommand cmd = new SqlCommand())
                {



                    string HEADER_TABLE_SQL = @"SELECT     dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI.SIRKET_KODU, dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI.DIRECTOR_KODU, dbo.ADM_KULLANICI.UNVANI  
                                                FROM         dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI INNER JOIN
                                                                      dbo.ADM_KULLANICI ON dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI.SIRKET_KODU = dbo.ADM_KULLANICI.SIRKET_KODU
                                                GROUP BY dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI.SIRKET_KODU, dbo.TODO_TIME_SHEET_DIRECTOR_LISTESI.DIRECTOR_KODU, dbo.ADM_KULLANICI.UNVANI, 
                                                                      dbo.ADM_KULLANICI.AKTIF
                                                HAVING      (dbo.ADM_KULLANICI.UNVANI = N'DIRECTOR') AND (dbo.ADM_KULLANICI.AKTIF = 1) ";

                    cmd.CommandText = HEADER_TABLE_SQL;
                    cmd.Connection = myConnection;
                    SqlDataReader myReader = cmd.ExecuteReader();
                    string KULLANICI_ADI = "", USER_MAIL_ADRESI = "", ROW_EKLE = "";
                    string SIRKET_KODU = "";

                    while (myReader.Read())
                    {
                        string _KAYIT = "YOK";
                        string _ONAY = "TRUE";
                        StringBuilder mesaj = new StringBuilder();
                        TEXT_DIRECTOR_ONAY_MAILI_TXT = "";
                        TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI.Text;

                        DIRECTOR_ADI = myReader["DIRECTOR_KODU"].ToString();
                        SIRKET_KODU = myReader["SIRKET_KODU"].ToString();
                        KULLANICI_ADI = ""; USER_MAIL_ADRESI = ""; ROW_EKLE = "";
                        double TotalDay = 0, TotalOran = 0;

                        string HEADER_USER_SQL = @" SELECT     dbo.TODO_TIME_SHEET.SIRKET_KODU, dbo.TODO_TIME_SHEET.ONAY_DIREKTOR, dbo.TODO_TIME_SHEET.MAIL_ADRESI 
                                FROM      dbo.TODO_TIME_SHEET INNER JOIN
                                          dbo.ADM_KULLANICI ON dbo.TODO_TIME_SHEET.MAIL_ADRESI = dbo.ADM_KULLANICI.MAIL_ADRESI
                                WHERE     (dbo.TODO_TIME_SHEET.StartDate >= CONVERT(DATETIME, '" + myDTStart.ToString("yyyy-MM-dd").ToString() + "', 102))  AND (EndDate <= CONVERT(DATETIME,'" + myDTEnd.ToString("yyyy-MM-dd").ToString() + "', 102)) GROUP BY dbo.TODO_TIME_SHEET.MAIL_ADRESI, dbo.TODO_TIME_SHEET.SIRKET_KODU, dbo.TODO_TIME_SHEET.ONAY_DIREKTOR, dbo.TODO_TIME_SHEET.ONAY_DURUMU, dbo.ADM_KULLANICI.AKTIF  HAVING  (dbo.TODO_TIME_SHEET.ONAY_DIREKTOR = N'" + myReader["DIRECTOR_KODU"] + "')   AND   (dbo.TODO_TIME_SHEET.ONAY_DURUMU IS NULL) AND   (dbo.ADM_KULLANICI.AKTIF = 1)  ";
                        using (SqlCommand cmdUser = new SqlCommand())
                        {
                            cmdUser.CommandText = HEADER_USER_SQL;
                            cmdUser.Connection = ConUser;
                            SqlDataReader rdrUser = cmdUser.ExecuteReader();
                            while (rdrUser.Read())
                            {
                                _KAYIT = "VAR";

                                TotalDay = 0; TotalOran = 0;
                                KULLANICI_ADI = rdrUser["MAIL_ADRESI"].ToString().Replace("@groupm.com", "").Replace("@mediacom.com", "").Replace("@mecglobal.com", "").Replace("@mindshareworld.com", "").Replace("@maxusglobal.com", "");
                                USER_MAIL_ADRESI = rdrUser["MAIL_ADRESI"].ToString();
                                string _USER_LINE_SQL = "";
                                DateTime DTStart = myDTStart; ;
                                DateTime DTEnd = myDTStart; ;
                                for (int i = 1; i <= 5; i++)
                                {
                                    if (i > 1) _USER_LINE_SQL += "UNION ALL";
                                    _USER_LINE_SQL += " SELECT      StartDate,  EndDate ,      (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))/60.0) as SURE , (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))*100)/ (60.0*45) as ORAN  " +
                                                      " FROM       dbo.TODO_TIME_SHEET " +
                                                      " WHERE     (ONAY_DIREKTOR = N'" + rdrUser["ONAY_DIREKTOR"] + "') AND (ONAY_DURUMU IS NULL) AND (StartDate >= CONVERT(DATETIME, '" + DTStart.ToString("yyyy-MM-dd").ToString() + " 08:00:00', 102))  AND (EndDate <= CONVERT(DATETIME,'" + DTEnd.ToString("yyyy-MM-dd").ToString() + " 23:59:00', 102))  AND (MAIL_ADRESI = N'" + rdrUser["MAIL_ADRESI"] + "')" +
                                                      " group by StartDate,  EndDate  " +
                                                      " UNION ALL " +
                                                      " SELECT     StartDate,  EndDate ,      (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))/60.0) as SURE , (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))*100)/ (60.0*45) as ORAN   " +
                                                      " FROM       dbo.ADM_TATILER " +
                                                      " WHERE      (StartDate >= CONVERT(DATETIME, '" + DTStart.ToString("yyyy-MM-dd").ToString() + " 08:00:00', 102)) AND     (EndDate <= CONVERT(DATETIME, '" + DTEnd.ToString("yyyy-MM-dd").ToString() + " 23:59:00', 102))  " +
                                                      " group by StartDate,  EndDate ";
                                    DTStart = DTStart.AddDays(1);
                                    DTEnd = DTEnd.AddDays(1);
                                }
                                double PAZARTESI = 0, SALI = 0, CARSAMBA = 0, PERSEMBE = 0, CUMA = 0;
                                using (SqlCommand cmdUserLine = new SqlCommand())
                                {
                                    cmdUserLine.CommandText = _USER_LINE_SQL;
                                    cmdUserLine.Connection = ConUserLine;
                                    SqlDataReader rdrUserLine = cmdUserLine.ExecuteReader();
                                    while (rdrUserLine.Read())
                                    {
                                        //Pazartesi Monday 
                                        //Salı Tuesday 
                                        //Çarşamba Wednesday 
                                        //Perşembe Thursday 
                                        //Cuma Friday 
                                        //Cumartesi Saturday  

                                        DayOfWeek today = Convert.ToDateTime(rdrUserLine["StartDate"].ToString()).DayOfWeek;
                                        // Test current day of week.
                                        if (today == DayOfWeek.Monday)
                                        {
                                            PAZARTESI += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                        }
                                        if (today == DayOfWeek.Tuesday)
                                        {
                                            SALI += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                        }
                                        if (today == DayOfWeek.Wednesday)
                                        {
                                            CARSAMBA += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                        }
                                        if (today == DayOfWeek.Thursday)
                                        {
                                            PERSEMBE += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                        }
                                        if (today == DayOfWeek.Friday)
                                        {
                                            CUMA += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                        }

                                        TotalDay += Convert.ToDouble(rdrUserLine["SURE"].ToString());
                                    }
                                    rdrUserLine.Close();
                                }

                                TotalOran = ((TotalDay / 45) * 100);

                                if (TotalOran < 100.0)
                                {
                                    if (_ONAY == "TRUE") _ONAY = "FALSE";
                                }

                                string DETAY = String.Format("<a href='http://10.219.168.91/TimeSheet_DetaySchedule.aspx?USER_NAME={0}&START_DATE={1}&END_DATE={2}&FIRMAID={3}&DIRECTOR={4}'> Detay </a> ", USER_MAIL_ADRESI, myDTStart.ToString("yyyy-MM-dd").ToString(), myDTEnd.ToString("yyyy-MM-dd").ToString(), myReader["SIRKET_KODU"], DIRECTOR_ADI);
                                string UYARI = String.Format("<a href='http://10.219.168.91/TimeSheet_Uyari.aspx?USER_NAME={0}&START_DATE={1}&END_DATE={2}&FIRMAID={3}&DIRECTOR={4}'> Uyarı </a> ", USER_MAIL_ADRESI, myDTStart.ToString("yyyy-MM-dd").ToString(), myDTEnd.ToString("yyyy-MM-dd").ToString(), myReader["SIRKET_KODU"], DIRECTOR_ADI);

                                string ROW_LINE_ADD = TEXT_DIRECTOR_ONAY_MAILI_LINE.Text;
                                ROW_EKLE += ROW_LINE_ADD.ToString().Replace("KULLANICI_ADI", KULLANICI_ADI).Replace("PAZARTESI", PAZARTESI.ToString()).Replace("SALI", SALI.ToString()).Replace("CARSAMBA", CARSAMBA.ToString()).Replace("PERSEMBE", PERSEMBE.ToString()).Replace("CUMA", CUMA.ToString()).Replace("TOPLAM", TotalDay.ToString()).Replace("BILGI", DETAY + " / " + UYARI).ToString();
                            }
                            rdrUser.Close();
                        }

                        if (_KAYIT == "VAR")
                        {

                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT.Replace("DONEM", String.Format("{0}-{1}", myDTStart.ToString("dd.MM.yyyy"), myDTEnd.ToString("dd.MM.yyyy")));
                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT;
                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT.Replace("TABLE_ROW_INSERT", ROW_EKLE.ToString());
                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT;
                            string ONAY_LINKIM = "";
                            if (_ONAY == "TRUE")
                            {
                                ONAY_LINKIM = String.Format("<a href='http://10.219.168.91/TimeSheet_Onay.aspx?START_DATE={0}&END_DATE={1}&FIRMAID={2}&DIRECTOR={3}'style='text-decoration: none; color: white;'><strong>TimeSheet verilerini onaylamak için tıklayınız.</strong>", myDTStart.ToString("yyyy-MM-dd").ToString(), myDTEnd.ToString("yyyy-MM-dd").ToString(), SIRKET_KODU, DIRECTOR_ADI);
                            }
                            else
                            {
                                ONAY_LINKIM = "<strong>TimeSheet verileri eksik onaylayamazsınız.<br> Verilerin tamamlanması için kullanıcılarınızı uyarınız.</strong>";
                            }

                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT.Replace("ONAY_LINKI", ONAY_LINKIM);
                            TEXT_DIRECTOR_ONAY_MAILI_TXT = TEXT_DIRECTOR_ONAY_MAILI_TXT;

                            WebServiceSendMail.SALES_INVOICES fr = new WebServiceSendMail.SALES_INVOICES();
                            mesaj.Append(TEXT_DIRECTOR_ONAY_MAILI_TXT);//DIRECTOR_ADI
                            fr.SendMailAsync("noreply.TimeSheet@groupm.com", DIRECTOR_ADI, "" + myDTStart.ToString("dd.MM.yyyy").ToString() + " - " + myDTEnd.ToString("dd.MM.yyyy").ToString() + " TimeSheet onay/bilgilendirme mailidir. ", mesaj.ToString(), "");
                            fr.SendMailCompleted += fr_SendMailCompleted;
                        }
                    }

                }
            }
            }
        }
         
 
        private void fr_SendMailCompleted(object sender, WebServiceSendMail.SendMailCompletedEventArgs e)
        {
            //  throw new NotImplementedException();
        }

        private void BTN_FINANSA_DIREKTOR_RAPORLA_Click(object sender, EventArgs e)
        {
            DateTime myDTStart = Convert.ToDateTime(dateTimePicker_START_DATE.Value);
            DateTime myDTEnd = Convert.ToDateTime(dateTimePicker_END_DATE.Value);
            string SQL_PATH = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94";
            SqlConnection ConUser = new SqlConnection(SQL_PATH);
            ConUser.Open();
            SqlConnection ConUserLine = new SqlConnection(SQL_PATH);
            ConUserLine.Open();
            string _TEXT_TIME_SHEET_KULLANMAYANLAR = "";
            using (SqlConnection myConnection = new SqlConnection(SQL_PATH))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    string HEADER_USER_SQL = @"SELECT     SIRKET_KODU,  FINANS_GRUP_MAIL FROM         dbo.ADM_SIRKET  where TIME_SHEET='True'  ";
                    using (SqlCommand cmdUser = new SqlCommand())
                    {
                        cmdUser.CommandText = HEADER_USER_SQL;
                        cmdUser.Connection = ConUser;
                        SqlDataReader rdrUser = cmdUser.ExecuteReader();
                        while (rdrUser.Read())
                        {
                            StringBuilder mesaj = new StringBuilder();
                            string ONAY_DIREKTOR = "";
                            string _USER_LINE_SQL = @"  SELECT     TOP (100) PERCENT dbo.TODO_TIME_SHEET.ONAY_DIREKTOR, dbo.TODO_TIME_SHEET.SIRKET_KODU FROM         dbo.TODO_TIME_SHEET INNER JOIN "+
                                                    "  dbo.ADM_SIRKET ON dbo.TODO_TIME_SHEET.SIRKET_KODU = dbo.ADM_SIRKET.SIRKET_KODU WHERE     (dbo.TODO_TIME_SHEET.ONAY_DURUMU IS NULL) AND (dbo.ADM_SIRKET.TIME_SHEET = 1) AND  (dbo.TODO_TIME_SHEET.StartDate >= CONVERT(DATETIME, '" + myDTStart.ToString("yyyy-MM-dd").ToString() + "', 102))  AND (EndDate <= CONVERT(DATETIME,'" + myDTEnd.ToString("yyyy-MM-dd").ToString() + "', 102)) "+
                                                    " GROUP BY dbo.TODO_TIME_SHEET.ONAY_DIREKTOR, dbo.TODO_TIME_SHEET.SIRKET_KODU " +
                                                    " HAVING  (dbo.TODO_TIME_SHEET.SIRKET_KODU = N'" + rdrUser["SIRKET_KODU"].ToString ()+ "') ORDER BY dbo.TODO_TIME_SHEET.SIRKET_KODU ";
                            using (SqlCommand cmdUserLine = new SqlCommand())
                            {
                                cmdUserLine.CommandText = _USER_LINE_SQL;
                                cmdUserLine.Connection = ConUserLine;
                                SqlDataReader rdrUserLine = cmdUserLine.ExecuteReader();
                                while (rdrUserLine.Read())
                                {
                                    ONAY_DIREKTOR += rdrUserLine["ONAY_DIREKTOR"].ToString() + "<br>";
                                }
                                rdrUserLine.Close();
                            }

                            _TEXT_TIME_SHEET_KULLANMAYANLAR = "";
                            _TEXT_TIME_SHEET_KULLANMAYANLAR = TEXT_TIME_SHEET_KULLANMAYANLAR.Text;
                            _TEXT_TIME_SHEET_KULLANMAYANLAR = _TEXT_TIME_SHEET_KULLANMAYANLAR.Replace("DONEM", ONAY_DIREKTOR);

                            WebServiceSendMail.SALES_INVOICES fr = new WebServiceSendMail.SALES_INVOICES();
                            mesaj.Append(_TEXT_TIME_SHEET_KULLANMAYANLAR);//DIRECTOR_ADI
                            fr.SendMailAsync("noreply.TimeSheet_Uyari@groupm.com", rdrUser["FINANS_GRUP_MAIL"].ToString(), "TimeSheet verisi onaylamayanlar bilgilendirme mailidir. ", mesaj.ToString(), "");
                            fr.SendMailCompleted += fr_SendMailCompleted;


                        }
                    }
                }
            }
            
 
        }
        private DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;
            oDE = new DirectoryEntry("LDAP://10.219.168.51", "" + TXT_USERNAME.Text + "", "" + TXT_PASSWORDS.Text + "", AuthenticationTypes.Secure);
            //oDE = new DirectoryEntry("LDAP://ISTADCP01101", "" + TXT_USERNAME.Text + "", "" + TXT_PASSWORDS.Text + "", AuthenticationTypes.Secure);
            return oDE;
        }

        private void BTN_USER_DISABLE_Click(object sender, EventArgs e)
        {
            //string manage = "SELECT * FROM Win32_NetworkAdapter";
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            //ManagementObjectCollection collection = searcher.Get();
            //List<string> netWorkList = new List<string>();
            //foreach (ManagementObject obj in collection)
            //{
            //    if (obj["Name"].ToString() == "Qualcomm Atheros AR5B97 Wireless Network Adapter")
            //    {
            //        DisableNetWork(obj);//disable network
            //        Thread.Sleep(3000);
            //        EnableNetWork(obj);//enable network
            //        return;
            //    }
            //}


            //SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");
            //ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            //foreach (ManagementObject result in search.Get())
            //{
            //    NetworkAdapter adapter = new NetworkAdapter(result);

            //    // Identify the adapter you wish to disable here. 
            //    // In particular, check the AdapterType and 
            //    // Description properties.

            //    // Here, we're selecting the LAN adapters.
            //    if (adapter.AdapterType.Equals("Ethernet 802.3"))
            //    {
            //        adapter.Disable();
            //    }
            //}

            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://10.219.168.51/OU=Users,OU=ist,OU=emea,DC=ad,DC=insidemedia,DC=net", "" + TXT_USERNAME.Text + "", "" + TXT_PASSWORDS.Text + "", AuthenticationTypes.Secure);

            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = "(objectCategory=user)";
            foreach (SearchResult item in directorySearcher.FindAll())
            {
                DirectoryEntry directoryEntryItem = item.GetDirectoryEntry();

                if (directoryEntryItem.Properties["mail"].Value!=null)
                {
                    if (directoryEntryItem.Properties["mail"].Value.ToString()  == TXT_LOCK_USERNAME.Text )
                    {
                        DirectoryEntry userEntry = item.GetDirectoryEntry();

                        int old_UAC = (int)userEntry.Properties["userAccountControl"][0];

                        // AD user account disable flag
                        int ADS_UF_ACCOUNTDISABLE = 2;

                        // To disable an ad user account, we need to set the disable bit/flag:
                        userEntry.Properties["userAccountControl"][0] = (old_UAC | ADS_UF_ACCOUNTDISABLE);
                        userEntry.CommitChanges();
                     }
               }

            }



           //DirectoryEntry de = GetDirectoryObject();




           // DirectorySearcher searcher = new DirectorySearcher(de);

           //searcher.SearchRoot = de;
           //searcher.Filter = "(&(objectClass=user)(SAMAccountName=" + TXT_LOCK_USERNAME.Text + "))";

           // SearchResult searchResult = searcher.FindOne();
           // if (searcher != null)
           // {
           //     DirectoryEntry userEntry = searchResult.GetDirectoryEntry();

           //     int old_UAC = (int)userEntry.Properties["userAccountControl"][0];

           //     // AD user account disable flag
           //     int ADS_UF_ACCOUNTDISABLE = 2;

           //     // To disable an ad user account, we need to set the disable bit/flag:
           //     userEntry.Properties["userAccountControl"][0] = (old_UAC | ADS_UF_ACCOUNTDISABLE);
           //     userEntry.CommitChanges();

           //     //Console.WriteLine("Active Director User Account Disabled successfully 
           //     //                    through userAccountControl property");
           // }
           // else
           // {
           //     //AD User Not Found
           // }









            //DirectorySearcher deSearch = new DirectorySearcher();
            //deSearch.SearchRoot = de;
            //deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + TXT_LOCK_USERNAME.Text + "))";
            //deSearch.PropertiesToLoad.Add("mail");
            //deSearch.PropertiesToLoad.Add("userPrincipalName");
            //SortOption Srt;
            //Srt = new SortOption("mail", System.DirectoryServices.SortDirection.Ascending);
            //deSearch.Sort = Srt;
            ////Sonuçları bir değişkene atalım.
            //try
            //{
            //    SearchResultCollection Results = deSearch.FindAll();
            //    if (Results != null)
            //    {
            //        foreach (SearchResult Result in Results)
            //        {
            //            ResultPropertyCollection Rpc = Result.Properties;
            //            foreach (string Property in Rpc.PropertyNames)
            //            {
            //               string UserMail = Rpc["userPrincipalName"][0].ToString();
            //            }
            //        }
            //    }
            //    Close();
            //}
            //catch (Exception EX) { MessageBox.Show("Kullanıcı adı veya Password geçersiz."); }
        }

    private static void DisableADUserUsingUserAccountControl(string username)
    {
        try
        {
             DirectoryEntry domainEntry = Domain.GetCurrentDomain().GetDirectoryEntry();
          
            // ldap filter
            string searchFilter = string.Format(@"(&(objectCategory=person)(objectClass=user)
                  (!sAMAccountType=805306370)(|(userPrincipalName={0})(sAMAccountName={0})))", username);

            DirectorySearcher searcher = new DirectorySearcher(domainEntry, searchFilter);
            SearchResult searchResult = searcher.FindOne();
            if (searcher != null)
            {
                DirectoryEntry userEntry = searchResult.GetDirectoryEntry();

                int old_UAC = (int)userEntry.Properties["userAccountControl"][0];

                // AD user account disable flag
                int ADS_UF_ACCOUNTDISABLE = 2;

                // To disable an ad user account, we need to set the disable bit/flag:
                userEntry.Properties["userAccountControl"][0] = (old_UAC | ADS_UF_ACCOUNTDISABLE);
                userEntry.CommitChanges();

                //Console.WriteLine("Active Director User Account Disabled successfully 
                //                    through userAccountControl property");
            }
            else
            {
                //AD User Not Found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void BTN_GUNLUK_TIME_SHEET_KONTROL_Click(object sender, EventArgs e)
    {
            GUNLUK_TIME_SHEET_KONTROL();

        if (timer1.Enabled)
        {
            timer1.Enabled = false;
            BTN_GUNLUK_TIME_SHEET_KONTROL.Text = "Günlük Kullanıcı Uyarı Mail Gönder Auto Off ";
        }
        else
        { timer1.Enabled = true;
            BTN_GUNLUK_TIME_SHEET_KONTROL.Text = "Günlük Kullanıcı Uyarı Mail Gönder Auto On ";
        } 
    }

    private void GUNLUK_TIME_SHEET_KONTROL()
    { 
        string SQL_PATH = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94";
        //DateTime myDTStart = Convert.ToDateTime(DateTime.Now.AddDays(-1));
        DateTime myDTStart = Convert.ToDateTime(dateTimePicker_START_DATE.Value);
        myDTStart = myDTStart.AddDays(-1);
        DayOfWeek today = Convert.ToDateTime(myDTStart).DayOfWeek;

        if (today == DayOfWeek.Sunday)
        { 
            myDTStart = myDTStart.AddDays(-1);
            today = Convert.ToDateTime(myDTStart).DayOfWeek;  
        }
        if (today == DayOfWeek.Saturday)
        {
            myDTStart = myDTStart.AddDays(-1);
            today = Convert.ToDateTime(myDTStart).DayOfWeek; 
        } 
       
        //   DateTime myDTEnd = Convert.ToDateTime(DateTime.Now);
        SqlConnection ConUser = new SqlConnection(SQL_PATH);
        ConUser.Open();
        SqlConnection ConUserLine = new SqlConnection(SQL_PATH);
        ConUserLine.Open();
        string TEXT_KULLANICI_UYARI_MAILI_TXT = "";
        using (SqlConnection myConnection = new SqlConnection(SQL_PATH))
        {
            myConnection.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                double TotalDay = 0, TotalOran = 0;
                string HEADER_USER_SQL = @"SELECT     SIRKET_KODU, MAIL_ADRESI,ADI,SOYADI, TIMESHEET_KULLANICISI FROM dbo.ADM_KULLANICI WHERE     (TIMESHEET_KULLANICISI = 1) and (AKTIF=1) ";
                using (SqlCommand cmdUser = new SqlCommand())
                {
                    cmdUser.CommandText = HEADER_USER_SQL;
                    cmdUser.Connection = ConUser;
                    SqlDataReader rdrUser = cmdUser.ExecuteReader();
                    while (rdrUser.Read())
                    {
                        StringBuilder mesaj = new StringBuilder();
                        TEXT_KULLANICI_UYARI_MAILI_TXT = "";
                        TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_KULLANCI_UYARI_MAILI.Text;
                        TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_KULLANICI_UYARI_MAILI_TXT.Replace("TARIHI", String.Format("{0}", myDTStart.ToString("dd.MM.yyyy")));
                        TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_KULLANICI_UYARI_MAILI_TXT.Replace("ADI_SOYADI", rdrUser["ADI"].ToString() + " " + rdrUser["SOYADI"].ToString());
                        int kontrol = 0;
                        TotalDay = 0; TotalOran = 0;
                        string _USER_LINE_SQL = "";
                        DateTime DTStart = myDTStart;
                        DateTime dt = DTStart;

                        if (dt.DayOfWeek == DayOfWeek.Saturday) dt = DTStart = DTStart.AddDays(-1);
                        if (dt.DayOfWeek == DayOfWeek.Sunday) dt = DTStart = DTStart.AddDays(-1);

                        _USER_LINE_SQL = " SELECT SUM(SURE) AS SURE FROM (SELECT StartDate, EndDate, (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))/60.0) as SURE  " +
                                          " FROM      dbo.TODO_TIME_SHEET " +
                                          " WHERE     (StartDate >= CONVERT(DATETIME, '" + DTStart.ToString("yyyy-MM-dd").ToString() + " 08:00:00', 102))  AND (EndDate <= CONVERT(DATETIME,'" + DTStart.ToString("yyyy-MM-dd").ToString() + " 23:59:00', 102))  AND (MAIL_ADRESI = N'" + rdrUser["MAIL_ADRESI"] + "')" +
                                          " GROUP BY StartDate, EndDate " +
                                          " UNION ALL " +
                                          " SELECT StartDate, EndDate,   (DATEDIFF(MINUTE,MIN(StartDate), Max(EndDate))/60.0) as SURE   " +
                                          " FROM       dbo.ADM_TATILER " +
                                          " WHERE      (StartDate >= CONVERT(DATETIME, '" + DTStart.ToString("yyyy-MM-dd").ToString() + " 08:00:00', 102)) AND     (EndDate <= CONVERT(DATETIME, '" + DTStart.ToString("yyyy-MM-dd").ToString() + " 23:59:00', 102))  " +
                                          " GROUP BY StartDate, EndDate ) TOTAL_TIME ";

                        using (SqlCommand cmdUserLine = new SqlCommand())
                        {
                            cmdUserLine.CommandText = _USER_LINE_SQL;
                            cmdUserLine.Connection = ConUserLine;
                            SqlDataReader rdrUserLine = cmdUserLine.ExecuteReader();
                            if (!rdrUserLine.HasRows) kontrol++;
                            while (rdrUserLine.Read())
                            {
                                double SURESI = 0;
                                if (rdrUserLine["SURE"] != DBNull.Value) SURESI = Convert.ToDouble(rdrUserLine["SURE"].ToString());

                                if (SURESI < 9.0)
                                {
                                    WebServiceSendMail.SALES_INVOICES fr = new WebServiceSendMail.SALES_INVOICES();
                                    mesaj.Append(TEXT_KULLANICI_UYARI_MAILI_TXT);//DIRECTOR_ADI
                                    fr.SendMailAsync("noreply.TimeSheet_Uyari@groupm.com", rdrUser["MAIL_ADRESI"].ToString(), "" + myDTStart.ToString("dd.MM.yyyy").ToString() + " TimeSheet onay/bilgilendirme mailidir. ", mesaj.ToString(), "");
                                    fr.SendMailCompleted += fr_SendMailCompleted;
                                }
                            }
                            rdrUserLine.Close();
                        }
                    }
                }
            }
        }    
    }

    private void BTN_TIMESHEET_KULLANMAYANLAR_Click(object sender, EventArgs e)
    {
         

        string SQL_PATH = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94"; 
        SqlConnection ConUser = new SqlConnection(SQL_PATH);
        ConUser.Open();
        SqlConnection ConUserLine = new SqlConnection(SQL_PATH);
        ConUserLine.Open();
        string _TEXT_TIME_SHEET_KULLANMAYANLAR = "";
        using (SqlConnection myConnection = new SqlConnection(SQL_PATH))
        {
            myConnection.Open();
            using (SqlCommand cmd = new SqlCommand())
            {

                string HEADER_USER_SQL = @"SELECT     SIRKET_KODU,  DIRECTOR_GRUP_MAIL FROM         dbo.ADM_SIRKET  where DIRECTOR_GRUP_MAIL IS NOT NULL  ";
                using (SqlCommand cmdUser = new SqlCommand())
                {
                    cmdUser.CommandText = HEADER_USER_SQL;
                    cmdUser.Connection = ConUser;
                    SqlDataReader rdrUser = cmdUser.ExecuteReader();
                    while (rdrUser.Read())
                    {
                        StringBuilder mesaj = new StringBuilder();

                        string ADI_SOYADI = "";
                      string    _USER_LINE_SQL = @" SELECT   dbo.ADM_KULLANICI.SIRKET_KODU, dbo.ADM_KULLANICI.ADI, dbo.ADM_KULLANICI.SOYADI, dbo.ADM_KULLANICI.UNVANI,  dbo.ADM_KULLANICI.MAIL_ADRESI " +
                                         "  FROM    dbo.ADM_KULLANICI LEFT OUTER JOIN   dbo.TODO_TIME_SHEET ON dbo.ADM_KULLANICI.MAIL_ADRESI = dbo.TODO_TIME_SHEET.MAIL_ADRESI WHERE     (dbo.TODO_TIME_SHEET.MAIL_ADRESI IS NULL) AND (dbo.ADM_KULLANICI.TIMESHEET_KULLANICISI = 1) AND (dbo.ADM_KULLANICI.SIRKET_KODU = N'MDS') " +
                                         " ORDER BY dbo.ADM_KULLANICI.ADI ";

                         using (SqlCommand cmdUserLine = new SqlCommand())
                        {
                            cmdUserLine.CommandText = _USER_LINE_SQL;
                            cmdUserLine.Connection = ConUserLine;
                            SqlDataReader rdrUserLine = cmdUserLine.ExecuteReader();
                        
                            while (rdrUserLine.Read())
                            {
                                ADI_SOYADI += rdrUserLine["ADI"].ToString() + " " + rdrUserLine["SOYADI"].ToString() + "<br>";
                            }
                            rdrUserLine.Close();
                        }

                         _TEXT_TIME_SHEET_KULLANMAYANLAR = "";
                         _TEXT_TIME_SHEET_KULLANMAYANLAR = TEXT_TIME_SHEET_KULLANMAYANLAR.Text;
                         _TEXT_TIME_SHEET_KULLANMAYANLAR = _TEXT_TIME_SHEET_KULLANMAYANLAR.Replace("ADI_SOYADI", ADI_SOYADI);

                         WebServiceSendMail.SALES_INVOICES fr = new WebServiceSendMail.SALES_INVOICES();
                         mesaj.Append(_TEXT_TIME_SHEET_KULLANMAYANLAR);//DIRECTOR_ADI rdrUser["DIRECTOR_GRUP_MAIL"].ToString ()
                         fr.SendMailAsync("noreply.TimeSheet_Uyari@groupm.com", rdrUser["DIRECTOR_GRUP_MAIL"].ToString(), "TimeSheet verisi girmeyenler bilgilendirme mailidir. ", mesaj.ToString(), "");
                         fr.SendMailCompleted += fr_SendMailCompleted;


                    }
                }
            }
        } 

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (textBox5.Text == DateTime.Now.ToLongTimeString())
        {
            GUNLUK_TIME_SHEET_KONTROL();
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void timer_week_Tick(object sender, EventArgs e)
    {
        if (textBox_Week_Time.Text == DateTime.Now.ToLongTimeString())
        {
            AUTO_WEEK_ONAY();
        }
    }

    private void btn_PDKS_KONTROL_Click(object sender, EventArgs e)
    {

        TimeSpan ixt = Convert.ToDateTime(dt_END_DATE.Value) - Convert.ToDateTime(dt_START_DATE.Value);
        //int Colums = ts.Days;//(ts.Days / 365); 
      //  return ixt.Days; 

        string SQL_PATH = "Password=tr1net784;Persist Security Info=True;User ID=login;Initial Catalog=VISION;Data Source=10.219.168.94";



        using (SqlConnection MySqlConnection = new SqlConnection(SQL_PATH.ToString()))
        {

                DateTime myDTStart = Convert.ToDateTime(dt_START_DATE.Value);
                DateTime myDTEND = Convert.ToDateTime(dt_END_DATE.Value);


                DateTime PLAN_BAS_TARIHI = Convert.ToDateTime(dt_START_DATE.Value);

            string sql = "";
            for (int i = 0; i <= ixt.Days; i++)
            {
                
                PLAN_BAS_TARIHI = PLAN_BAS_TARIHI.AddDays(1);

                if (PLAN_BAS_TARIHI.DayOfWeek.ToString() != "Saturday" && PLAN_BAS_TARIHI.DayOfWeek.ToString() != "Sunday")
                {
                    sql += " MIN( CASE  RAPOR_TARIHI WHEN '" + PLAN_BAS_TARIHI.ToString("yyyy-MM-dd") + "'  THEN 'X'  END ) AS ["+ (char)13 + (char)10 + PLAN_BAS_TARIHI.ToString("yyyy").ToString() + (char)13 + (char)10 + "-" + PLAN_BAS_TARIHI.ToString("MM").ToString() + (char)13 + (char)10 + "-" + PLAN_BAS_TARIHI.ToString("dd").ToString() + "],";
                }
            }
            string SQL = String.Format(@" SELECT  MAIL_ADRESI, {0}  COUNT(*) AS Adet  FROM dbo.ADM_KULLANICI_PDKS  WHERE    (RAPOR_TARIHI >= CONVERT(DATETIME, '" + myDTStart.ToString("yyyy-MM-dd").ToString() + "', 102)) AND     (RAPOR_TARIHI <= CONVERT(DATETIME, '" + myDTEND.ToString("yyyy-MM-dd").ToString() + "', 102))  group by MAIL_ADRESI  HAVING  (COUNT(*) > 1) ", sql);
        

            SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter(SQL, MySqlConnection);
            DataSet MyDataSet = new DataSet();
            MySqlDataAdapter.Fill(MyDataSet, "dbo_USER");
            DataViewManager dvManager = new DataViewManager(MyDataSet);
            DataView dv = dvManager.CreateDataView(MyDataSet.Tables[0]);
            GRD_PDKS_PLANI.DataSource = dv;

            int KONTROL=0;
            string MAIL_ADRESLERI = "";
            string  TARIHLER = "";

                for (int i = 0; i < GRDVIEW_PDKS_PLANI.DataRowCount; i++)
                {
                     KONTROL = 0;
                     DataRow DR = dv[i].Row;
                     MAIL_ADRESLERI = DR[0].ToString();
                     TARIHLER = "";
                     for (int xi = 1; xi < DR.Table.Columns.Count-1  ; xi++)
                     {
                         if (DR[xi] != DBNull.Value) 
                         {
                             KONTROL++;
                             TARIHLER += DR.Table.Columns[xi].ColumnName + " / ";
                         } 
                         else 
                         {
                             if (KONTROL > 1)
                             { //MessageBox.Show("Mesaj Gönder");
                                 string TEXT_KULLANICI_UYARI_MAILI_TXT = "";
                                 StringBuilder mesaj = new StringBuilder();
                                 TEXT_KULLANICI_UYARI_MAILI_TXT = "";
                                 TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_PDKS_UYARI_MAILI.Text;
                                 TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_KULLANICI_UYARI_MAILI_TXT.Replace("$TARIH$", String.Format("{0}", TARIHLER));
                                 TEXT_KULLANICI_UYARI_MAILI_TXT = TEXT_KULLANICI_UYARI_MAILI_TXT.Replace("$ADI_SOYADI$", DR[0].ToString());


                                 WebServiceSendMail.SALES_INVOICES fr = new WebServiceSendMail.SALES_INVOICES();
                                 mesaj.Append(TEXT_KULLANICI_UYARI_MAILI_TXT);//DIRECTOR_ADI/MAIL_ADRESLERI
                                 fr.SendMailAsync("noreply.pdks_alert@groupm.com", MAIL_ADRESLERI, " Pdks bilgilendirme mailidir. ", mesaj.ToString(), "");
                                 fr.SendMailCompleted += fr_SendMailCompleted;
                                 KONTROL = 0;
                                 TARIHLER = "";
                             }
                         }
                     }            
                 }
            }

        }
         
    } 

  }  
    

