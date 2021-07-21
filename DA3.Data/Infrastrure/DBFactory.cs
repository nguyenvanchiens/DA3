namespace DA3.Data.Infrastrure
{
    //khởi tạo các đối tượng dbContext
    public class DBFactory : Disposable, IDbFactory
    {
        private FasFoodDbcontext dbcontext;

        public FasFoodDbcontext init()
        {
            return dbcontext ?? (dbcontext = new FasFoodDbcontext());
        }

        protected override void DisposeCore()
        {
            if (dbcontext != null)
            {
                dbcontext.Dispose();
            }
        }
    }
}