// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly BookDbContext _dbContext; // Add DbContext
        //private readonly IUnitOfWork _unitOfWork; // Add DbContext

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            BookDbContext dbContext)
            //UnitOfWork unitOfWork) // Inject DbContext
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            //_unitOfWork = unitOfWork;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public Customer Customer { get; set; } // Add Customer property
        public CustomerAddress CustomerAddress { get; set; } // Add CustomerAddress property

        public class InputModel
        {
            public Customer Customer { get; set; }

            [Display(Name = "Address")]
            [RegularExpression(@"^\d+,\s+[^,]+,\s+[^,]+,\s+[^,]+$", ErrorMessage = "Address must be in the format: Street Number, Street Name, City, Country")]
            public string customerAddress { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            // Load Customer information
            Customer = _dbContext.Customers.FirstOrDefault(c => c.Email == userName);
            CustomerAddress = _dbContext.CustomerAddresses
                .Include(ca => ca.Address)
                .Include(ca => ca.Address.Country)
                .FirstOrDefault(c => c.CustomerId == Customer.CustomerId);
            string cusAddress;
            if (CustomerAddress == null) 
            {
                cusAddress = "";
            }
            else
            {
                cusAddress = $"{CustomerAddress.Address.StreetNumber}, {CustomerAddress.Address.StreetName}, {CustomerAddress.Address.City}, {CustomerAddress.Address.Country.CountryName}";
            }
            Input = new InputModel
            {
                Customer = Customer,
                PhoneNumber = phoneNumber,
                customerAddress = cusAddress,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Update customer information
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Email == user.UserName);
            if (customer != null)
            {
                customer.FirstName = Input.Customer.FirstName;
                customer.LastName = Input.Customer.LastName;
                customer.ModifiedTime = DateTime.UtcNow;

                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
            }

            var address = Input.customerAddress;
            var addressParts = address.Split(',');
            if (addressParts.Length != 4)
            {
                ModelState.AddModelError("Input.customerAddress", "Address must be in the format: Street Number, Street Name, City, Country");
                await LoadAsync(user);
                return Page();
            }
            var streetNumber = addressParts[0].Trim();
            var streetName = addressParts[1].Trim();
            var city = addressParts[2].Trim();
            var country = addressParts[3].Trim();
            var customerAddress = _dbContext.CustomerAddresses
                .Include(ca => ca.Address)
                .Include(ca => ca.Address.Country)
                .FirstOrDefault(ca => ca.CustomerId == customer.CustomerId);
            if (customerAddress == null)
            {
                customerAddress = new CustomerAddress
                {
                    CustomerId = customer.CustomerId,
                    Address = new Address
                    {
                        StreetNumber = streetNumber,
                        StreetName = streetName,
                        City = city,
                        Country = new Country { CountryName = country }
                    },
                    AddressStatus = _dbContext.AddressStatuses.FirstOrDefault(ads => ads.AddressStatusName == "Active")
                };
                _dbContext.CustomerAddresses.Add(customerAddress);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                customerAddress.Address.StreetNumber = streetNumber;
                customerAddress.Address.StreetName = streetName;
                customerAddress.Address.City = city;
                customerAddress.Address.Country.CountryName = country;
                _dbContext.CustomerAddresses.Update(customerAddress);
                await _dbContext.SaveChangesAsync();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            return RedirectToPage();
        }
    }
}
