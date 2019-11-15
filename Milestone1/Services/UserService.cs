using Microsoft.EntityFrameworkCore;
using Milestone1.Data;
using Milestone1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Services
{
    public class UserService
    {
        private readonly MyAppContext _context;

       
        public int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0) throw new ArgumentException("Second number can't be 0");

            return firstNumber / secondNumber;
        }

        public UserService(MyAppContext context)
        {
            _context = context;
        }

        public UserService()
        {
        }

        public async void AddUser(User user)
        {
            if(user==null)
            {
                throw new System.ArgumentException("user cannot be null", "original");
            }
             _context.Add(user);
            await _context.SaveChangesAsync();
        
        }

        public async void checkId(int? ID)
        {
            if (ID == null)
            {
                throw new System.ArgumentException("ID cannot be null", "original");
            }
        }

       

        public bool checkUser(User user)
        {
            if (user == null)
            {
                throw new System.ArgumentException("user cannot be null", "original");
            }
            else
            {
                return true;
            }
           
        }

        public bool checkUser2(int id)
        {
            if (id < 0)
            {
                throw new System.ArgumentException("user cannot be null", "original");
              
            }
            else
            {
                return true;
            }

        }


    }
}
