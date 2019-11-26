using System;
using System.Collections.Generic;
using System.Text;
using SKU.DataClasses;
using SKU.CRUD;
using log4net;
using SKU.Exceptions;

namespace SKU.Models
{
    public class UserModel : IUserModel
    {
        private static ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Error { get; private set; }
        private const int VERIFICATION_FAILED = 0;  //ML: Niet de goede plaats voor errors? Waar is een betere plek?
        private const int USER_NOT_FOUND = 1;
        private const int DATABASE_ERROR = 2;


        public Crud Crud { get; }

        public UserModel(Crud crud)
        {
            Crud = crud;
        }

        public List<UserInfo> FindAllUsers()
        {
            List<UserInfo> allUsers = new List<UserInfo>();

            List<Dictionary<string, string>> result = Crud.SelectQuery("SELECT user.*, colors.color as color_name, colors.id AS color_id " +
                                                                       "FROM user LEFT JOIN colors ON user.color = colors.id");

            if (result != null)
            {
                foreach (var userProperties in result)
                {
                    UserInfo userInfo = new UserInfo();


                    //userInfo.Parse(userProperties);
                    userInfo.Name = userProperties["username"];

                    userInfo.Active = bool.Parse(userProperties["active"]);
                    userInfo.Role = int.Parse(userProperties["role"]);
                    userInfo.Id = int.Parse(userProperties["id"]);

                    UserColor userColor = new UserColor();
                    userColor.Id = int.Parse(userProperties["color_id"]);
                    userColor.Name = userProperties["color_name"];

                    userInfo.Color = userColor;


                    allUsers.Add(userInfo);
                }
                return allUsers;
            }
            LOG.Info("no results returned with FindAllUsers()");
            return null;
        }

        public List<UserColor> FindUserColors()
        {

            List<UserColor> allColors = new List<UserColor>();
            List<Dictionary<string, string>> result = Crud.SelectQuery("SELECT * FROM colors");
            if (result != null)
            {
                foreach (var color in result)
                {
                    UserColor userColor = new UserColor();
                    userColor.Id = int.Parse(color["id"]);
                    userColor.Name = color["color"];

                    allColors.Add(userColor);
                }
                return allColors;
            }
            LOG.Info("no results returned with FindUserColors()");
            return null;

        }

        public bool UpdateUserInfo(UserInfo userInfo)
        {
            string id = userInfo.Id.ToString();
            string name = userInfo.Name;
            bool active = userInfo.Active;
            string color = userInfo.Color.Id.ToString();//error
            string role = userInfo.Role.ToString();

            string activeString;
            if (active)
            {
                activeString = "1";
            }
            else
            {
                activeString = "0";
            }

            int result = (int)Crud.NonQuery("UPDATE user SET username='" + name +
                                                                  "', active= '" + activeString +
                                                                  "', color= '" + color +
                                                                  "', role='" + role +
                                                                  "', updated_at = now()" +                                                                  "' WHERE id='" + id + "'");
            if (result == 1)
            {
                return true;
            }
            LOG.Info("unsuccessfull user update query");
            return false;
        }

        public bool ValidateLogin(string inputUserName, string inputPassword)
        {
            if (inputUserName == null)
            { 
                throw new ArgumentNullException("username");
            }
            if (inputPassword == null)
            {
                throw new ArgumentNullException("password");
            }
            try
            {
                List<Dictionary<string, string>> result = Crud.SelectQuery("SELECT encrypted_password FROM user WHERE username = '" + inputUserName + "'AND role = '5'");
                if (result != null && result.Count > 0)
                {
                    if (BCrypt.Net.BCrypt.Verify(inputPassword, result[0]["encrypted_password"]))
                    {
                        return true;
                    }
                    else
                    {
                        Error = VERIFICATION_FAILED;
                        return false;
                    }
                }
                Error = USER_NOT_FOUND;
                return false;
            }
            catch(DatabaseException ex)
            {
                Error = DATABASE_ERROR;
                throw;
            }
        }
    }
}