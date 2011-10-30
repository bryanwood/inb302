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
            Bind<IUFileContext>().To<UFileContext>();
            Bind<IRestrictionService>().To<RestrictionService>();
            Bind<IEmailService>().To<EmailService>();
            Bind<IUserService>().To<UserService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<IFileService>().To<FileService>();
            Bind<ITransmittalService>().To<TransmittalService>();
            Bind<IUFileService>().To<UFileService>();
        }
    }
}