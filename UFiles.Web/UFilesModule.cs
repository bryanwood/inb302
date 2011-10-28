using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using System.Data.Entity;

namespace UFiles.Web
{
    public class UFilesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UFileContext>().To<UFileContext>();

            Bind<IEmailService>().To<EmailService>();
            Bind<IUserService>().To<UserService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<ITransmittalService>().To<TransmittalService>();
        }
    }
}