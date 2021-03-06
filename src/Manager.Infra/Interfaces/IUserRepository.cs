namespace Manager.Infra.Interfaces{
    public interface IUserRepository: IBaseRepository<User>
    
    {

        Task<User> GetNyEmail (string email);
        Task<List<User>> SearchEmail(string email);

        Task<List<User>> SearchByName(string name);

    }
}