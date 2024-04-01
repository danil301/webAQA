using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Data
{
    public class DebitXPaths
    {
        public virtual string FirstName => "//input[@name='CardHolderFirstName']";
        public virtual string LastName => "//input[@name='CardHolderLastName']";
        public virtual string MiddleName => "//input[@name='CardHolderMiddleName']";
        public virtual string Male => "//div[@class='rui-radio__label'][normalize-space()='Мужской']/..";
        public virtual string Female => "//div[@class='rui-radio__label'][normalize-space()='Женский']/..";
        public virtual string BirthDate => "//input[@data-mat-calendar='mat-datepicker-1']";
        public virtual string PhoneNumber => "//input[@rtl-automark='Phone']";
        public virtual string CitizenShip => "//mat-select[@name='RussianFederationResident']";
        public virtual string PersonalData => "//a[@href='/res/i/td/ConsentPDProcessing.pdf']/../../../span[@class='rui-checkbox__frame']";
        public virtual string Promotion => "//a[@href='/res/i/td/ConsentPromotion.pdf']/../../../span[@class='rui-checkbox__frame']";
        public virtual string Continue => "//button[@rtl-automark='REGISTRATION_NEXT']";
    }
}
