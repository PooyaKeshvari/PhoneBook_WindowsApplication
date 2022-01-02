using Model.DomainModels.DTO;
using Model.DomainModels.DTO.AdoCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModels.POCO
{
    public class ContactsRepository
    { 

        #region [-Ctor-]
        public ContactsRepository()
        {

        }
        #endregion

        #region [-Tasks-]

        #region [-Select()-]
        public List<DTO.ContactListAggregates.ContactList> Select()
        {
            using (var context = new PhoneBookDbContext())
            {
                try
                {
                    var q = context.Contacts.ToList();
                    return q;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        #endregion

        #region [-Insert(int id,string fullName,string phoneNumber ,string contactAddress ,string email)-]
        public void Insert
            (int id, string fullName,string phoneNumber ,string contactAddress ,string email)
        {
            using (var context = new PhoneBookDbContext())
            {
                try
                {
                    DTO.ContactListAggregates.ContactList contactListTables = new DTO.ContactListAggregates.ContactList();
                    contactListTables.Id = id;
                    contactListTables.FullName = fullName;
                    contactListTables.PhoneNumber = phoneNumber;
                    contactListTables.ContactAddress = contactAddress;
                    contactListTables.Email = email;  

                    context.Contacts.Add(contactListTables);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }

        }
        #endregion

        #region [-Update(string fullName,string phoneNumber ,string contactAddress ,string email)-]
        public void Update
            (int id , string fullName , string phoneNumber ,string contactAddress,string email)
        {
            using (var context = new PhoneBookDbContext())
            {
                try
                {
                    DTO.ContactListAggregates.ContactList contactListTable = new DTO.ContactListAggregates.ContactList();


                    contactListTable = 
                    context.Contacts.Where(q => q.Id == id).Single();
                 
                    contactListTable.FullName = fullName;
                    contactListTable.PhoneNumber = phoneNumber;
                    contactListTable.ContactAddress = contactAddress;
                    contactListTable.Email = email;
                    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        #endregion

        #region [-Remove(int id)-]
        public void Remove(int id)
        {
            using (var context = new PhoneBookDbContext())
            {
                try
                {
                    DTO.ContactListAggregates.ContactList contactListTable = new DTO.ContactListAggregates.ContactList();

                    contactListTable = context.Contacts.Remove
                        (context.Contacts.Single
                        (q => q.Id == id));
                   

                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }

        }
        #endregion

        #endregion
       
    }
}
