using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class TransmittalService : ITransmittalService
    {
        private IRepository<Transmittal> transmittalRepo = new Repository<Transmittal>();
        private IRepository<User> userRepo = new Repository<User>();
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public TransmittalService()
        {
            userRepo.UnitOfWork = unitOfWork;
            transmittalRepo.UnitOfWork = unitOfWork;
        }

        public IQueryable<Transmittal> GetTransmittalsByUser(User user)
        {
            return transmittalRepo.Where(t => t.Sender.UserId == user.UserId);
        }

        public Transmittal GetTransmittalById(int id)
        {
            return transmittalRepo.Where(t => t.TransmittalId == id).Single();
        }
    }
}
