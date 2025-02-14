using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Data;
using E_commerce_Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork ,IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly AuthServices authServices;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IActionContextAccessor actionContextAccessor;

        public IAuthRepository AuthRepository { get; }

        public IItemRepository ItemRepository { get; }

        public ICartRepository CartRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public UnitOfWorkRepository(ApplicationDbContext dbContext, UserManager<Users> userManager, SignInManager<Users> signInManager, AuthServices authServices, IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authServices = authServices;
            this.httpContextAccessor = httpContextAccessor;
            this.urlHelperFactory = urlHelperFactory;
            this.actionContextAccessor = actionContextAccessor;
            AuthRepository = new AuthRepository(userManager, signInManager, authServices, httpContextAccessor, urlHelperFactory, actionContextAccessor);
            ItemRepository = new ItemRepository(dbContext);
            CartRepository = new CartRepository(dbContext);
            InvoiceRepository = new InvoiceRepository(dbContext);

        }

        public async Task<int> SaveAsync() =>await dbContext.SaveChangesAsync();

        public void Dispose()
        {
           dbContext.Dispose();
        }
    }
}
