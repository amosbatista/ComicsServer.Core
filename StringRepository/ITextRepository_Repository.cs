using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmosBatista.ComicsServer.Core.StringRepository
{
    public interface ITextRepository_Repository<RepositoryType, ReturnType>
    {
        void SaveTextRepository(ITextRepository<RepositoryType> textRepository);

        ReturnType LoadTextRepository();
    }



}
