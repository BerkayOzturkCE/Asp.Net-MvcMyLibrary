using MyLibrary.DbOparations;

namespace MyLibrary.Application.AuthorOparation.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdatedAuthorModel UpdatedAuthor{get;set;}
                public int AuthorId{get;set;}

        private readonly IBookStoreDbContext _dbcontext;
        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        { 

            var author = _dbcontext.Authors.SingleOrDefault(x => x.id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı.");
            }
            author.Name = UpdatedAuthor.Name != default ? UpdatedAuthor.Name : author.Name;
            author.Surname = UpdatedAuthor.Surname != default ? UpdatedAuthor.Surname : author.Surname;

            author.Birthday = UpdatedAuthor.Birthday != default ? UpdatedAuthor.Birthday : author.Birthday;
            _dbcontext.SaveChanges();
        }


        public class UpdatedAuthorModel
        {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        }
    }


}