using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ufiles.Email.UFilesService;

namespace Ufiles.Email
{
    public class UFiles
    {
        private static UFiles current;
        public static UFiles Current{
            get
            {
                if (UFiles.current == null)
                {
                    UFiles.current = new UFiles();
                }
                return UFiles.current;
            }
        }
        private int userId;
        public UFilesService.UFileServiceClient Client{get;set;}
        public UFiles()
        {
            Client = new UFilesService.UFileServiceClient();
            try
            {
                var form = new LoginForm();
                var result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        userId = Client.Login(form.Username, form.Password);
                    }
                    catch
                    {
                        throw new LoginException();
                    }
                }
                else
                {
                   
                }
            }
            catch
            {
                throw  new LoginException();
            }
        }
        
        public List<File> Files { get; private set; }
        public void AddFile(File file)
        {
            LastFile = file;
            Files.Add(file);
        }
        public File LastFile { get; private set; }
    }
    public class LoginException : Exception
    {
        public override string Message
        {
            get
            {
                return "Login Failed";
            }
        }
    }
}
