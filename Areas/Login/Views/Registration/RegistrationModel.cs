using ApplicationDb.Entities;
 


using Microsoft.AspNetCore.Mvc;

using ReCaptcha;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMVC.Views.Registration
{
    
    public class RegistrationModel: InputPageModel<global::UserPerson>
    {
        public RegistrationModel(IServiceProvider provider) : base(provider)
        {
        }

        [RecaptchaValidation("Подтвердите что вы не робот")]
        [FromForm(Name = "g-Recaptcha-Response")]
        [BindProperty(Name = "g-Recaptcha-Response")]
        [Display(Name = "g-Recaptcha-Response")]
        public string ReCaptcha { get; set; }

        [BindProperty]
        [DisplayName("Электронный адрес")]
        /*[UniqValidation(
            "Электронная почта уже зарегистрирована",
            EntityTypeName = nameof(Account),
            EntityPropertyName = nameof(Email))]*/
        [DataType(
            DataType.EmailAddress,
            ErrorMessage = "Электронный адрес задан некорректно"
        )]
        [NotNullNotEmptyAttribute( "Не указан электронный адрес")]
        public string Email { get; set; }
 


        [BindProperty]
        [DisplayName("Пароль для входа")]
        [DataType(DataType.Password)]
        [NotNullNotEmptyAttribute( "Не задан пароль для входа")]
        [MinLength(8, ErrorMessage = "Для пароля должна быть не менее 8 символов")]
        public string Password { get; set; }
 

        
        [BindProperty]
        [DisplayName("Подтверждение")]
        [DataType(DataType.Password)]
        [NotNullNotEmptyAttribute( "Не задано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Подтверждение и пароль не совпадают")]
        public string Confirmation { get; set; }
 


        [BindProperty]
        [DisplayName("Фамилия")]
        [NotNullNotEmptyAttribute( "Не указана фамилия пользователя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Фамилия может содержать только буквы русского алфавита")]
        public string SurName { get; set; }

  


        [BindProperty]
        [DisplayName("Имя")]
        [NotNullNotEmptyAttribute( "Не указано имя пользователя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Имя может содержать только буквы русского алфавита")]
        public string FirstName { get; set; }

 


        [BindProperty]
        [DisplayName("Отчество")]
        [NotNullNotEmptyAttribute( "Не указано отчество пользователя")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Отчество может содержать только буквы русского алфавита")]
        public string LastName { get; set; }
 


        [BindProperty]
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        [NotNullNotEmptyAttribute( "Не указана дата рождения пользователя")]
        public DateTime? Birthday { get; set; }
 

        [BindProperty]
        [InputPhone("Введите номер телефона")]        
        /*[UniqValidation(
            "Номер телефона уже зарегистрирован",
            EntityTypeName = nameof(Account),
            EntityPropertyName = nameof(Email))]*/
        [DisplayName("Номер телефона")]
        [NotNullNotEmptyAttribute( "Не указана номер телефона")]
        public string Tel { get; set; }
 

    }
}
