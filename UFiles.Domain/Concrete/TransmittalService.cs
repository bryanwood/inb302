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
        private IUnitOfWork unitOfWork;

        public TransmittalService(IUnitOfWork unitOfWork)
        {
            
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Transmittal> GetTransmittalsByUser(User user)
        {
            return unitOfWork.TransmittalRepository.Where(t => t.Sender.UserId == user.UserId);
        }

        public Transmittal GetTransmittalById(int id)
        {
            return unitOfWork.TransmittalRepository.Where(t => t.TransmittalId == id).Single();
        }
    }
}
