using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ContactsViewModel
    {
        #region [-Ctor-]
        public ContactsViewModel()
        {
            Ref_ContactsRepository = new Model.DomainModels.POCO.ContactsRepository();
        }
        #endregion

        #region [-Prop-]
        public Model.DomainModels.POCO.ContactsRepository Ref_ContactsRepository { get; set; }

        #endregion

        #region [-Methods-]

        #region [-Refresh()-]
        public dynamic Refresh()
        {
            var s = Ref_ContactsRepository.Select();
            return s;
        }
        #endregion

        #region [-Add(int id , string fullName,string phoneNumber ,string contactAddress ,string email)-]
        public void Add
            (int id, string fullName, string phoneNumber, string contactAddress, string email)
        {
            Ref_ContactsRepository.Insert
                (id,fullName, phoneNumber, contactAddress, email);

        }
        #endregion

        #region [-Edit(int id ,string fullName, string phoneNumber, string contactAddress, string email)-]
        public void Edit
            (int id ,string fullName, string phoneNumber, string contactAddress, string email)
        {
            Ref_ContactsRepository.Update
                (id,fullName, phoneNumber, contactAddress, email);
        }
        #endregion

        #region [-Delete(int id)-]
        public void Delete(int id)
        {
            Ref_ContactsRepository.Remove(id);
        }
        #endregion

        #endregion
    }
}
