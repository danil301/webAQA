//using OpenQA.Selenium;
//using Pages.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Pages
//{
//    public class CreditInteractions<T> : Interactions<T> where T : CreditPage
//    {
//        public CreditInteractions(T page) : base(page)
//        {
//        }

//        /// <summary>
//        /// Выбирает "Есть" в поле оффициальное трудоустройство.
//        /// </summary>
//        /// <returns>CreditPage</returns>
//        public CreditInteractions<T> FillOfficialEmloyment(string emp)
//        {
           
//            return (CreditInteractions<T>)FillListBox(_page._oficcialEmploymentInput.element, emp);
//        }

//        /// <summary>
//        /// Заполняет чекбокс кредитной истории.
//        /// </summary>
//        /// <returns>CreditPage</returns>
//        public CreditInteractions<T> FillCreditStoryCheckBox(bool check)
//        {
//            if (check && !_page._driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../input")).Selected)
//            {
//                _page._creditStoryCheckBox.element.Click();
//            }
//            else if (!check && _page._driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../input")).Selected)
//            {
//                _page._creditStoryCheckBox.element.Click();
//            }

//            return this;
//        }

//        /// <summary>
//        /// Переопределённый метод заполнения поля номера телефона.
//        /// </summary>
//        /// <returns></returns>
//        public override CreditInteractions<T> FillPhoneNumber()
//        {
//            return (CreditInteractions<T>)FillActionFields(_page._phoneNumberInput.element, Fields._phoneNumber.Substring(1));
//        }
//    }
//}
