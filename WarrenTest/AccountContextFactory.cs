using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarrenAPI.Repositories;

namespace WarrenTest
{
    public class AccountContextFactory
    {
        public AccountContext GetAccountContext()
        {
            var options = new DbContextOptionsBuilder<AccountContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                            .Options;
            var dbContext = new AccountContext(options);

            return dbContext;
        }
    }
}
