using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class IMessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public IMessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }

        public void Delete(MessageCategory t)
        {
            _messageCategoryDal.Delete(t);
        }

        public MessageCategory GetByID(int id)
        {
            return _messageCategoryDal.GetByID(id);
        }

        public List<MessageCategory> GetList()
        {
            return _messageCategoryDal.GetList();
        }

        public void Insert(MessageCategory t)
        {
            _messageCategoryDal.Insert(t);
        }

        public void Update(MessageCategory t)
        {
            _messageCategoryDal.Update(t);
        }
    }
}
