﻿using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.CreateEvent
{
    public class CreateProductCommandRequest : IRequest<IResult>
    {
        public string Name { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public string Color { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, IResult>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly CreateProductValidator validator;
        public CreateProductCommandHandler(
            IProductRepository productRepository,
            CreateProductValidator validator,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.validator = validator;
            this.mapper = mapper;
        }
        public Task<IResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken) 
        {
            Product product = mapper.Map<Product>(request);
            var result = validator.Validate(product);
            if (result.Errors.Any())
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            productRepository.Add(product);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Added));
        }
    }
}
