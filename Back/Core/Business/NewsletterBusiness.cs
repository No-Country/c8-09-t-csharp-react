using CohorteApi.Core.Interfaces;
using CohorteApi.Core.Models.Newsletter;
using CohorteApi.Data;
using CohorteApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO.Compression;

namespace CohorteApi.Core.Business
{
    public class NewsletterBusiness : INewsletterBusiness
    {
        ApplicationDbContext _context;
        private readonly string path = "wwwroot/newsletters";
        private readonly string dateFormat = "yyyy-MM-ddTHHmm";

        public NewsletterBusiness(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<string> CreateNewsletter([FromForm] string html, [FromForm] List<IFormFile> images)
        //{
        //    //file needs to be a valid zip - should be improved to avoid injecting javascript

        //    return String.Empty;
        //    throw new NotImplementedException();

        //}
        public async Task<string> CreateNewsletter(Stream file)
        {
            //TODO file needs to be a valid zip - should be improved to avoid injecting javascript/viruses
            var pathContentsPath = await ValidateFile(file);
            var destinyPath = await this.CreatePathForNewsletter();
            var result = SaveContents(pathContentsPath, destinyPath);
            var url = String.Join("/", destinyPath.Split("/").Skip(1)).Replace("\\", "/");
            return url;
        }

        private async Task<string> ValidateFile(Stream file)
        {
            //open file
            //read contents
            //check if contains index.html
            //check if contains "images" folder
            //check if imeges inside folder are actual images.
            //check if index.html doesnt contains javacript code
            //check if html contains  links outside damain
            //ZipFile.
            try
            {
                var tempPath = Path.GetTempPath();
                using (var archive = new ZipArchive(file))
                {
                    var entries = archive.Entries;
                    //validations

                    var guid = Guid.NewGuid();
                    var extractedPath = $"{tempPath}\\{guid}";
                    await Task.Run(() => archive.ExtractToDirectory(extractedPath));
                    return extractedPath;
                }
            }
            catch (Exception e)
            {

                throw;
            }

            //     ZipFile.Open(tempPath, File.ReadAllBytes())
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copy contents from one directory to other
        /// </summary>
        private bool SaveContents(string sourceContents, string directoryPath)
        {
            var rootFiles = Directory.EnumerateFiles(sourceContents);
            var imagesInFolder = Directory.EnumerateFiles(sourceContents + "\\images");
            var dest = $"{directoryPath}\\images";

            try
            {
                // await Task.Run(() =>
                File.Copy(rootFiles.First(), directoryPath + "\\index.html", true)
                //)
                    ;
                foreach (var item in imagesInFolder)
                {
                    var fileName = item.Split("\\").Last();
                    //   await Task.Run(() =>
                    File.Copy(item, $"{dest}\\{fileName}", true)
                        // )
                        ;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        private async Task<string> CreatePathForNewsletter()
        {
            var guid = $"{Guid.NewGuid()}_{DateTime.Now.ToString(dateFormat)}";
            var directoryPath = $"{path}\\{guid}";
            await Task.Run(() => Directory.CreateDirectory(@directoryPath));
            if (Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(@directoryPath + "\\images");
                return directoryPath;
            };
            throw new InvalidProgramException("Couldnt create directory");
        }

        public IEnumerable<NewsletterDTO> GetAll()
        {
            //read folder, split order by
            var newsletters = Directory.GetDirectories(path);
            var nl = newsletters.Select(x => new NewsletterDTO()
            {
                Url = String.Join("/", x.Replace("\\", "/").Split("/").Skip(1)) + "/index.html",
                Date = DateTime.ParseExact(x.Split("_").Last(), dateFormat, CultureInfo.InvariantCulture)
            }).OrderBy(o => o.Date).ToList();

            return nl;
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }

        public Subscription GetSubscriptionByEmail(string email)
        {
            return _context.Subscriptions.FirstOrDefault(x => x.Email == email);
        }

        public Subscription Subscribe(string emailAddress)
        {
            var email = new System.Net.Mail.MailAddress(emailAddress).Address;


            //create
            var newSubscription = new Subscription()
            {
                Email = email,
                DateSubscribed = DateTime.Now,
            };

            var exists = GetSubscriptionByEmail(email);
            if (exists == null)
            {
                _context.Subscriptions.Add(newSubscription);
            }
            else
            {
                if (exists.IsActive) return exists;
                exists.IsActive = true;
                exists.DateSubscribed = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            }

            try
            {
                var rows = _context.SaveChanges();
                return exists != null ? exists : newSubscription;
            }
            catch (Exception)
            {
                //log
                throw;
            }
        }

        public Task<bool> Unsubscribe(string email)
        {
            var exists = GetSubscriptionByEmail(email);
            if (exists == null) return Task.FromResult(true);

            exists.IsActive = false;

            try
            {
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> CreateNewsletter(string html, IList<IFormFile> file)
        {
            throw new NotImplementedException();
        }

    }
}
