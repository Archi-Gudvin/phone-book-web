using phone_book.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace phone_book.Interfaces
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
        Task Create(Client user);

        /// <summary>
        /// Метод обновления данных клиента
        /// </summary>
        /// <param name="user"></param>
        Task Update(Client user);

        /// <summary>
        /// Метод удаления клиента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
