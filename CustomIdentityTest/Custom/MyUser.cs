using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomIdentityTest.Custom
{
    public class MyUser:IUser<int>
    {

        public int Id { get; set; }

        public string UserName {get;set;}

        public String Password { get; set; }
        public String Email { get; set; }

        public DateTime Birthday { get; set; }
    }
    public class MyContext : IdentityDbContext {
        public MyContext() : base("DefaultConnection") { }
        public DbSet<MyUser> users { get; set; }
    }
    public class MyUserStore<TUser> : IUserStore<TUser>, IUserPasswordStore<TUser>, IUserEmailStore<TUser> where TUser : IdentityUser
    {
        private MyContext db = new MyContext();
        private Models.ApplicationDbContext applicationDbContext;

        public MyUserStore(Models.ApplicationDbContext applicationDbContext)
        {
            // TODO: Complete member initialization
            this.applicationDbContext = applicationDbContext;
        }
        public System.Threading.Tasks.Task CreateAsync(TUser auser)
        {
            var user = new MyUser();
            user.UserName = auser.UserName;
            user.Password = auser.PasswordHash;
            db.users.Add(user);
            return db.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(TUser user)
        {
            db.Entry(user).State = EntityState.Deleted;
            return db.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task<MyUser> FindByIdAsync(int userId)
        {
            return db.users.FindAsync(userId);
        }

        public System.Threading.Tasks.Task<MyUser> FindByNameAsync(string userName)
        {
            return db.users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public System.Threading.Tasks.Task UpdateAsync(MyUser user)
        {
            db.Entry(user).State = EntityState.Modified;
            return db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }


        public System.Threading.Tasks.Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task<TUser> IUserStore<TUser, string>.FindByNameAsync(string userName)
        {
            var result =  Activator.CreateInstance<TUser>();
            return Task.FromResult<TUser>(null);
        }

        public System.Threading.Tasks.Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task<string> IUserPasswordStore<TUser, string>.GetPasswordHashAsync(TUser user)
        {
            return Task.Run(() => {
                return "aabb";
            });
        }

        System.Threading.Tasks.Task<bool> IUserPasswordStore<TUser, string>.HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task IUserPasswordStore<TUser, string>.SetPasswordHashAsync(TUser user, string passwordHash)
        {
            System.Diagnostics.Debug.WriteLine(passwordHash);
            return Task.Run(() => { });
        }

        System.Threading.Tasks.Task IUserStore<TUser, string>.CreateAsync(TUser user)
        {
            //here is create user;
            MyUser m = new MyUser();
            m.Email = user.Email;
            m.Password = user.PasswordHash;
            db.users.Add(m);
            db.SaveChanges();
            return Task.FromResult(m);
        }

        System.Threading.Tasks.Task IUserStore<TUser, string>.DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task<TUser> IUserStore<TUser, string>.FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task IUserStore<TUser, string>.UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            var user = db.users.FirstOrDefaultAsync(u => u.Email == email);
            return Task.FromResult<TUser>(null);
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult<String>(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }
    }
}