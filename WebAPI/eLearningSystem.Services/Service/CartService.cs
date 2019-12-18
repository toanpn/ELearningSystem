﻿using eLearningSystem.Data.Model;
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

        public CartService(IUnitOfWork unitOfWork, ICartRepository cartRepository)
            : base(unitOfWork, cartRepository)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
        }

        public bool CheckExistCart(int? courseId, int id)
        {
            return this._cartRepository.CheckExistCart(courseId, id);
        }

        public int GetNumberCart(int id)
        {
            return _cartRepository.GetNumberCart(id);
        }
    }
}
