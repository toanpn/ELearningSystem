using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Service
{
    public class CartService : BaseService<Cart>, ICartService
    {
        IUnitOfWork _unitOfWork;
        ICartRepository _cartRepository;
        IUserRepository _userRepository;

        public CartService(IUnitOfWork unitOfWork, ICartRepository cartRepository, IUserRepository userRepository)
            : base(unitOfWork, cartRepository)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public bool CheckExistCart(int? courseId, int id)
        {
            return this._cartRepository.CheckExistCart(courseId, id);
        }

        public ICollection<Cart> GetCartsByUserName(string username)
        {
            User user = _userRepository.GetUserByUserName(username);
            if (user != null)
            {
                ICollection<Cart> cart = _cartRepository.FindBy(m => m.UserId == user.Id).ToList();
                return cart;
            }
            return null;
        }

        public int GetNumberCart(int id)
        {
            return _cartRepository.GetNumberCart(id);
        }
    }
}
