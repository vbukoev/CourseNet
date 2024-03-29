using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CourseNet.Services.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
