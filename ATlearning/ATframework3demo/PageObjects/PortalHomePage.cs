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
        public Bitrix24User GetCurrentUserName()
        {
            WebItem userCaption = new WebItem("//span[@id='user-name']", "Имя текущего пользователя в Битрикс24");
            Bitrix24User userName = new Bitrix24User(userCaption.InnerText());
            return userName;
        }
    }
}
