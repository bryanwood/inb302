using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ufiles.Email.UFilesService;
using System.Windows.Forms;

namespace Ufiles.Email
{
    public class UFiles
    {
        public delegate void FileAddedHandler();
        public event FileAddedHandler FileAdded;

        private UFilesService.UFileServiceClient client { get; set; }
        private int userId = 0;
        private static UFiles current;
        private bool isStarted = false;
        private UFiles()
        {
            client = new UFileServiceClient();
        }
        public class FileUploadCompleteArgs
        {
            public int TransmittalId { get; set; }
        }
        public delegate void FileUploadCompleteHandler(FileUploadCompleteArgs args);
        public event FileUploadCompleteHandler FileUploadComplete;
        public void Start()
        {
            isStarted = true;
            if (userId == 0)
            {
                GetLogin();
            }
            Files = new List<UploadableFile>();
            var filesForm = new FilesForm();
            var result = filesForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Success");
                if (FileUploadComplete != null)
                {
                    FileUploadComplete(new FileUploadCompleteArgs
                    {
                        TransmittalId = 0,
                    });
                }
            }
            else
            {
                MessageBox.Show("Failure");
            }
        }
        public List<UploadableFile> Files { get; private set; }
        public UploadableFile LastFile { get; private set; }
        public void AddFile(string path, string fileName, string contentType)
        {
            if (!isStarted)
                throw new InvalidOperationException();

            var uploadFile = new UploadableFile
            {
                FileName = fileName,
                Path = path,
                ContentType = contentType,
                UserRestrictions = new List<string[]>(),
                GroupRestrictions = new List<int[]>(),
            };
            Files.Add(uploadFile);
            LastFile = uploadFile;
            FileAdded();
        }
        public void AddUserRestriction(string[] emails)
        {
            if (!isStarted || LastFile==null)
                throw new InvalidOperationException();
            LastFile.UserRestrictions.Add(emails);
        }
        public void AddGroupRestrictions(int[] groupIds)
        {
            if (!isStarted || LastFile == null)
                throw new InvalidOperationException();
            LastFile.GroupRestrictions.Add(groupIds);
        }
        private void GetLogin()
        {
            var loginForm = new LoginForm();
            var result = loginForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                userId = client.Login(loginForm.Username, loginForm.Password);
            }
            loginForm.Dispose();
        }
        public Group[] GetGroups()
        {
            return client.GetGroups(userId);
        }
        public static UFiles Current
        {
            get
            {
                if (UFiles.current == null)
                {
                    UFiles.current = new UFiles();
                }
                return UFiles.current;
            }
        }
    }
    public class UploadableFile
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public List<string[]> UserRestrictions { get; set; }
        public List<int[]> GroupRestrictions { get; set; }
    }

}
