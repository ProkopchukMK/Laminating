using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class UsersDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public void AddUser(string name, string password, string role)
        {
            Users user = new Users();
            user.UserName = name;
            user.UserPassword = password;
            user.Role = role;
            _entity.Users.Add(user);
            _entity.SaveChanges();
        }
        public List<UsersDTO> GetListUsersDTO()
        {
            var list = _entity.Users.Where(x => x.ID != 0).ToList();
            List<UsersDTO> listUserDTO = new List<UsersDTO>();
            for (int i = 0; i < list.Count; i++)
            {
                UsersDTO userDTO = new UsersDTO();
                userDTO.ID = list[i].ID;
                userDTO.UserName = list[i].UserName;
                userDTO.UserPassword = list[i].UserPassword;
                userDTO.UserRole = list[i].Role;
                listUserDTO.Add(userDTO);
            }
            return listUserDTO;
        }
        public UsersDTO GetUserByName(string name)
        {
            return this.GetListUsersDTO().SingleOrDefault(x => x.UserName == name);
        }
    }
}
