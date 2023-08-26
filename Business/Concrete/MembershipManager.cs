using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class MembershipManager : IMembershipService
{
   

    private IMembershipDal _membershipDal;
    public MembershipManager(IMembershipDal membershipDal)
    {
        _membershipDal = membershipDal;

    }
    
    public void Add(Membership entity)
    {
        _membershipDal.Add(entity);
    }

    public void Update(Membership entity)
    {
       _membershipDal.Update(entity);
    }

    public void Delete(Membership entity)
    {
        _membershipDal.Delete(entity);
    }

    public List<Membership> GetAll()
    {
        return _membershipDal.GetList();
    }

    public Membership GetById(Guid id)
    {
        return _membershipDal.GetById(id);
    }
}