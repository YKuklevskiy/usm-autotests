using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        public Bitrix24User GetCurrentUser()
        {
            WebItem userLabel = new WebItem("//span[@id='user-name']", "Текст с полным именем текущего пользователя");
            Bitrix24User user = new Bitrix24User(userLabel.InnerText());
            
            return user;
        }
    }
}
