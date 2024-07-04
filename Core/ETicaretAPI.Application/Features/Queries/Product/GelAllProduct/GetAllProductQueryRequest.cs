﻿using ETicaretAPI.Application.RequestParemetres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GelAllProduct
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        //public Pagination pagination{ get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
