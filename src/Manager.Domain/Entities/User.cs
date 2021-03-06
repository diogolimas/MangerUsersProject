using System.Collections.Generic;
using System;

namespace Manager.Domain.Entities

{
    
    public class User: Base{
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        //justo for Entity Framework
        protected User(){}

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password; 
            _errors = new List<string>();
        }

        //a entidade está fechada, você só consnegue alterar 
        //através do construtor


        public void ChangeName(string name){
            Name = name;
            Validate();
        }

        public void ChangePasssword(string passowrd){
            Password = passowrd;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);


            if(!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new Exception("Alguns campos estão inválidos, por favor, corrijá-os!", _errors[0]);
                
            }
        }

        
    }
}