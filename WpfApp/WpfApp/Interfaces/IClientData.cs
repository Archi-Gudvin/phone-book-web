using WpfApp.Models;
using System.Collections.Generic;

namespace WpfApp.Interfaces
{
    public interface IClientData
    {
        /// <summary>
        /// Метод получения коллекции клиентов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Client> Get();

        /// <summary>
        /// Метод получения конкретного клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Client Get(int id);

        /// <summary>
        /// Метод создания клиента
        /// </summary>
        /// <param name="user"></param>
        void Create(Client client);

        /// <summary>
        /// Метод обновления данных клиента
        /// </summary>
        /// <param name="user"></param>
        void Update(Client client);

        /// <summary>
        /// Метод удаления клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(int id);
    }
}
