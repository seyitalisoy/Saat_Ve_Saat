using Business.Abstract;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        [ValidationAspect(typeof(AnnouncementValidator))]
        public void Add(Announcement announcement)
        {
            _announcementDal.Add(announcement);
        }

        public void Delete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
        }

        public List<Announcement> GetAll()
        {
            return _announcementDal.GetAll();
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.Get(a=>a.AnnouncementId.Equals(id));
        }

        [ValidationAspect(typeof(AnnouncementValidator))]
        public void Update(Announcement announcement)
        {
            _announcementDal.Update(announcement);
        }
    }
}
