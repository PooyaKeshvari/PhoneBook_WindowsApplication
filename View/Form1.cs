using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form
    {
        #region [-Ctor-]
        public Form1()
        {
            InitializeComponent();
            Ref_ContactsViewModel = new ViewModel.ContactsViewModel();
            dgvContactList.DataSource = Ref_ContactsViewModel.Refresh();
        }
        #endregion

        #region [-Prop-]
        public ViewModel.ContactsViewModel Ref_ContactsViewModel { get; set; }
        public int ID { get; set; }
        public string phoneNumber { get; set; }
        #endregion

        #region [-ContactListRow-]
        private void ContactListRow(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContactList.SelectedRows.Count > 0)
            {
                string FullName = dgvContactList.SelectedRows[0].Cells[1].Value + string.Empty;
                string PhoneNumber = dgvContactList.SelectedRows[0].Cells[2].Value + string.Empty;
                string ContactAddress = dgvContactList.SelectedRows[0].Cells[3].Value + string.Empty;
                string Email = dgvContactList.SelectedRows[0].Cells[4].Value + string.Empty;
                txtFullName.Text = FullName;
                txtPhoneNumber.Text = PhoneNumber;
                txtAddress.Text = ContactAddress;
                txtEmail.Text = Email;

            }
        }
        #endregion

        #region [- Cleartxtbox() -]
        public void Cleartxtbox()
        {
            txtFullName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }
        #endregion

        #region [-BtnRefresh_Click-]
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            dgvContactList.DataSource = Ref_ContactsViewModel.Refresh();
            MessageBox.Show("Your Acction Was Successfull . ", "Successfully !");
            Cleartxtbox();
        }
        #endregion

        #region [-BtnAdd_Click-]
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                    MessageBox.Show("Contact Name Could Not Be Empty :( ", "Oops !!!");
            }

            else
            {
                Ref_ContactsViewModel.Add
                              (ID, txtFullName.Text, txtPhoneNumber.Text,
                              txtAddress.Text, txtEmail.Text);

                MessageBox.Show(string.Format(" This item Was Added With \n Contact Name = {0} \n Phone Number = {1} \n Address = {2} \n Email = {3}", txtFullName.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text), "Successfully Added !");
                Cleartxtbox();
                dgvContactList.DataSource = Ref_ContactsViewModel.Refresh();
            }


        }
        #endregion

        #region [-BtnEdit_Click-]
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))

            {
                MessageBox.Show("Contact Name Could Not Be Empty :( ", "Oops !!!");
            }
            else
            {
                Ref_ContactsViewModel.Edit
                                (System.Convert.ToInt32(dgvContactList.CurrentRow.Cells[0].Value), txtFullName.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text);

                MessageBox.Show(string.Format(" This item Was Updated With \n Contact Name = {0} \n Phone Number = {1} \n Address = {2} \n Email = {3}", txtFullName.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text), "SuccessFully Edited !");
                Cleartxtbox();
                dgvContactList.DataSource = Ref_ContactsViewModel.Refresh();

            }

        }
        #endregion

        #region [-BtnDelete_Click-]
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            Ref_ContactsViewModel.Delete(System.Convert.ToInt32(dgvContactList.CurrentRow.Cells[0].Value));

            MessageBox.Show(string.Format(" This item Was Deleted With \n Contact Name = {0} \n Phone Number = {1} \n Address = {2} \n Email = {3}", txtFullName.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text), "SuccessFully Deleted !");
            Cleartxtbox();
            dgvContactList.DataSource = Ref_ContactsViewModel.Refresh();

        }

        #endregion

        #region [-TxtPhoneNumber_KeyPress-]
        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}

