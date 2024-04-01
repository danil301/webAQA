using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Data
{
    public class CreditXPaths : DebitXPaths
    {
        public string OfficialEmploymnet => "//mat-select[@name='RussianEmployment']";
        public string CreditStory => "//a[@href='/res/i/td/ConsentBKI.pdf']/../../../span[@class='rui-checkbox__frame']";
    }
}
