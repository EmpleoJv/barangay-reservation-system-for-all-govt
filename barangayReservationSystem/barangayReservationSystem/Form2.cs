using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;

namespace barangayReservationSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Submit.Enabled = false;

        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void ForAgeAcceptsOnlyNumbers(object sender, KeyPressEventArgs e)//To make this textbox only accepts Numbers
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ForMobileNumbersAcceptsOnlyNumbers(object sender, KeyPressEventArgs e)//To make this textbox only accepts Numbers
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ForYearAcceptsOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            firstNameTxb.Text = "";
            lastNameTxb.Text = "";
            middleInitialTxb.Text = "";
            ageTxb.Text = "";
            genderTxb.Text = "";
            mobileNumberTxb.Text = "";
            emailTxb.Text = "";
            barangayTxb.Text = "";
            govtAgenciesTxb.SelectedIndex = -1;
            addressTxb.Text = "";
            appointDayTxb.SelectedIndex = -1;
            appointMonthTxb.SelectedIndex = -1;
            appointYearTxb.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string dataBaseChooser = String.Empty;

            if (govtAgenciesTxb.Text == "Overseas Workers Welfare Administration(OWWA)")
            {
                dataBaseChooser = "owwa";
            }
            else if (govtAgenciesTxb.Text == "Philippine Health Insurance Corporation(PHILHEALTH)")
            {
                dataBaseChooser = "philippine_health_insurance_corporation";
            }
            else if (govtAgenciesTxb.Text == "Philippine Overseas Employment Administration(POEA)")
            {
                dataBaseChooser = "philippine_overseas_employment_administration";
            }
            else if (govtAgenciesTxb.Text == "Department of Labor and Employment(DOLE)")
            {
                dataBaseChooser = "department_of_labor_and_employment";
            }
            else if (govtAgenciesTxb.Text == "Department of Trade and Industry(DTI)")
            {
                dataBaseChooser = "department_of_trade_and_industry";
            }
            else if (govtAgenciesTxb.Text == "Bureau of Immigration(BI)")
            {
                dataBaseChooser = "bureau_of_immigration";
            }
            else if (govtAgenciesTxb.Text == "Commission on Filipinos Overseas(CFO)")
            {
                dataBaseChooser = "commission_on_filipinos_overseas";
            }
            else if (govtAgenciesTxb.Text == "Bangko Sentral ng Pilipinas(BSP")
            {
                dataBaseChooser = "bangko_sentral_ng_pilipinas";
            }
            else if (govtAgenciesTxb.Text == "Commission of Elections(COMELEC)")
            {
                dataBaseChooser = "commission_of_elections";
            }
            else if (govtAgenciesTxb.Text == "Department of Tourism(DOT)")
            {
                dataBaseChooser = "department_of_tourism";
            }
            else if (govtAgenciesTxb.Text == "Office of the President(OP)")
            {
                dataBaseChooser = "office_of_the_president";
            }
            else if (govtAgenciesTxb.Text == "Office of the Press Secretary(OPS)")
            {
                dataBaseChooser = "office_of_the_press_secretary";
            }
            else if (govtAgenciesTxb.Text == "Overseas Absentee Voting Secretariat(OAVS)")
            {
                dataBaseChooser = "overseas_absentee_voting_secretariat";
            }
            else if (govtAgenciesTxb.Text == "National Economic and Development Authority(NEDA)")
            {
                dataBaseChooser = "national_economic_and_development authority";
            }
            else if (govtAgenciesTxb.Text == "PAGIBIG Home Development Mutual Fund(PAGIBIG)")
            {
                dataBaseChooser = "pagibig_home_development_mutual_fund";
            }
            else if (govtAgenciesTxb.Text == "Social Security System(SSS)")
            {
                dataBaseChooser = "social_security_system";
            }
            else if (govtAgenciesTxb.Text == "Philippine Institute for Development Studies(PIDS)")
            {
                dataBaseChooser = "philippine_institute_for_development_studies";
            }
            else if (govtAgenciesTxb.Text == "Bureau of Customs(BOC)")
            {
                dataBaseChooser = "bureau_of_customs";
            }
            else
            {

                firstNameTxb.Text = "";
                lastNameTxb.Text = "";
                middleInitialTxb.Text = "";
                ageTxb.Text = "";
                genderTxb.Text = "";
                mobileNumberTxb.Text = "";
                emailTxb.Text = "";
                barangayTxb.Text = "";
                govtAgenciesTxb.SelectedIndex = -1;
                addressTxb.Text = "";
                appointDayTxb.SelectedIndex = -1;
                appointMonthTxb.SelectedIndex = -1;
                appointYearTxb.Text = "";

                MessageBox.Show("Invalid Government Agency" + "Use the drop down");

            }

            string theDate = dateTodayTxb.Value.ToString("yyyy-MM-dd");
            string selectedAgencie = this.govtAgenciesTxb.GetItemText(this.govtAgenciesTxb.SelectedItem);
            string selectedMonth = this.appointMonthTxb.GetItemText(this.appointMonthTxb.SelectedItem);
            string selectedDay = this.appointDayTxb.GetItemText(this.appointDayTxb.SelectedItem);

            try
            {
                string conString = "datasource=localhost;username=root;password=;database=capsstone;";

                string query = "insert into " + dataBaseChooser + " (fname,minitial,lname,age,gender,mnumber,email,rdate,barangay,address,gagencie,ayear,amonth,aday,qrcode)" +
                " values('" + this.firstNameTxb.Text + "','" + this.middleInitialTxb.Text + "','" + this.lastNameTxb.Text + "','" + this.ageTxb.Text + "','" + this.genderTxb.Text + "','" + this.mobileNumberTxb.Text + "','" + this.emailTxb.Text + "','" + theDate + "','" + this.barangayTxb.Text + "','" + this.addressTxb.Text + "','" + selectedAgencie + "','" + this.appointYearTxb.Text + "','" + selectedMonth + "','" + selectedDay + "','" + this.qrCodeLbl.Text + "');";

                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myReader;

                conn.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
                Console.WriteLine(ex);
                MessageBox.Show("Invalid Government Agency" + "Use the drop down");
            }


            string to, from, pass, mail;
            to = "empleojv22@gmail.com";
            from = "janeiyo74@gmail.com";
            mail = "Good";
            pass = "ezofkzronmodfssn";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "Barangay Reservation Confirmation";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Email Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            firstNameTxb.Text = "";
            lastNameTxb.Text = "";
            middleInitialTxb.Text = "";
            ageTxb.Text = "";
            genderTxb.Text = "";
            mobileNumberTxb.Text = "";
            emailTxb.Text = "";
            barangayTxb.Text = "";
            govtAgenciesTxb.SelectedIndex = -1;
            addressTxb.Text = "";
            appointDayTxb.SelectedIndex = -1;
            appointMonthTxb.SelectedIndex = -1;
            appointYearTxb.Text = "";
        }


        private void generateCode_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int randomNum = rand.Next(10000, 99999);
            qrCodeLbl.Text = randomNum + this.firstNameTxb.Text + this.lastNameTxb.Text + ageTxb.Text;

            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(qrCodeLbl.Text, QRCoder.QRCodeGenerator.ECCLevel.M);
            var code = new QRCoder.QRCode(MyData);
            qrCodeViewer.Image = code.GetGraphic(50);

            Submit.Enabled = true;

        }
    }
}
