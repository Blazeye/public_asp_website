using System;
using System.Collections.Generic;
using System.Text;
using SKU.DataClasses;

namespace SKU.Models
{

    public interface IUserModel
    {
        /// <summary>
        /// Check if entered username is present in database and password is correct 
        /// </summary>
        /// <param>string username</param>
        /// <param>string password</param>
        /// <returns>UserInfo object or null if not found/correct</returns>
        bool ValidateLogin(string InputUserName, string InputPassword);

        /// <summary>
        /// change user info
        /// </summary>
        /// <returns>true is successfull or false if not successfull</returns>
        bool UpdateUserInfo(UserInfo userInfo);

        /// <summary>
        /// get info from all users
        /// </summary>
        /// <returns>list of UserInfo objects</returns>
        List<UserInfo> FindAllUsers(); /* JH TIP: Dit wordt vaak GetAllUsers genoemd */

        /// <summary>
        /// get info from all users
        /// </summary>
        /// <returns>list of UserInfo objects</returns>
        List<UserColor> FindUserColors(); /* JH TIP: Dit wordt vaak getAllUserColors genoemd */

        int Error { get; }
    }
}
