using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class ContactManager: IContactService
{
    IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void Add(Contact contact)
    {
        _contactDal.Add(contact);
    }

    public void Update(Contact entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Contact entity)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetAll()
    {
        throw new NotImplementedException();
    }

    public Contact GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}