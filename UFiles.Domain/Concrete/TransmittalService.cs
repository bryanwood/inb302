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

        public void CreateNewTransmittal(Transmittal t)
        {

        }

        public IQueryable<Transmittal> GetTransmittalsBySender(User user)
        {
            return unitOfWork.TransmittalRepository.Where(t => t.Sender.UserId == user.UserId);
        }

        public IQueryable<Transmittal> GetTransmittalsByRecipient(User user)
        {
            return unitOfWork.TransmittalRepository.Where(t => t.Recipients.Contains(user));
        }

        public Transmittal GetTransmittalById(int id)
        {
            return unitOfWork.TransmittalRepository.Where(t => t.TransmittalId == id).Single();
        }


        

        public Transmittal AddRestriction(Transmittal transmittal, Restriction restriction)
        {
            throw new NotImplementedException();
        }

      
    }
}
